using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Security.Data;
using Security.Data.Exceptions;
using Security.Logic.MappingProfiles;
using Security.Logic.Models.Enums;
using Security.Logic.Services;

namespace Security.Logic.Tests.Tests.FeatureTests
{
    public class SecurityServiceDeleteFeatureTests
    {
        private ISecurityService _securityData;
        private IMapper _mapper;
        private Mock<ISecurityData> _mock;

        [SetUp]
        public void Setup()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FetureProfile>();
            }));

            _mock = new Mock<ISecurityData>();
            _mock.Setup(x => x.DeleteFeature(It.Is<int>(id => id == 0)))
                .Returns<int>(id =>
                {
                    throw new SecurityDbException("Feature was not found", ExceptionType.NotFound, EntityType.Function, new []{id.ToString()});
                });
            _mock.Setup(x => x.DeleteFunction(It.Is<int>(id => id != 0)))
                .Returns(() => Task.FromResult(true));

            _securityData = new SecurityService(_mock.Object, _mapper);
        }

        [Test]
        public async Task DeleteFunctionZero()
        {
            var id = 0;

            var result = await _securityData.DeleteFunction(id);
            var expectedMessage = "Nothing was deleted on id = 0";

            Assert.AreEqual(ActionStatus.Warning, result.Status);
            Assert.AreEqual(expectedMessage, result.Message);
            _mock.Verify(data => data.DeleteFunction(It.Is<int>(db => db == 0 )), () => Times.Exactly(0));
        }

        [Test]
        public async Task DeleteFunction()
        {
            var id = 2;

            var result = await _securityData.DeleteFunction(id);

            Assert.AreEqual(ActionStatus.Success, result.Status);
            _mock.Verify(data => data.DeleteFunction(It.Is<int>(db => db == id )), () => Times.Exactly(1));
        }
    }
}