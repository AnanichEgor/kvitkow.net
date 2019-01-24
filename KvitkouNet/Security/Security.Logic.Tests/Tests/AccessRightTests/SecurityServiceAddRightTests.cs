using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Security.Data;
using Security.Data.Exceptions;
using Security.Data.Models;
using Security.Logic.MappingProfiles;
using Security.Logic.Models.Enums;
using Security.Logic.Services;
using Security.Logic.Tests.Fakers;

namespace Security.Logic.Tests.Tests.AccessRightTests
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
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AccessRightProfile>();
                cfg.AddProfile<AccessFunctionProfile>();
                cfg.AddProfile<FetureProfile>();
                cfg.AddProfile<RoleProfile>();
                cfg.AddProfile<UserRightsProfile>();
            }));

            _mock = new Mock<ISecurityData>();
            _mock.Setup(x => x.GetRights(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns((int i, int p, string m) =>
                    Task.FromResult(
                        _dbFaker.AccessRights.Where(l => string.IsNullOrEmpty(m) || l.Name.Contains(m))
                        .OrderBy(l => l.Name).Skip((p - 1) * i).Take(i)));
            //Id == 0
            _mock.Setup(x => x.AddRights(
                    It.Is<AccessRightDb[]>(right => right.Length == 1 && right[0].Id == 0)))
                .Returns(() =>
                {
                    Console.WriteLine("Id == 0");
                    return Task.FromResult(new AccessRightDb[]
                    {
                        new AccessRightDb()
                        {
                            Id = _dbFaker.AccessRights.OrderBy(l => l.Id).Last().Id + 1
                        }
                    });
                });
            //Id != 0
            _mock.Setup(x => x.AddRights(
                It.Is<AccessRightDb[]>(right => right.Length == 1 
                       && right[0].Id != 0 && _dbFaker.AccessRights.All(l => l.Id != right[0].Id))))
                .Returns<AccessRightDb[]>(right =>
                {
                    Console.WriteLine("Id != 0");
                    return Task.FromResult(right);
                });
            //Id == existed
            _mock.Setup(x => x.AddRights(
                It.Is<AccessRightDb[]>(right => right.Length == 1 && right[0].Id != 0
                    && _dbFaker.AccessRights.Any(l => l.Id == right[0].Id))))
                .Returns(() =>
                {
                    Console.WriteLine("Id == existed");
                    throw new InvalidOperationException();
                });
            //Name == existed
            _mock.Setup(x => x.AddRights(
                It.Is<AccessRightDb[]>(right => right.Length == 1
                    && _dbFaker.AccessRights.Any(l => l.Name == right[0].Name))))
                .Returns<AccessRightDb[]>(rights =>
                {
                    Console.WriteLine("Name == existed");
                    throw new SecurityDbException("Names already exist", ExceptionType.NameExists, EntityType.UserRights, rights.Select(l => l.Name).ToArray());
                });
            //Some other error
            _mock.Setup(x => x.AddRights(
                It.Is<AccessRightDb[]>(right => right.Length == 1 && right[0].Name == "Error!")))
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

            var rights = await _securityData.AddRights(new[] {right});
            var expected = _dbFaker.AccessRights.OrderBy(l => l.Id).Last();

            Assert.AreEqual(ActionStatus.Success, rights.Status);
            Assert.AreEqual(expected.Id + 1, rights.AccessRights.SingleOrDefault().Id);
            _mock.Verify(
                data => data.AddRights(It.Is<AccessRightDb[]>(db =>
                    db.Length == 1 && db[0].Id == 0 && db[0].Name.Equals(right.Name))), () => Times.Exactly(1));
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

            var rights = await _securityData.AddRights(new[] { right });
            var expected = _dbFaker.AccessRights.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, rights.Status);
            Assert.AreEqual(expected, rights.AccessRights.SingleOrDefault().Id);
            _mock.Verify(data => data.AddRights(It.Is<AccessRightDb[]>(db => db.Length == 1 && db[0].Id == 0 && db[0].Name.Equals(right.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddRightExistedId()
        {
            var existedId = _dbFaker.AccessRights.Last()?.Id??0;
            var right = new Models.AccessRight
            {
                Id = existedId,
                Name = "NormalName"
            };

            var rights = await _securityData.AddRights(new[] { right });
            var expected = _dbFaker.AccessRights.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, rights.Status);
            Assert.AreEqual(expected, rights.AccessRights.SingleOrDefault().Id);
            _mock.Verify(data => data.AddRights(It.Is<AccessRightDb[]>(db => db.Length == 1 && db[0].Id == 0 && db[0].Name.Equals(right.Name))), () => Times.Exactly(1));
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

            var rights = await _securityData.AddRights(new[] { right });
            var expectedMessage = $"Names: {existedName} of User Rights already exist";

            Assert.AreEqual(ActionStatus.Warning, rights.Status);
            Assert.AreEqual(expectedMessage, rights.Message);
            _mock.Verify(data => data.AddRights(new[] {It.IsAny<AccessRightDb>()}), () => Times.Exactly(0));
        }

        [Test]
        public async Task AddRightToLongName()
        {
            var right = new Models.AccessRight
            {
                Id = 0,
                Name = "In the fields of physical security and information security, access control(AC) is the selective restriction of access to a place or other resource"
            };

            var rights = await _securityData.AddRights(new[] { right });
            var expectedMessage = "Name is longer then 100";

            Assert.AreEqual(ActionStatus.Warning, rights.Status);
            Assert.AreEqual(expectedMessage, rights.Message);
            _mock.Verify(data => data.AddRights(new[] {It.IsAny<AccessRightDb>()}), () => Times.Exactly(0));
        }

        [Test]
        public async Task AddRightUnknownError()
        {
            var right = new Models.AccessRight
            {
                Id = 0,
                Name = "Error!"
            };

            var rights = await _securityData.AddRights(new[] { right });
            var expectedMessage = "Something went wrong!";

            Assert.AreEqual(ActionStatus.Error, rights.Status);
            Assert.AreEqual(expectedMessage, rights.Message);
            _mock.Verify(data => data.AddRights(It.Is<AccessRightDb[]>(db => db.Length == 1 && db[0].Id == 0 && db[0].Name.Equals(right.Name))), () => Times.Exactly(1));
        }
    }
}