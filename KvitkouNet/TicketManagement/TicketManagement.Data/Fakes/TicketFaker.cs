using System.Collections.Generic;
using Bogus;
using TicketManagement.Data.DbModels;

namespace TicketManagement.Data.Fakes
{
    public static class TicketFaker
    {
        private static readonly Faker<TicketDb> _fakerTicket;

        static TicketFaker()
        {
            _fakerTicket = new Faker<TicketDb>();
            _fakerTicket.RuleFor(db => db.Name, faker => faker.Lorem.Sentence(10));
            _fakerTicket.RuleFor(db => db.Price, faker => faker.Random.Decimal(1, 100));
            _fakerTicket.RuleFor(db => db.AdditionalData, faker => faker.Lorem.Paragraph(10));
            _fakerTicket.RuleFor(db => db.SellerPhone, faker => faker.Phone.ToString());
        }

        public static IEnumerable<TicketDb> Generate(int count = 10)
        {
            return _fakerTicket.Generate(count);
        }
    }
}