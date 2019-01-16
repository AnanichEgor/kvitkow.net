using System.Collections.Generic;
using Bogus;
using TicketManagement.Data.DbModels;
using TicketManagement.Data.DbModels.Enums;

namespace TicketManagement.Data.Fakes
{
    public static class TicketFaker
    {
        private static readonly Faker<TicketDb> _fakerTicket;

        static TicketFaker()
        {
            _fakerTicket = new Faker<TicketDb>();
            _fakerTicket.RuleFor(db => db.Name, faker => faker.Lorem.Sentence(4, 10));
            _fakerTicket.RuleFor(db => db.AdditionalData, faker => faker.Lorem.Sentence(10, 20));
            _fakerTicket.RuleFor(db => db.SellerPhone, faker => faker.Phone.PhoneNumber("###-###-####"));
            _fakerTicket.RuleFor(db => db.CreatedDate, faker => faker.Date.Past());
            _fakerTicket.RuleFor(db => db.EventLink, faker => faker.Lorem.Word());
            _fakerTicket.CustomInstantiator(faker => new TicketDb()).Rules((faker, db) =>
            {
                db.Free = faker.Random.Bool();
                if (!db.Free)
                    db.Price = faker.Random.Int(1, 100);
                else
                    db.Price = null;
            });
            _fakerTicket.RuleFor(db => db.PaymentSystems, faker => faker.Lorem.Word());
            _fakerTicket.RuleFor(db => db.TimeActual, faker => faker.Date.Future());
            _fakerTicket.RuleFor(db => db.Status, faker => (TicketStatusDb) faker.Random.Int(0, 3));
            _fakerTicket.RuleFor(db => db.TypeEvent, faker => (TypeEventTicketDb) faker.Random.Int(0, 9));
            _fakerTicket.RuleFor(db => db.LocationEvent, f =>
            {
                var fakelocale = new Faker<AddressDb>();
                fakelocale.RuleFor(db => db.Country, faker => faker.Lorem.Word());
                fakelocale.RuleFor(db => db.City, faker => faker.Lorem.Word());
                fakelocale.RuleFor(db => db.Street, faker => faker.Lorem.Word());
                fakelocale.RuleFor(db => db.House, faker => faker.Random.Int(0, 100).ToString());
                fakelocale.RuleFor(db => db.Flat, faker => faker.Random.Int(0, 100).ToString());
                return fakelocale.Generate();
            });
            _fakerTicket.RuleFor(db => db.SellerAdress, f =>
            {
                var fakeaddress = new Faker<AddressDb>();
                fakeaddress.RuleFor(db => db.Country, faker => faker.Lorem.Word());
                fakeaddress.RuleFor(db => db.City, faker => faker.Lorem.Word());
                fakeaddress.RuleFor(db => db.Street, faker => faker.Lorem.Word());
                fakeaddress.RuleFor(db => db.House, faker => faker.Random.Int(0, 100).ToString());
                fakeaddress.RuleFor(db => db.Flat, faker => faker.Random.Int(0, 100).ToString());
                return fakeaddress.Generate();
            });
            _fakerTicket.RuleFor(db => db.User, f =>
            {
                var fakeaddress = new Faker<UserInfoDb>();
                fakeaddress.RuleFor(db => db.FirstName, faker => faker.Lorem.Word());
                fakeaddress.RuleFor(db => db.LastName, faker => faker.Lorem.Word());
                fakeaddress.RuleFor(db => db.Rating, faker => faker.Random.Int(-50, 50));
                return fakeaddress.Generate();
            });
            _fakerTicket.RuleFor(db => db.RespondedUsers, f =>
            {
                var fakeusercoll = new Faker<UserInfoDb>();
                fakeusercoll.RuleFor(db => db.FirstName, faker => faker.Lorem.Word());
                fakeusercoll.RuleFor(db => db.LastName, faker => faker.Lorem.Word());
                fakeusercoll.RuleFor(db => db.Rating, faker => faker.Random.Int(-50, 50));
                return fakeusercoll.Generate(f.Random.Int(0, 10));
            });
        }

        public static IEnumerable<TicketDb> Generate(int count = 10)
        {
            return _fakerTicket.Generate(count);
        }
    }
}