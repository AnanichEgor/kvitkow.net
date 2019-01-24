using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Security.Data;
using Security.Data.Exceptions;
using Security.Data.Models;
using Security.Logic.Implementations;
using Security.Logic.MappingProfiles;
using Security.Logic.Models;
using Security.Logic.Models.Enums;
using Security.Logic.Services;
using Security.Logic.Tests.Fakers;
using Security.Logic.Validators;

namespace Security.Logic.Tests.Tests.RoleTests
{
    public class SecurityServiceAddRoleTests
    {
        private IRoleService _securityData;
        private SecurityDbFaker _dbFaker;
        private IMapper _mapper;
        private Mock<ISecurityData> _mock;

        [SetUp]
        public void Setup()
        {
            _dbFaker = new SecurityDbFaker();
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AccessRightProfile>();
                cfg.AddProfile<RoleProfile>();
            }));

            _mock = new Mock<ISecurityData>();
            _mock.Setup(x => x.GetRoles(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns((int i, int p, string m) =>
                    Task.FromResult(_dbFaker.Roles.Where(l => string.IsNullOrEmpty(m) || l.Name.Contains(m))
                        .OrderBy(l => l.Name).Skip((p - 1) * i).Take(i)));
            _mock.Setup(x => x.AddRole(It.Is<RoleDb>(role => role.Id == 0)))
                .Returns(() => Task.FromResult(_dbFaker.Roles.Max(l=>l.Id) + 1));
            _mock.Setup(x => x.AddRole(It.Is<RoleDb>(role => role.Id != 0 && _dbFaker.Roles.All(l => l.Id != role.Id))))
                .Returns<RoleDb>(role => Task.FromResult(role.Id));
            _mock.Setup(x => x.AddRole(
                    It.Is<RoleDb>(role => _dbFaker.Roles.Any(l => l.Name.Equals(role.Name)))))
                .Returns<RoleDb>(role => throw new SecurityDbException(
                    $"Names already exist", ExceptionType.NameExists, EntityType.Role, new []{ role.Name }));
            _mock.Setup(x => x.AddRole(It.Is<RoleDb>(role => role.Id != 0 && _dbFaker.Roles.Any(l => l.Id == role.Id))))
                .Returns(() => throw new InvalidOperationException());
            _mock.Setup(x => x.AddRole(It.Is<RoleDb>(role => role.Name == "Error!")))
                .Returns(() => throw new Exception());

            _securityData = new RoleService(_mock.Object, _mapper, new RoleValidator());
        }

        [Test]
        public async Task AddRole()
        {
            var role = new Role()
            {
                Id = 0,
                Name = "NormalName"
            };

            var roles = await _securityData.AddRole(role);
            var expected = _dbFaker.Roles.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, roles.Status);
            Assert.AreEqual(expected, roles.Id);
            _mock.Verify(data => data.AddRole(It.Is<RoleDb>(db => db.Id == 0 && db.Name.Equals(role.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddRoleGreaterId()
        {
            var greaterId = _dbFaker.Roles.Max(l => l.Id) + 3;
            var role = new Role
            {
                Id = greaterId,
                Name = "NormalName"
            };

            var roles = await _securityData.AddRole(role);
            var expected = _dbFaker.Roles.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, roles.Status);
            Assert.AreEqual(expected, roles.Id);
            _mock.Verify(data => data.AddRole(It.Is<RoleDb>(db => db.Id == 0 && db.Name.Equals(role.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddRoleExistedId()
        {
            var existedId = _dbFaker.Roles.FirstOrDefault()?.Id??0;
            var role = new Role
            {
                Id = existedId,
                Name = "NormalName"
            };

            var roles = await _securityData.AddRole(role);
            var expected = _dbFaker.Roles.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, roles.Status);
            Assert.AreEqual(expected, roles.Id);
            _mock.Verify(data => data.AddRole(It.Is<RoleDb>(db => db.Id == 0 && db.Name.Equals(role.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddRoleExistedName()
        {
            var existedName = _dbFaker.Roles.FirstOrDefault()?.Name;
            var role = new Role
            {
                Id = 0,
                Name = existedName
            };

            var roles = await _securityData.AddRole(role);
            var expectedMessage = $"Names: {existedName} of Role already exist";

            Assert.AreEqual(ActionStatus.Warning, roles.Status);
            Assert.AreEqual(expectedMessage, roles.Message);
            _mock.Verify(data => data.AddRole(It.Is<RoleDb>(db => db.Id == 0 && db.Name.Equals(role.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddRoleToLongName()
        {
            var role = new Role
            {
                Id = 0,
                Name = "In the fields of physical security and information security, access control(AC) is the selective restriction of access to a place or other resource",
            };

            var roles = await _securityData.AddRole(role);
            var expectedMessage = "'Name' must be between 1 and 100 characters. You entered 147 characters.";

            Assert.AreEqual(ActionStatus.Warning, roles.Status);
            Assert.AreEqual(expectedMessage, roles.Message);
            _mock.Verify(data => data.AddRole(It.IsAny<RoleDb>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task AddRoleUnknownError()
        {
            var role = new Role
            {
                Id = 0,
                Name = "Error!"
            };

            var roles = await _securityData.AddRole(role);
            var expectedMessage = "Something went wrong!";

            Assert.AreEqual(ActionStatus.Error, roles.Status);
            Assert.AreEqual(expectedMessage, roles.Message);
            _mock.Verify(data => data.AddRole(It.Is<RoleDb>(db => db.Id == 0 && db.Name.Equals(role.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddRoleExistingRights()
        {
            var role = new Role()
            {
                Id = 0,
                Name = "NormalName",
                AccessRights = _mapper.Map<List<AccessRight>>(_dbFaker.AccessRights.Take(3).ToList())
            };

            var roles = await _securityData.AddRole(role);
            var expected = _dbFaker.Roles.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, roles.Status);
            Assert.AreEqual(expected, roles.Id);
            _mock.Verify(data => data.AddRole(It.Is<RoleDb>(db => db.Id == 0 && db.Name.Equals(role.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddRoleNotExistingRights()
        {
            var role = new Role()
            {
                Id = 0,
                Name = "NormalName",
                AccessRights = new List<AccessRight>() { new AccessRight() { Id = 2, Name = "1"} }
            };

            var roles = await _securityData.AddRole(role);
            var expected = _dbFaker.Roles.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, roles.Status);
            Assert.AreEqual(expected, roles.Id);
            _mock.Verify(data => data.AddRole(It.Is<RoleDb>(db => db.Id == 0 && db.Name.Equals(role.Name))), () => Times.Exactly(1));
        }
        [Test]
        public async Task AddRoleExistingFunctions()
        {
            var role = new Role()
            {
                Id = 0,
                Name = "NormalName",
                AccessFunctions = _mapper.Map<List<AccessFunction>>(_dbFaker.Functions.Take(3).ToList())
            };

            var roles = await _securityData.AddRole(role);
            var expected = _dbFaker.Roles.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, roles.Status);
            Assert.AreEqual(expected, roles.Id);
            _mock.Verify(data => data.AddRole(It.Is<RoleDb>(db => db.Id == 0 && db.Name.Equals(role.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddRoleNotExistingFunctions()
        {
            var role = new Role()
            {
                Id = 0,
                Name = "NormalName",
                AccessFunctions = new List<AccessFunction>() { new AccessFunction() { Id = 15055, Name = "1"} }
            };

            var roles = await _securityData.AddRole(role);
            var expected = _dbFaker.Roles.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, roles.Status);
            Assert.AreEqual(expected, roles.Id);
            _mock.Verify(data => data.AddRole(It.Is<RoleDb>(db => db.Id == 0 && db.Name.Equals(role.Name))), () => Times.Exactly(1));
        }

    }
}