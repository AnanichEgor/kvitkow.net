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

namespace Security.Logic.Tests.Tests.FunctionTests
{
    public class SecurityServiceAddFunctionTests
    {
        private IFunctionService _securityData;
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
                    Task.FromResult(_dbFaker.Functions.Where(l => string.IsNullOrEmpty(m) || l.Name.Contains(m))
                        .OrderBy(l => l.Name).Skip((p - 1) * i).Take(i)));
            _mock.Setup(x => x.AddFunction(It.Is<AccessFunctionDb>(function => function.Id == 0)))
                .Returns(() => Task.FromResult(_dbFaker.Functions.Max(l=>l.Id) + 1));
            _mock.Setup(x => x.AddFunction(It.Is<AccessFunctionDb>(function => function.Id != 0 && _dbFaker.Functions.All(l => l.Id != function.Id))))
                .Returns<AccessFunctionDb>(function => Task.FromResult(function.Id));
            _mock.Setup(x => x.AddFunction(
                    It.Is<AccessFunctionDb>(function => _dbFaker.Functions.Any(l => l.Name.Equals(function.Name)))))
                .Returns<AccessFunctionDb>(function => throw new SecurityDbException(
                    $"Names already exist", ExceptionType.NameExists, EntityType.Function, new []{ function.Name }));
            _mock.Setup(x => x.AddFunction(It.Is<AccessFunctionDb>(function => function.Id != 0 && _dbFaker.Functions.Any(l => l.Id == function.Id))))
                .Returns(() => throw new InvalidOperationException());
            _mock.Setup(x => x.AddFunction(It.Is<AccessFunctionDb>(function => function.Name == "Error!")))
                .Returns(() => throw new Exception());
            _mock.Setup(x => x.AddFunction(
                    It.Is<AccessFunctionDb>(function => !_dbFaker.Features.Any(l => l.Id.Equals(function.FeatureId)))))
                .Returns<AccessFunctionDb>(function => throw new SecurityDbException(
                    $"Feature not Found", ExceptionType.NotFound, EntityType.Feature, new[] { function.FeatureId.ToString() }));
            _mock.Setup(x => x.AddFunction(
                    It.Is<AccessFunctionDb>(function => function.FeatureId == 0)))
                .Returns<AccessFunctionDb>(function => throw new SecurityDbException(
                    $"Feature not Found", ExceptionType.NotFound, EntityType.Feature, new[] { function.FeatureId.ToString() }));

