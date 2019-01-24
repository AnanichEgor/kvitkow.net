using PhoneNumbers;
using TicketManagement.Logic.Models;

namespace TicketManagement.Logic.Extentions
{
    /// <summary>
    ///     Класс валидации номеров
    /// </summary>
    public static class PhoneValidatorExtention
    {
        /// <summary>
        ///     Метод валидации номеров
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns></returns>
        public static bool PhoneValidate(this Ticket ticket)
        {
            var number = ticket.SellerPhone.Replace('-',
                    ' ')
                .Replace('(',
                    ' ')
                .Replace(')',
                    ' ')
                .Replace('+',
                    ' ');
            var isNumber = double.TryParse(number, out var tResult);
            if (!isNumber) return false;
            var phoneUtil = PhoneNumberUtil.GetInstance();
            var parse = phoneUtil.Parse(ticket.SellerPhone, null);
            return phoneUtil.IsValidNumber(parse);
        }
    }
}