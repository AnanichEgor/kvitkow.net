using System;
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

namespace Security.Logic.Tests.FunctionTests
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
                cfg.AddProfile<AccessFunctionProfile>();
                cfg.AddProfile<AccessFunctionProfile>();
            }));

            _mock = new Mock<ISecurityData>();
            _mock.Setup(x => x.GetFunctions(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns((int i, int p, string m) =>
                    _dbFaker.Functions.Where(l => string.IsNullOrEmpty(m) || l.Name.Contains(m))
                        .OrderBy(l => l.Name).Skip((p - 1) * i).Take(i));
            _securityData = new SecurityService(_mock.Object, _mapper);
        }
        
        [Test]
        public async Task GetFunctions()
        {
            var itemsPerPage = 10;
            var pageNumber = 1;

            var rights = (await _securityData.GetFunctions(itemsPerPage, pageNumber)).ToArray();
            var expected = _mapper.Map<AccessFunction[]>(_dbFaker.Functions
                .OrderBy(l => l.Name).Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToArray());

            CollectionAssert.AreEqual(expected, rights, new FunctionComparer());
            _mock.Verify(
                data => data.GetFunctions(It.Is<int>(i => i == itemsPerPage), It.Is<int>(i => i == pageNumber),
                    It.Is<string>(i => i == null)), () => Times.Exactly(1));
        }

        [Test]
        public async Task GetFunctionsMask()
        {
            var itemsPerPage = 10;
            var pageNumber = 1;
            var mask = "no";

            var rights = (await _securityData.GetFunctions(itemsPerPage, pageNumber, mask)).ToArray();

            var expected = _mapper.Map<AccessFunction[]>(_dbFaker.Functions.Where(l => string.IsNullOrEmpty(mask) || l.Name.Contains(mask))
                .OrderBy(l => l.Name).Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToArray());

            CollectionAssert.AreEqual(expected, rights, new FunctionComparer());
            _mock.Verify(
                data => data.GetFunctions(It.Is<int>(i => i == itemsPerPage), It.Is<int>(i => i == pageNumber),
                    It.Is<string>(i => i == mask)), () => Times.Exactly(1));
        }

        [Test]
        public async Task GetFunctionsZeroItemsPerPage()
        {
            var itemsPerPage = 0;
            var pageNumber = 1;

            var rights = (await _securityData.GetFunctions(itemsPerPage, pageNumber)).ToArray();

            var expected = new AccessFunction[0];

            CollectionAssert.AreEqual(expected, rights, new FunctionComparer());
            _mock.Verify(data => data.GetFunctions(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task GetFunctionsNegativeItemsPerPage()
        {
            var itemsPerPage = -10;
            var pageNumber = 1;

            var rights = (await _securityData.GetFunctions(itemsPerPage, pageNumber)).ToArray();

            var expected = new AccessFunction[0];

            CollectionAssert.AreEqual(expected, rights, new FunctionComparer());
            _mock.Verify(data => data.GetFunctions(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task GetFunctionsZeroPage()
        {
            var itemsPerPage = 10;
            var pageNumber = 0;

            var rights = (await _securityData.GetFunctions(itemsPerPage, pageNumber)).ToArray();

            var expected = new AccessFunction[0];

            CollectionAssert.AreEqual(expected, rights, new FunctionComparer());
            _mock.Verify(data => data.GetFunctions(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task GetFunctionsNegativePage()
        {
            var itemsPerPage = 10;
            var pageNumber = -1;

            var rights = (await _securityData.GetFunctions(itemsPerPage, pageNumber)).ToArray();

            var expected = new AccessFunction[0];

            CollectionAssert.AreEqual(expected, rights, new FunctionComparer());
            _mock.Verify(data => data.GetFunctions(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task GetFunctionsToLongMask()
        {
            var itemsPerPage = 10;
            var pageNumber = 1;
            var mask = "no423534645674tgdfbdfmgvbngdnty356y34gvt634fredgdfhnfgmytngv56t43c5t23rhfghnfgjgdfbdfmgvbngdnty356y34gvt634fredgdfhnfgmytngv56t43c5t23rhfghnfgj";

            var rights = (await _securityData.GetFunctions(itemsPerPage, pageNumber, mask)).ToArray();

            var expected = new AccessFunction[0];

            CollectionAssert.AreEqual(expected, rights, new FunctionComparer());
            _mock.Verify(data => data.GetFunctions(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), () => Times.Exactly(0));
        }

        [Test]
        public async Task GetFunctionsMaskStartsEndsWithSpaces()
        {
            var itemsPerPage = 10;
            var pageNumber = 1;
            var mask = " no ";

            var rights = (await _securityData.GetFunctions(itemsPerPage, pageNumber, mask)).ToArray();

            var expected = _mapper.Map<AccessFunction[]>(_dbFaker.Functions.Where(l => string.IsNullOrEmpty(mask) || l.Name.Contains(mask.Trim()))
                .OrderBy(l => l.Name).Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage).ToArray());

            CollectionAssert.AreEqual(expected, rights, new FunctionComparer());
            _mock.Verify(data => data.GetFunctions(It.Is<int>(i => i == itemsPerPage), It.Is<int>(i => i == pageNumber),
                    It.Is<string>(i => i == mask.Trim())), () => Times.Exactly(1));
        }
    }
}