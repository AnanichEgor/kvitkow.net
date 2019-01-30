using Bogus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UserManagement.Data.DbModels;
using UserManagement.Data.DbModels.Enums;

namespace UserManagement.Data.Fakers
{
    public class UserFaker
    {
        private static Faker<UserDB> _faker;

        static UserFaker()
        {
            _faker = new Faker<UserDB>();
            _faker.RuleFor(x => x.Id, f => f.IndexFaker.ToString());
            _faker.RuleFor(x => x.AccountDB, a =>
            {
                var fakeAcc = new Faker<AccountDB>();
                fakeAcc.RuleFor(x => x.Login, f => f.Lorem.Word());
                fakeAcc.RuleFor(x => x.Password, f => f.Lorem.Word());
                fakeAcc.RuleFor(x => x.Email, f => f.Lorem.Word());
                return fakeAcc.Generate();
            });
            _faker.RuleFor(x => x.ProfileDB, a =>
            {
                var fakeAcc = new Faker<ProfileDB>();
                fakeAcc.RuleFor(x => x.FirstName, f => f.Lorem.Word());
                fakeAcc.RuleFor(x => x.LastName, f => f.Lorem.Word());
                fakeAcc.RuleFor(x => x.Sex, f => (SexDB)f.Random.Int(0, 1));
                fakeAcc.RuleFor(x => x.Birthday, f => f.Date.Between(new System.DateTime(1900, 1, 1), new System.DateTime(2015, 1, 1)));
                fakeAcc.RuleFor(x => x.Rating, f => f.Random.Int(0, 100));
                fakeAcc.RuleFor(x => x.RegistrationDate, f => f.Date.Past());
                return fakeAcc.Generate();
            });
        }

        public static IEnumerable<UserDB> Generate(int count = 10)
        {
            return _faker.Generate(count);
        }
    }
}
