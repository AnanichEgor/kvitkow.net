using System.Collections.Generic;
using Bogus;
using Dashboard.Data.DbModels;

namespace TicketManagement.Data.Fakes
{
    public static class TicketFaker
    {
        private static readonly Faker<NewsDb> _fakerNews;

        static TicketFaker()
        {
            _fakerNews = new Faker<NewsDb>();
            _fakerNews.RuleFor(db => db.Description, faker => faker.Lorem.Sentences(10));
            _fakerNews.RuleFor(db => db.EventLink, faker => faker.Internet.Url());  
            _fakerNews.RuleFor(db => db.CreatedDate, faker => faker.Date.Soon());

            _fakerNews.RuleFor(db => db.UserInfo, f =>
            {
                var fakeaddress = new Faker<UserInfoDb>();
                fakeaddress.RuleFor(db => db.FirstName, faker => faker.Lorem.Word());
                fakeaddress.RuleFor(db => db.LastName, faker => faker.Lorem.Word());
                fakeaddress.RuleFor(db => db.Rating, faker => faker.Random.Int(-50, 50));
                return fakeaddress.Generate();
            });
            _fakerNews.RuleFor(db => db.TicketInfo, f =>
            {
                var fakeusercoll = new Faker<TicketInfoDb>();
                fakeusercoll.RuleFor(db => db.Name, faker => faker.Lorem.Word());
                fakeusercoll.RuleFor(db => db.LocationEvent, faker => faker.Lorem.Word());
                fakeusercoll.RuleFor(db => db.Price, faker => faker.Finance.Amount(1,1000,2));
                fakeusercoll.RuleFor(db => db.SellerPhone, faker => faker.Phone.PhoneNumber("###-###-##-##"));
                fakeusercoll.RuleFor(db => db.EventLink, faker => faker.Lorem.Word());
                return fakeusercoll.Generate();
            });
        }

        public static IEnumerable<NewsDb> Generate(int count = 10)
        {
            return _fakerNews.Generate(count);
        }
    }
}