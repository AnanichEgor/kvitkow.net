using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.Results;
using Security.Logic.Models.Enums;
using Security.Logic.Models.Responses;

namespace Security.Logic.Helpers
{
    static class ValidationResponseHelper
    {
        public static ActionResponse GetResponse(ValidationResult validationResult)
        {
            return new ActionResponse
            {
                Message = string.Join(Environment.NewLine, validationResult.Errors),
                Status = ActionStatus.Warning
            };
        }

        internal static ActionResponse GetResponse(IEnumerable<ValidationResult> validationFaults)
        {
            return new ActionResponse
            {
                Message = string.Join(Environment.NewLine, validationFaults.SelectMany(l=>l.Errors)),
                Status = ActionStatus.Warning
            };
        }
    }
}
