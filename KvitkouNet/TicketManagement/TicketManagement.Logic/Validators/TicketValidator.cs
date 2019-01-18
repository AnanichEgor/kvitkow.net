using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TicketManagement.Logic.Models;

namespace TicketManagement.Logic.Validators
{
    public class TicketValidator: AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(ticket => ticket.Name).NotEmpty().Length(5, 100);
            RuleFor(ticket => ticket.AdditionalData).MaximumLength(240);
            RuleFor(ticket => ticket.SellerPhone).NotEmpty().Length(6,9);
            RuleFor(ticket => ticket.User.FirstName).NotEmpty().Length(3,12);
            RuleFor(ticket => ticket.User.LastName).NotEmpty().Length(3,15);
            RuleFor(ticket => ticket.LocationEvent.City).NotEmpty().Length(3,15);
            RuleFor(ticket => ticket.LocationEvent.Country).NotEmpty().Length(3,15);
            RuleFor(ticket => ticket.LocationEvent.Street).NotEmpty().Length(3,15);
            RuleFor(ticket => ticket.LocationEvent.House).NotEmpty().Length(1,6);
            RuleFor(ticket => ticket.SellerAdress.City).NotEmpty().Length(3, 15);
            RuleFor(ticket => ticket.SellerAdress.Country).NotEmpty().Length(3, 15);
            RuleFor(ticket => ticket.SellerAdress.Street).NotEmpty().Length(3, 15);
            RuleFor(ticket => ticket.SellerAdress.House).NotEmpty().Length(1, 6);

        }
    }
}
