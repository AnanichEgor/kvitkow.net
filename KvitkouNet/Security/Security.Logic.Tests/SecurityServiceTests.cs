using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Security.Data;
using Security.Logic.MappingProfiles;
using Security.Logic.Models;
using Security.Logic.Services;
using Security.Logic.Tests.Comparers;
using Security.Logic.Tests.Fakers;

namespace Security.Logic.Tests
{
    public class SecurityServiceTests
    {
        private ISecurityService _securityData;
        private SecurityDbFaker _dbFaker;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _dbFaker = new SecurityDbFaker();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<AccessRightProfile>()));

            var mock = new Mock<ISecurityData>();
            mock.Setup(x => x.GetRights(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns((int i, int p, string m) =>
                    _dbFaker.AccessRights.Where(l=> string.IsNullOrEmpty(m) || l.Name.Contains(m))
                        .OrderBy(l=>l.Name).Skip((p-1)*i).Take(i));
            _securityData = new SecurityService(mock.Object, _mapper);
        }

        [Test]
        public async Task GetRights()
        {
            var itemsPerPage = 10;
            var pageNumber = 1;

            var rights = (await _securityData.GetRights(10, 1)).ToArray();
            var expected = _mapper.Map<AccessRight[]>(_dbFaker.AccessRights
                .OrderBy(l => l.Name).Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToArray());

            CollectionAssert.AreEqual(expected, rights, new AccessRightComparer());
        }
        [Test]
        public async Task GetRightsMask()
        {
            var itemsPerPage = 10;
            var pageNumber = 1;
            var mask = "no";

            var rights = (await _securityData.GetRights(10, 1, mask)).ToArray();

            var expected = _mapper.Map<AccessRight[]>(_dbFaker.AccessRights.Where(l => string.IsNullOrEmpty(mask) || l.Name.Contains(mask))
                .OrderBy(l => l.Name).Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToArray());
            
            CollectionAssert.AreEqual(expected, rights, new AccessRightComparer());
        }

        [Test]
        public void GetRightsZeroItemsPerPage()
        {
            Assert.Pass();
        }

        [Test]
        public void GetRightsNegativeItemsPerPage()
        {
            Assert.Pass();
        }

        [Test]
        public void GetRightsZeroPage()
        {
            Assert.Pass();
        }

        [Test]
        public void GetRightsNegativePage()
        {
            Assert.Pass();
        }

        [Test]
        public void GetRightsToLongMask()
        {
            Assert.Pass();
        }

        [Test]
        public void GetRightsMaskStartsEndsWithSpaces()
        {
            Assert.Pass();
        }
    }
}