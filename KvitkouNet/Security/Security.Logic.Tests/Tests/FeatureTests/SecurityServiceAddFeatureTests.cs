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

namespace Security.Logic.Tests.Tests.FeatureTests
{
    public class SecurityServiceAddFeatureTests
    {
        private IFeatureService _securityData;
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
                cfg.AddProfile<FetureProfile>();
            }));

            _mock = new Mock<ISecurityData>();
            _mock.Setup(x => x.GetFeatures(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns((int i, int p, string m) =>
                    Task.FromResult(_dbFaker.Features.Where(l => string.IsNullOrEmpty(m) || l.Name.Contains(m))
                        .OrderBy(l => l.Name).Skip((p - 1) * i).Take(i)));
            _mock.Setup(x => x.AddFeature(It.Is<FeatureDb>(feature => feature.Id == 0)))
                .Returns(() => Task.FromResult(_dbFaker.Features.Max(l=>l.Id) + 1));
            _mock.Setup(x => x.AddFeature(It.Is<FeatureDb>(feature => feature.Id != 0 && _dbFaker.Features.All(l => l.Id != feature.Id))))
                .Returns<FeatureDb>(feature => Task.FromResult(feature.Id));
            _mock.Setup(x => x.AddFeature(
                    It.Is<FeatureDb>(feature => _dbFaker.Features.Any(l => l.Name.Equals(feature.Name)))))
                .Returns<FeatureDb>(feature => throw new SecurityDbException(
                    "Names already exist", ExceptionType.NameExists, EntityType.Function, new []{ feature.Name }));
            _mock.Setup(x => x.AddFeature(It.Is<FeatureDb>(feature => feature.Id != 0 && _dbFaker.Features.Any(l => l.Id == feature.Id))))
                .Returns(() => throw new InvalidOperationException());
            _mock.Setup(x => x.AddFeature(It.Is<FeatureDb>(feature => feature.Name == "Error!")))
                .Returns(() => throw new Exception());

            _securityData = new FeatureService(_mock.Object, _mapper, new FeatureValidator());
        }

        [Test]
        public async Task AddFeature()
        {
            var feature = new Feature
            {
                Id = 0,
                Name = "NormalName"
            };

            var features = await _securityData.AddFeature(feature);
            var expected = _dbFaker.Features.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, features.Status);
            Assert.AreEqual(expected, features.Id);
            _mock.Verify(data => data.AddFeature(It.Is<FeatureDb>(db => db.Id == 0 && db.Name.Equals(feature.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFeatureGreaterId()
        {
            var greaterId = _dbFaker.Features.Max(l => l.Id) + 3;
            var feature = new Feature
            {
                Id = greaterId,
                Name = "NormalName"
            };

            var features = await _securityData.AddFeature(feature);
            var expected = _dbFaker.Features.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, features.Status);
            Assert.AreEqual(expected, features.Id);
            _mock.Verify(data => data.AddFeature(It.Is<FeatureDb>(db => db.Id == 0 && db.Name.Equals(feature.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFeatureExistedId()
        {
            var existedId = _dbFaker.Features.FirstOrDefault()?.Id??0;
            var feature = new Feature
            {
                Id = existedId,
                Name = "NormalName"
            };

            var features = await _securityData.AddFeature(feature);
            var expected = _dbFaker.Features.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, features.Status);
            Assert.AreEqual(expected, features.Id);
            _mock.Verify(data => data.AddFeature(It.Is<FeatureDb>(db => db.Id == 0 && db.Name.Equals(feature.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFeatureExistedName()
        {
            var existedName = _dbFaker.Features.FirstOrDefault()?.Name;
            var feature = new Feature
            {
                Id = 0,
                Name = existedName
            };

            var features = await _securityData.AddFeature(feature);
            var expectedMessage = $"Names: {existedName} of Access Function already exist";

            Assert.AreEqual(ActionStatus.Warning, features.Status);
            Assert.AreEqual(expectedMessage, features.Message);
            _mock.Verify(data => data.AddFeature(It.Is<FeatureDb>(db => db.Id == 0 && db.Name.Equals(feature.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFeatureToLongName()
        {
            var feature = new Feature
            {
                Id = 0,
                Name = "In the fields of physical security and information security, access control(AC) is the selective restriction of access to a place or other resource"
            };

            var features = await _securityData.AddFeature(feature);
            var expectedMessage = "'Name' must be between 1 and 100 characters. You entered 147 characters.";

            Assert.AreEqual(ActionStatus.Warning, features.Status);
            Assert.AreEqual(expectedMessage, features.Message);
            _mock.Verify(data => data.AddFeature(It.IsAny<FeatureDb>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task AddFeatureUnknownError()
        {
            var feature = new Feature
            {
                Id = 0,
                Name = "Error!"
            };

            var features = await _securityData.AddFeature(feature);
            var expectedMessage = "Something went wrong!";

            Assert.AreEqual(ActionStatus.Error, features.Status);
            Assert.AreEqual(expectedMessage, features.Message);
            _mock.Verify(data => data.AddFeature(It.Is<FeatureDb>(db => db.Id == 0 && db.Name.Equals(feature.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFeatureExistingRights()
        {
            var feature = new Feature
            {
                Id = 0,
                Name = "NormalName",
                AvailableAccessRights = _mapper.Map<List<AccessRight>>(_dbFaker.AccessRights.Take(3).ToList())
            };

            var features = await _securityData.AddFeature(feature);
            var expected = _dbFaker.Features.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, features.Status);
            Assert.AreEqual(expected, features.Id);
            _mock.Verify(data => data.AddFeature(It.Is<FeatureDb>(db => db.Id == 0 && db.Name.Equals(feature.Name))), () => Times.Exactly(1));
        }

        [Test]
        public async Task AddFeatureNotExistingRights()
        {
            var feature = new Feature
            {
                Id = 0,
                Name = "NormalName",
                AvailableAccessRights = new List<AccessRight> { new AccessRight { Id = 2, Name = "1"} }
            };

            var features = await _securityData.AddFeature(feature);
            var expected = _dbFaker.Features.Max(l => l.Id) + 1;

            Assert.AreEqual(ActionStatus.Success, features.Status);
            Assert.AreEqual(expected, features.Id);
            _mock.Verify(data => data.AddFeature(It.Is<FeatureDb>(db => db.Id == 0 && db.Name.Equals(feature.Name))), () => Times.Exactly(1));
        }
    }
}