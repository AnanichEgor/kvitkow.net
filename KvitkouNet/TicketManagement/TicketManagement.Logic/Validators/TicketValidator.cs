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

        }
    }
}
