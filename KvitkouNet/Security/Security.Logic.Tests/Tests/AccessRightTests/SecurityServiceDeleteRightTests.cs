using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Security.Data;
using Security.Logic.Implementations;
using Security.Logic.MappingProfiles;
using Security.Logic.Models.Enums;
using Security.Logic.Services;
using Security.Logic.Tests.Fakers;
using Security.Logic.Validators;

namespace Security.Logic.Tests.Tests.AccessRightTests
{
    public class SecurityServiceDeleteFunctionsTests
    {
        private IRightsService _securityData;
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
            }));

            _mock = new Mock<ISecurityData>();

            _securityData = new RightsService(_mock.Object, _mapper, new AccessRightValidator());
        }

        [Test]
        public async Task DeleteRightZero()
        {
            var id = 0;

            var result = await _securityData.DeleteRight(id);
            var expectedMessage = "Nothing was deleted on id = 0";

            Assert.AreEqual(ActionStatus.Warning, result.Status);
            Assert.AreEqual(expectedMessage, result.Message);
            _mock.Verify(data => data.DeleteRight(It.Is<int>(db => db == 0 )), () => Times.Exactly(0));
        }

        [Test]
        public async Task DeleteRight()
        {
            var id = 2;

            var result = await _securityData.DeleteRight(id);

            Assert.AreEqual(ActionStatus.Success, result.Status);
            _mock.Verify(data => data.DeleteRight(It.Is<int>(db => db == id )), () => Times.Exactly(1));
        }
    }
}