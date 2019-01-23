using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Security.Data;
using Security.Data.Context;
using Security.Data.Models;

namespace Tests
{
    public class Tests
    {
        private ISecurityData _data;

        [SetUp]
        public async Task Setup()
        {
            _data = DataExtensions.GetISecurityData();

            var id1 = await _data.AddRights(new[]
            {
                new AccessRightDb() {Name = "1"},
                new AccessRightDb() {Name = "2"},
                new AccessRightDb() {Name = "3"}
            });

            var fi = await _data.AddFeature(new FeatureDb()
            {
                Name = "1fi"
            });
            var fi2 = await _data.AddFeature(new FeatureDb()
            {
                Name = "2fi"
            });
            var fi3 = await _data.AddFeature(new FeatureDb()
            {
                Name = "3fi"
            });

            _data.EditFeatureRules(fi, new[] { 1, 2 });
            _data.EditFeatureRules(fi2, new[] { 1, 2 });
            _data.EditFeatureRules(fi3, new[] { 3 });

            var fu1 = await _data.AddFunction(new AccessFunctionDb()
            {
                Name = "1fu",
                FeatureId = 1
            });
            var fu2 = await _data.AddFunction(new AccessFunctionDb()
            {
                Name = "2fu",
                FeatureId = 2
            });
            var fu3 = await _data.AddFunction(new AccessFunctionDb()
            {
                Name = "3fu",
                FeatureId = 3
            });
            _data.EditFunctionRights(fu1, new[] { 1, 2 });
            _data.EditFunctionRights(fu2, new[] { 1, 2 });
            _data.EditFunctionRights(fu3, new[] { 3 });
        }

        [Test]
        public async Task Test1()
        {
            var right = await _data.GetRights(10, 1, "");
            Assert.IsTrue(right.Count() == 3);

            var features = await _data.GetFeatures(10, 1, "");
            Assert.IsTrue(features.Count() == 3);
            Assert.IsTrue(features.SelectMany(l=>l.AvailableAccessRights).Count() == 5);

            var functions = await _data.GetFunctions(10, 1, "");
            Assert.IsTrue(functions.Count() == 3);
            Assert.IsTrue(functions.SelectMany(l => l.AccessRights).Count() == 5);

        }
    }
}