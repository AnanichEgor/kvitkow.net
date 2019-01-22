using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Security.Data;
using Security.Data.Models;
using Security.Logic.MappingProfiles;
using Security.Logic.Models.Enums;
using Security.Logic.Services;
using Security.Logic.Tests.Fakers;

namespace Security.Logic.Tests.AccessRightTests
{
    public class SecurityServiceGetFunctionsTests
    {
        private ISecurityService _securityData;
        private SecurityDbFaker _dbFaker;
        private IMapper _mapper;
        private Mock<ISecurityData> _mock;

        [SetUp]
        public void Setup()
        {
            _dbFaker = new SecurityDbFaker();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<AccessRightProfile>()));

            _mock = new Mock<ISecurityData>();
            _mock.Setup(x => x.GetRights(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns((int i, int p, string m) =>
                    _dbFaker.AccessRights.Where(l => string.IsNullOrEmpty(m) || l.Name.Contains(m))
                        .OrderBy(l => l.Name).Skip((p - 1) * i).Take(i));
            _mock.Setup(x => x.AddRight(It.Is<AccessRightDb>(right => right.Id == 0)))
                .Returns(() => _dbFaker.AccessRights.Max(l=>l.Id) + 1);
            _mock.Setup(x => x.AddRight(It.Is<AccessRightDb>(right => right.Id != 0 && _dbFaker.AccessRights.All(l => l.Id != right.Id))))
                .Returns<AccessRightDb>(right => right.Id);
            _mock.Setup(x => x.AddRight(It.Is<AccessRightDb>(right => right.Id != 0 && _dbFaker.AccessRights.Any(l => l.Id == right.Id))))
                .Returns(() => throw new InvalidOperationException());
            _mock.Setup(x => x.AddRight(It.Is<AccessRightDb>(right => right.Name == "Error!")))
                .Returns(() => throw new Exception());

            _securityData = new SecurityService(_mock.Object, _mapper);
        }

        [Test]
        public async Task AddRight()
        {
            var right = new Models.AccessRight
            {
                Id = 0,
                Name = "NormalName"
            };

            var rights = await _securityData.AddRight(right);
            var expected = _dbFaker.AccessRights.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, rights.Status);
            Assert.AreEqual(expected, rights.Id);
            _mock.Verify(data => data.AddRight(It.Is<AccessRightDb>(db => db.Id == 0 && db.Name.Equals(right.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddRightGreaterId()
        {
            var greaterId = _dbFaker.AccessRights.Max(l => l.Id) + 3;
            var right = new Models.AccessRight
            {
                Id = greaterId,
                Name = "NormalName"
            };

            var rights = await _securityData.AddRight(right);
            var expected = _dbFaker.AccessRights.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, rights.Status);
            Assert.AreEqual(expected, rights.Id);
            _mock.Verify(data => data.AddRight(It.Is<AccessRightDb>(db => db.Id == 0 && db.Name.Equals(right.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddRightExistedId()
        {
            var existedId = _dbFaker.AccessRights.FirstOrDefault()?.Id??0;
            var right = new Models.AccessRight
            {
                Id = existedId,
                Name = "NormalName"
            };

            var rights = await _securityData.AddRight(right);
            var expected = _dbFaker.AccessRights.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, rights.Status);
            Assert.AreEqual(expected, rights.Id);
            _mock.Verify(data => data.AddRight(It.Is<AccessRightDb>(db => db.Id == 0 && db.Name.Equals(right.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddRightExistedName()
        {
            var existedName = _dbFaker.AccessRights.FirstOrDefault()?.Name;
            var right = new Models.AccessRight
            {
                Id = 0,
                Name = existedName
            };

            var rights = await _securityData.AddRight(right);
            var expectedMessage = "Name already exists";

            Assert.AreEqual(ActionStatus.Error, rights.Status);
            Assert.AreEqual(expectedMessage, rights.Message);
            _mock.Verify(data => data.AddRight(It.IsAny<AccessRightDb>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task AddRightToLongName()
        {
            var right = new Models.AccessRight
            {
                Id = 0,
                Name = "In the fields of physical security and information security, access control(AC) is the selective restriction of access to a place or other resource"
            };

            var rights = await _securityData.AddRight(right);
            var expectedMessage = "Name is longer then 100";

            Assert.AreEqual(ActionStatus.Error, rights.Status);
            Assert.AreEqual(expectedMessage, rights.Message);
            _mock.Verify(data => data.AddRight(It.IsAny<AccessRightDb>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task AddRightUnknownError()
        {
            var right = new Models.AccessRight
            {
                Id = 0,
                Name = "Error!"
            };

            var rights = await _securityData.AddRight(right);
            var expectedMessage = "Unknown error";

            Assert.AreEqual(ActionStatus.Error, rights.Status);
            Assert.AreEqual(expectedMessage, rights.Message);
            _mock.Verify(data => data.AddRight(It.Is<AccessRightDb>(db => db.Id == 0 && db.Name.Equals(right.Name))), () => Times.Exactly(1));
        }
    }
}