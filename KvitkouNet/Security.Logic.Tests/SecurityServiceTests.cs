using Moq;
using NUnit.Framework;
using Security.Data;
using Security.Data.Context;
using Security.Logic.Services;

namespace Security.Logic.Tests
{
    public class SecurityServiceTests
    {
        private ISecurityService _securityData;

        [SetUp]
        public void Setup()
        {
            var mock = new Mock<ISecurityData>();
            _securityData = new SecurityService(mock.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}