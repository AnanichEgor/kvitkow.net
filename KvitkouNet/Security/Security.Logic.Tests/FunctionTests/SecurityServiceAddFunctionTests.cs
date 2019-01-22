using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Security.Data;
using Security.Data.Models;
using Security.Logic.MappingProfiles;
using Security.Logic.Models;
using Security.Logic.Models.Enums;
using Security.Logic.Services;
using Security.Logic.Tests.Fakers;

namespace Security.Logic.Tests.FunctionTests
{
    public class SecurityServiceAddFunctionTests
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
            }));

            _mock = new Mock<ISecurityData>();
            _mock.Setup(x => x.GetFunctions(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns((int i, int p, string m) =>
                    _dbFaker.Functions.Where(l => string.IsNullOrEmpty(m) || l.Name.Contains(m))
                        .OrderBy(l => l.Name).Skip((p - 1) * i).Take(i));
            _mock.Setup(x => x.AddFunction(It.Is<AccessFunctionDb>(function => function.Id == 0)))
                .Returns(() => _dbFaker.Functions.Max(l=>l.Id) + 1);
            _mock.Setup(x => x.AddFunction(It.Is<AccessFunctionDb>(function => function.Id != 0 && _dbFaker.Functions.All(l => l.Id != function.Id))))
                .Returns<AccessFunctionDb>(function => function.Id);
            _mock.Setup(x => x.AddFunction(It.Is<AccessFunctionDb>(function => function.Id != 0 && _dbFaker.Functions.Any(l => l.Id == function.Id))))
                .Returns(() => throw new InvalidOperationException());
            _mock.Setup(x => x.AddFunction(It.Is<AccessFunctionDb>(function => function.Name == "Error!")))
                .Returns(() => throw new Exception());

            _securityData = new SecurityService(_mock.Object, _mapper);
        }

        [Test]
        public async Task AddFunction()
        {
            var function = new AccessFunction()
            {
                Id = 0,
                Name = "NormalName",
                FeatureId = 1
            };

            var functions = await _securityData.AddFunction(function);
            var expected = _dbFaker.Functions.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, functions.Status);
            Assert.AreEqual(expected, functions.Id);
            _mock.Verify(data => data.AddFunction(It.Is<AccessFunctionDb>(db => db.Id == 0 && db.Name.Equals(function.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFunctionGreaterId()
        {
            var greaterId = _dbFaker.Functions.Max(l => l.Id) + 3;
            var function = new AccessFunction
            {
                Id = greaterId,
                Name = "NormalName",
                FeatureId = 1
            };

            var functions = await _securityData.AddFunction(function);
            var expected = _dbFaker.Functions.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, functions.Status);
            Assert.AreEqual(expected, functions.Id);
            _mock.Verify(data => data.AddFunction(It.Is<AccessFunctionDb>(db => db.Id == 0 && db.Name.Equals(function.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFunctionExistedId()
        {
            var existedId = _dbFaker.Functions.FirstOrDefault()?.Id??0;
            var function = new AccessFunction
            {
                Id = existedId,
                Name = "NormalName",
                FeatureId = 1
            };

            var functions = await _securityData.AddFunction(function);
            var expected = _dbFaker.Functions.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, functions.Status);
            Assert.AreEqual(expected, functions.Id);
            _mock.Verify(data => data.AddFunction(It.Is<AccessFunctionDb>(db => db.Id == 0 && db.Name.Equals(function.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFunctionExistedName()
        {
            var existedName = _dbFaker.Functions.FirstOrDefault()?.Name;
            var function = new AccessFunction
            {
                Id = 0,
                Name = existedName,
                FeatureId = 1
            };

            var functions = await _securityData.AddFunction(function);
            var expectedMessage = "Name already exists";

            Assert.AreEqual(ActionStatus.Error, functions.Status);
            Assert.AreEqual(expectedMessage, functions.Message);
            _mock.Verify(data => data.AddFunction(It.IsAny<AccessFunctionDb>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task AddFunctionToLongName()
        {
            var function = new AccessFunction
            {
                Id = 0,
                Name = "In the fields of physical security and information security, access control(AC) is the selective restriction of access to a place or other resource",
                FeatureId = 1
            };

            var functions = await _securityData.AddFunction(function);
            var expectedMessage = "Name is longer then 100";

            Assert.AreEqual(ActionStatus.Error, functions.Status);
            Assert.AreEqual(expectedMessage, functions.Message);
            _mock.Verify(data => data.AddFunction(It.IsAny<AccessFunctionDb>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task AddFunctionUnknownError()
        {
            var function = new AccessFunction
            {
                Id = 0,
                Name = "Error!",
                FeatureId = 1
            };

            var functions = await _securityData.AddFunction(function);
            var expectedMessage = "Unknown error";

            Assert.AreEqual(ActionStatus.Error, functions.Status);
            Assert.AreEqual(expectedMessage, functions.Message);
            _mock.Verify(data => data.AddFunction(It.Is<AccessFunctionDb>(db => db.Id == 0 && db.Name.Equals(function.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFunctionExistingRights()
        {
            var function = new AccessFunction()
            {
                Id = 0,
                Name = "NormalName",
                FeatureId = 1,
                AccessRights = _mapper.Map<List<AccessRight>>(_dbFaker.AccessRights.Take(3).ToList())
            };

            var functions = await _securityData.AddFunction(function);
            var expected = _dbFaker.Functions.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, functions.Status);
            Assert.AreEqual(expected, functions.Id);
            _mock.Verify(data => data.AddFunction(It.Is<AccessFunctionDb>(db => db.Id == 0 && db.Name.Equals(function.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFunctionNotExistingRights()
        {
            var function = new AccessFunction()
            {
                Id = 0,
                Name = "NormalName",
                FeatureId = 1,
                AccessRights = new List<AccessRight>() { new AccessRight() { Id = 2, Name = "1"} }
            };

            var functions = await _securityData.AddFunction(function);
            var expected = _dbFaker.Functions.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, functions.Status);
            Assert.AreEqual(expected, functions.Id);
            _mock.Verify(data => data.AddFunction(It.Is<AccessFunctionDb>(db => db.Id == 0 && db.Name.Equals(function.Name))), () => Times.Exactly(1));
        }
    }
}