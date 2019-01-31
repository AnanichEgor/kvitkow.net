using System.Collections.Generic;
using Bogus;
using Dashboard.Data.DbModels;

namespace Dashboard.Data.Fakes
{
    public static class NewsFaker
    {
        private static readonly Faker<NewsDb> _fakerNews;

        static NewsFaker()
        {
            _fakerNews = new Faker<NewsDb>();
            _fakerNews.RuleFor(db => db.NewsId, faker => faker.Random.Int());
            _fakerNews.RuleFor(db => db.Description, faker => faker.Lorem.Sentences(10));
            _fakerNews.RuleFor(db => db.EventLink, faker => faker.Internet.Url());  
            _fakerNews.RuleFor(db => db.CreatedDate, faker => faker.Date.Soon());

            _fakerNews.RuleFor(db => db.UserInfo, f =>
            {
                var fakerUserInfo = new Faker<UserInfoDb>();
                fakerUserInfo.RuleFor(db => db.UserInfoDbId, faker => faker.Random.Int());
                fakerUserInfo.RuleFor(db => db.FirstName, faker => faker.Lorem.Word());
                fakerUserInfo.RuleFor(db => db.LastName, faker => faker.Lorem.Word());
                fakerUserInfo.RuleFor(db => db.Rating, faker => faker.Random.Int(-50, 50));
                return fakerUserInfo.Generate();
            });
            _fakerNews.RuleFor(db => db.TicketInfo, f =>
            {
                var fakerTicketInfo = new Faker<TicketInfoDb>();
                fakerTicketInfo.RuleFor(db => db.TicketId, faker => faker.Random.Int());
                fakerTicketInfo.RuleFor(db => db.Name, faker => faker.Lorem.Word());
                fakerTicketInfo.RuleFor(db => db.LocationEvent, faker => faker.Lorem.Word());
                fakerTicketInfo.RuleFor(db => db.Price, faker => faker.Finance.Amount(1,1000,2));
                fakerTicketInfo.RuleFor(db => db.SellerPhone, faker => faker.Phone.PhoneNumber("###-###-##-##"));
                fakerTicketInfo.RuleFor(db => db.EventLink, faker => faker.Lorem.Word());
                return fakerTicketInfo.Generate();
            });
        }

        public static IEnumerable<NewsDb> Generate(int count = 30)
        {
            return _fakerNews.Generate(count);
        }
    }
}