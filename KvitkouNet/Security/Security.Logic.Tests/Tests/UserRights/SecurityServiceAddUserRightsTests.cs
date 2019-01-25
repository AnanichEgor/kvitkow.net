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

namespace Security.Logic.Tests.Tests.UserRights
{
    public class SecurityServiceAddNewUserRightsTests
    {
        private IUserRightsService _securityData;
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
                cfg.AddProfile<UserRightsProfile>();
            }));

            _mock = new Mock<ISecurityData>();
            _mock.Setup(x => x.GetUserRights(It.IsAny<string>()))
                .Returns((string i) =>
                    Task.FromResult(_dbFaker.UserRights.SingleOrDefault(l => l.UserId == i)));
            _mock.Setup(x => x.AddNewUserRights(It.Is<UserRightsDb>(userRights => !string.IsNullOrEmpty(userRights.UserId)
                      && _dbFaker.UserRights.All(l => l.UserId != userRights.UserId))))
                .Returns(() => Task.FromResult(true));
            _mock.Setup(x => x.AddNewUserRights(
                    It.Is<UserRightsDb>(userRights => _dbFaker.UserRights.Any(l => l.UserId.Equals(userRights.UserId)))))
                .Returns<UserRightsDb>(userRights => throw new SecurityDbException(
                    "UserId already exist", ExceptionType.NameExists, EntityType.UserRights, new []{ userRights.UserId }));
           
            _mock.Setup(x => x.AddNewUserRights(It.Is<UserRightsDb>(userRights => userRights.UserLogin == "Error!")))
                .Returns(() => throw new Exception());

            _securityData = new UserRightsService(_mock.Object, _mapper, new UserRightsValidator(), new AccessRequestValidator());
        }

        [Test]
        public async Task AddNewUserRights()
        {
            var userRights = new Models.UserRights()
            {
                UserId = "newOne",
                UserLogin = "newOne"
            };

            var response = await _securityData.AddNewUserRights(userRights);

            Assert.AreEqual(ActionStatus.Success, response.Status);
            _mock.Verify(data => data.AddNewUserRights(It.Is<UserRightsDb>(db => db.UserId == userRights.UserId && db.UserLogin.Equals(userRights.UserLogin))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddNewUserRightsExistedId()
        {
            var existedId = _dbFaker.UserRights.FirstOrDefault()?.UserId;
            var userRights = new Models.UserRights
            {
                UserId = existedId,
                UserLogin = "NormalName"
            };

            var response = await _securityData.AddNewUserRights(userRights);
            var expectedMessage = $"Names: {existedId} of User Rights already exist";

            Assert.AreEqual(ActionStatus.Warning, response.Status);
            Assert.AreEqual(expectedMessage, response.Message);
            _mock.Verify(data => data.AddNewUserRights(It.Is<UserRightsDb>(db => db.UserId == userRights.UserId && db.UserLogin.Equals(userRights.UserLogin))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddNewUserRightsNullId()
        {
            var userRights = new Models.UserRights
            {
                UserLogin = "NormalName"
            };

            var response = await _securityData.AddNewUserRights(userRights);
            var expectedMessage = "'User Id' must not be empty.";

            Assert.AreEqual(ActionStatus.Warning, response.Status);
            Assert.AreEqual(expectedMessage, response.Message);
            _mock.Verify(data => data.AddNewUserRights(It.Is<UserRightsDb>(db => db.UserId == userRights.UserId && db.UserLogin.Equals(userRights.UserLogin))), () => Times.Exactly(0));
        }

        [Test]
        public async Task AddNewUserRightsEmptyId()
        {
            var userRights = new Models.UserRights
            {
                UserId = "",
                UserLogin = "NormalName"
            };

            var response = await _securityData.AddNewUserRights(userRights);
            var expectedMessage = "'User Id' must be between 1 and 100 characters. You entered 0 characters.";

            Assert.AreEqual(ActionStatus.Warning, response.Status);
            Assert.AreEqual(expectedMessage, response.Message);
            _mock.Verify(data => data.AddNewUserRights(It.Is<UserRightsDb>(db => db.UserId == userRights.UserId && db.UserLogin.Equals(userRights.UserLogin))), () => Times.Exactly(0));
        }

        [Test]
        public async Task AddNewUserRightsToLongName()
        {
            var userRights = new Models.UserRights
            {
                UserId = "newOne",
                UserLogin = "In the fields of physical security and information security, access control(AC) is the selective restriction of access to a place or other resource",
            };

            var response = await _securityData.AddNewUserRights(userRights);
            var expectedMessage = "'User Login' must be between 1 and 100 characters. You entered 147 characters.";

            Assert.AreEqual(ActionStatus.Warning, response.Status);
            Assert.AreEqual(expectedMessage, response.Message);
            _mock.Verify(data => data.AddNewUserRights(It.IsAny<UserRightsDb>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task AddNewUserRightsUnknownError()
        {
            var userRights = new Models.UserRights
            {
                UserId = "newOne",
                UserLogin = "Error!"
            };

            var response = await _securityData.AddNewUserRights(userRights);
            var expectedMessage = "Something went wrong!";

            Assert.AreEqual(ActionStatus.Error, response.Status);
            Assert.AreEqual(expectedMessage, response.Message);
            _mock.Verify(data => data.AddNewUserRights(It.Is<UserRightsDb>(db => db.UserId == userRights.UserId && db.UserLogin.Equals(userRights.UserLogin))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddNewUserRightsExistingRights()
        {
            var userRights = new Models.UserRights()
            {
                UserId = "newOne",
                UserLogin = "NormalName",
                AccessRights = _mapper.Map<List<AccessRight>>(_dbFaker.AccessRights.Take(3).ToList())
            };

            var response = await _securityData.AddNewUserRights(userRights);

            Assert.AreEqual(ActionStatus.Success, response.Status);
            _mock.Verify(data => data.AddNewUserRights(It.Is<UserRightsDb>(db => db.UserId == userRights.UserId && db.UserLogin.Equals(userRights.UserLogin))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddNewUserRightsNotExistingRights()
        {
            var userRights = new Models.UserRights()
            {
                UserId = "newOne",
                UserLogin = "NormalName",
                AccessRights = new List<AccessRight>() { new AccessRight() { Id = 2, Name = "1"} }
            };

            var response = await _securityData.AddNewUserRights(userRights);

            Assert.AreEqual(ActionStatus.Success, response.Status);
            _mock.Verify(data => data.AddNewUserRights(It.Is<UserRightsDb>(db => db.UserId == userRights.UserId && db.UserLogin.Equals(userRights.UserLogin))), () => Times.Exactly(1));
        }
        [Test]
        public async Task AddNewUserRightsExistingFunctions()
        {
            var userRights = new Models.UserRights()
            {
                UserId = "newOne",
                UserLogin = "NormalName",
                AccessFunctions = _mapper.Map<List<AccessFunction>>(_dbFaker.Functions.Take(3).ToList())
            };

            var response = await _securityData.AddNewUserRights(userRights);

            Assert.AreEqual(ActionStatus.Success, response.Status);
            _mock.Verify(data => data.AddNewUserRights(It.Is<UserRightsDb>(db => db.UserId == userRights.UserId && db.UserLogin.Equals(userRights.UserLogin))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddNewUserRightsNotExistingFunctions()
        {
            var userRights = new Models.UserRights()
            {
                UserId = "newOne",
                UserLogin = "NormalName",
                AccessFunctions = new List<AccessFunction>() { new AccessFunction() { Id = 15055, Name = "1"} }
            };

            var response = await _securityData.AddNewUserRights(userRights);

            Assert.AreEqual(ActionStatus.Success, response.Status);
            _mock.Verify(data => data.AddNewUserRights(It.Is<UserRightsDb>(db => db.UserId == userRights.UserId && db.UserLogin.Equals(userRights.UserLogin))), () => Times.Exactly(1));
        }

    }
}