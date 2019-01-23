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

            Assert.IsTrue(await _data.EditFeatureRules(fi, new[] { 1, 2 }));
            Assert.IsTrue(await _data.EditFeatureRules(fi2, new[] { 1, 2 }));
            Assert.IsTrue(await _data.EditFeatureRules(fi3, new[] { 3 }));

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
            Assert.IsTrue(await _data.EditFunctionRights(fu1, new[] { 1, 2 }));
            Assert.IsTrue(await _data.EditFunctionRights(fu2, new[] { 1, 2 }));
            Assert.IsTrue(await _data.EditFunctionRights(fu3, new[] { 3 }));

            var r1 = await _data.AddRole(new RoleDb()
            {
                Name = "r1"
            });
            var r2 = await _data.AddRole(new RoleDb()
            {
                Name = "r2"
            });
            var r3 = await _data.AddRole(new RoleDb()
            {
                Name = "r3"
            });

            Assert.IsTrue(await _data.EditRoleFunctions(1, new []{1}));
            Assert.IsTrue(await _data.EditRoleFunctions(2, new []{2}));

            Assert.IsTrue(await _data.EditRoleRights(1, new []{1}, new []{2}));
            Assert.IsTrue(await _data.EditRoleRights(2, new []{2}, new []{1}));
            Assert.IsTrue(await _data.EditRoleRights(3, new []{3}, new int [0]));

            Assert.IsTrue(await _data.AddNewUserRights(new UserRightsDb()
            {
                UserId = "1",
                UserLogin = "UserLogin",
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleName = "MiddleName",
                AccessRights = new List<AccessRightDb>() {new AccessRightDb(){Id = 1} },
                DeniedRights = new List<AccessRightDb>() { new AccessRightDb() { Id = 2 } },
                AccessFunctions = new List<AccessFunctionDb>() { new AccessFunctionDb(){Id = 1}},
                Roles = new List<RoleDb>() { new RoleDb() { Id = 1} }
            }));
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

            var roles = await _data.GetRoles(10, 1, "");
            Assert.IsTrue(roles.Count() == 3);
            Assert.IsTrue(roles.SelectMany(l => l.AccessRights).Count() == 3);
            Assert.IsTrue(roles.SelectMany(l => l.DeniedRights).Count() == 2);
            Assert.IsTrue(roles.SelectMany(l => l.AccessFunctions).Count() == 2);

            var userRights = await _data.GetUserRights("1");
            Assert.IsTrue(userRights.AccessRights.Count() == 1);
            Assert.IsTrue(userRights.DeniedRights.Count() == 1);
            Assert.IsTrue(userRights.AccessFunctions.Count() == 1);
            Assert.IsTrue(userRights.Roles.Count() == 1);

        }
    }
}