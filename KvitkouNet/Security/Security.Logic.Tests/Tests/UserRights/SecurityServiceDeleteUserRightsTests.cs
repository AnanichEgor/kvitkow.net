using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Security.Data;
using Security.Data.Exceptions;
using Security.Logic.Implementations;
using Security.Logic.MappingProfiles;
using Security.Logic.Models.Enums;
using Security.Logic.Services;
using Security.Logic.Validators;

namespace Security.Logic.Tests.Tests.UserRights
{
    public class SecurityServiceDeleteUserRightsTests
    {
        private IUserRightsService _securityData;
        private IMapper _mapper;
        private Mock<ISecurityData> _mock;

        [SetUp]
        public void Setup()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AccessRightProfile>();
                cfg.AddProfile<RoleProfile>();
            }));

            _mock = new Mock<ISecurityData>();
            _mock.Setup(x => x.DeleteUserRights(It.Is<string>(id => string.IsNullOrEmpty(id))))
                .Returns<string>(id => 
                    throw new SecurityDbException("User Rights was not found", ExceptionType.NotFound, EntityType.Role, new []{id}));
            _mock.Setup(x => x.DeleteUserRights(It.Is<string>(id => !string.IsNullOrEmpty(id))))
                .Returns(() => Task.FromResult(true));

            _securityData = new UserRightsService(_mock.Object, _mapper, new UserRightsValidator(), new AccessRequestValidator());
        }

        [Test]
        public async Task DeleteUserRightsEmpty()
        {
            var result = await _securityData.DeleteUserRights("");
            var expectedMessage = "Nothing was deleted on empty id";

            Assert.AreEqual(ActionStatus.Warning, result.Status);
            Assert.AreEqual(expectedMessage, result.Message);
            _mock.Verify(data => data.DeleteUserRights(It.Is<string>(db => db == "" )), () => Times.Exactly(0));
        }

        [Test]
        public async Task DeleteRole()
        {
            var result = await _securityData.DeleteUserRights("UserId");

            Assert.AreEqual(ActionStatus.Success, result.Status);
            _mock.Verify(data => data.DeleteUserRights(It.Is<string>(db => db == "UserId")), () => Times.Exactly(1));
        }
    }
}