            _securityData = new FunctionService(_mock.Object, _mapper, new AccessFunctionValidator());
        }

        [Test]
        public async Task AddFunction()
        {
            var featureId = _dbFaker.Features.FirstOrDefault()?.Id ?? 0;
            var function = new AccessFunction
            {
                Id = 0,
                Name = "NormalName",
                FeatureId = featureId
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
            var featureId = _dbFaker.Features.FirstOrDefault()?.Id ?? 0;
            var greaterId = _dbFaker.Functions.Max(l => l.Id) + 3;
            var function = new AccessFunction
            {
                Id = greaterId,
                Name = "NormalName",
                FeatureId = featureId
            };

            var functions = await _securityData.AddFunction(function);
            var expected = _dbFaker.Functions.Max(l => l.Id) + 1;

            Console.WriteLine(functions.Message);
            Assert.AreEqual(ActionStatus.Success, functions.Status);
            Assert.AreEqual(expected, functions.Id);
            _mock.Verify(data => data.AddFunction(It.Is<AccessFunctionDb>(db => db.Id == 0 && db.Name.Equals(function.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFunctionExistedId()
        {
            var existedId = _dbFaker.Functions.FirstOrDefault()?.Id??0;
            var featureId = _dbFaker.Features.FirstOrDefault()?.Id ?? 0;
            var function = new AccessFunction
            {
                Id = existedId,
                Name = "NormalName",
                FeatureId = featureId
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
            var featureId = _dbFaker.Features.FirstOrDefault()?.Id ?? 0;
            var function = new AccessFunction
            {
                Id = 0,
                Name = existedName,
                FeatureId = featureId
            };

            var functions = await _securityData.AddFunction(function);
            var expectedMessage = $"Names: {existedName} of Access Function already exist";

            Assert.AreEqual(ActionStatus.Warning, functions.Status);
            Assert.AreEqual(expectedMessage, functions.Message);
            _mock.Verify(data => data.AddFunction(It.Is<AccessFunctionDb>(db => db.Id == 0 && db.Name.Equals(function.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFunctionToLongName()
        {
            var featureId = _dbFaker.Features.FirstOrDefault()?.Id ?? 0;

            var function = new AccessFunction
            {
                Id = 0,
                Name = "In the fields of physical security and information security, access control(AC) is the selective restriction of access to a place or other resource",
                FeatureId = featureId
            };

            var functions = await _securityData.AddFunction(function);
            var expectedMessage = "'Name' must be between 1 and 100 characters. You entered 147 characters.";

            Assert.AreEqual(ActionStatus.Warning, functions.Status);
            Assert.AreEqual(expectedMessage, functions.Message);
            _mock.Verify(data => data.AddFunction(It.IsAny<AccessFunctionDb>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task AddFunctionUnknownError()
        {
            var featureId = _dbFaker.Features.FirstOrDefault()?.Id ?? 0;
            var function = new AccessFunction
            {
                Id = 0,
                Name = "Error!",
                FeatureId = featureId
            };

            var functions = await _securityData.AddFunction(function);
            var expectedMessage = "Something went wrong!";

            Assert.AreEqual(ActionStatus.Error, functions.Status);
            Assert.AreEqual(expectedMessage, functions.Message);
            _mock.Verify(data => data.AddFunction(It.Is<AccessFunctionDb>(db => db.Id == 0 && db.Name.Equals(function.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFunctionExistingRights()
        {
            var featureId = _dbFaker.Features.FirstOrDefault()?.Id ?? 0;
            var function = new AccessFunction()
            {
                Id = 0,
                Name = "NormalName",
                FeatureId = featureId,
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
            var featureId = _dbFaker.Features.FirstOrDefault()?.Id ?? 0;
            var function = new AccessFunction()
            {
                Id = 0,
                Name = "NormalName",
                FeatureId = featureId,
                AccessRights = new List<AccessRight>() { new AccessRight() { Id = 2, Name = "1"} }
            };

            var functions = await _securityData.AddFunction(function);
            var expected = _dbFaker.Functions.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, functions.Status);
            Assert.AreEqual(expected, functions.Id);
            _mock.Verify(data => data.AddFunction(It.Is<AccessFunctionDb>(db => db.Id == 0 && db.Name.Equals(function.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFunctionNotExistingFeature()
        {
            var featureId = 20000;

            var function = new AccessFunction()
            {
                Id = 0,
                Name = "NormalName",
                FeatureId = featureId,
                AccessRights = new List<AccessRight>() { new AccessRight() { Id = 2, Name = "1"} }
            };

            var functions = await _securityData.AddFunction(function);
            var expectedMessage = $"Feature with id = {featureId.ToString()} was not found";

            Assert.AreEqual(ActionStatus.Warning, functions.Status);
            Assert.AreEqual(expectedMessage, functions.Message);
            _mock.Verify(data => data.AddFunction(It.Is<AccessFunctionDb>(db => db.Id == 0 && db.Name.Equals(function.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFunctionFeatureIdZero()
        {
            var function = new AccessFunction()
            {
                Id = 0,
                Name = "NormalName",
                FeatureId = 0,
                AccessRights = new List<AccessRight>() { new AccessRight() { Id = 2, Name = "1"} }
            };

            var functions = await _securityData.AddFunction(function);
            var expectedMessage = "'Feature Id' must be greater than '0'.";

            Assert.AreEqual(ActionStatus.Warning, functions.Status);
            Assert.AreEqual(expectedMessage, functions.Message);
            _mock.Verify(data => data.AddFunction(It.Is<AccessFunctionDb>(db => db.Id == 0 && db.Name.Equals(function.Name))), () => Times.Exactly(0));
        }
    }
}