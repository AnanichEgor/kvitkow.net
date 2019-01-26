using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Security.Data;
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
                "1",
                "2",
                "3"
            });

            var fi = await _data.AddFeature("1fi");
            var fi2 = await _data.AddFeature("2fi");
            var fi3 = await _data.AddFeature("3fi");

            Assert.IsTrue(await _data.EditFeatureRights(fi, new[] { 1, 2 }));
            Assert.IsTrue(await _data.EditFeatureRights(fi2, new[] { 1, 2 }));
            Assert.IsTrue(await _data.EditFeatureRights(fi3, new[] { 3 }));

            var fu1 = await _data.AddFunction("1fu", 1);
            var fu2 = await _data.AddFunction("2fu", 2);
            var fu3 = await _data.AddFunction("3fu", 3);
            Assert.IsTrue(await _data.EditFunctionRights(fu1, new[] { 1, 2 }));
            Assert.IsTrue(await _data.EditFunctionRights(fu2, new[] { 1, 2 }));
            Assert.IsTrue(await _data.EditFunctionRights(fu3, new[] { 3 }));

            var r1 = await _data.AddRole("r1");
            var r2 = await _data.AddRole("r2");
            var r3 = await _data.AddRole("r3");

            Assert.IsTrue(await _data.EditRoleFunctions(1, new []{1}));
            Assert.IsTrue(await _data.EditRoleFunctions(2, new []{2}));

            Assert.IsTrue(await _data.EditRoleRights(1, new []{1}, new []{2}));
            Assert.IsTrue(await _data.EditRoleRights(2, new []{2}, new []{1}));
            Assert.IsTrue(await _data.EditRoleRights(3, new []{3}, new int [0]));

            Assert.IsTrue(await _data.AddUser(new UserInfoDb()
            {
                UserId = "1",
                UserLogin = "UserLogin",
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleName = "MiddleName"
            }));
            Assert.IsTrue(await _data.EditUserRights("1",
                new[] {1},
                new[] {2, 3},
                new[] {1},
                new[] {3}
            ));
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

            Assert.IsTrue(await _data.EditUserRights("1", new[] { 2, 3 }, new[] { 2 }, new[] { 2 }, new int[0]));

            var userRights2 = await _data.GetUserRights("1");
            Assert.IsTrue(userRights2.AccessRights.Count() == 1);
            Assert.IsTrue(!userRights2.DeniedRights.Any());
            Assert.IsTrue(userRights2.AccessFunctions.Count() == 1);
            Assert.IsTrue(userRights2.Roles.Count() == 2);

        }
    }
}