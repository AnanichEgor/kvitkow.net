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
            RuleFor(ticket => ticket.AdditionalData).NotEmpty();
            RuleFor(ticket => ticket.SellerPhone).NotEmpty();
            RuleFor(ticket => ticket.User.FirstName).NotEmpty();
            RuleFor(ticket => ticket.User.LastName).NotEmpty();
            RuleFor(ticket => ticket.LocationEvent.City).NotEmpty();
            RuleFor(ticket => ticket.LocationEvent.Country).NotEmpty();
            RuleFor(ticket => ticket.LocationEvent.Street).NotEmpty();
            RuleFor(ticket => ticket.LocationEvent.House).NotEmpty();
            RuleFor(ticket => ticket.SellerAdress.City).NotEmpty();
            RuleFor(ticket => ticket.SellerAdress.Country).NotEmpty();
            RuleFor(ticket => ticket.SellerAdress.Street).NotEmpty();
            RuleFor(ticket => ticket.SellerAdress.House).NotEmpty();

        }
    }
}
