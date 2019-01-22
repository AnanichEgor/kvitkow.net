using System.Linq;
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
        public void Setup()
        {
            _data = DataExtensions.GetISecurityData();
        }

        [Test]
        public void Test1()
        {
            var rights = _data.GetRights(10, 1, "mm");
            var id = _data.AddRight(new AccessRightDb() {Name = "rbfbgmm"});
            var id2 = _data.AddRight(new AccessRightDb() {Name = "rbfbgmmgfdsrbgerberbhrbrbhrthbtrhrthtrhbrthbrthrbfbgmmgfdsrbgerberbhrbrbhrthbtrhrthtrhbrthbrthrdfhsegserhrtjtyjyukytherthrth2" });
            
            var rights2 = _data.GetRights(10, 1, "mm").ToList();
        }
    }
}