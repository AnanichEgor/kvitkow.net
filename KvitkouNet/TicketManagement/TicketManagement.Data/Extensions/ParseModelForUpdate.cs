using TicketManagement.Data.DbModels;

namespace TicketManagement.Data.Extensions
{
    /// <summary>
    ///     Класс для обновления модели
    /// </summary>
    public static class ParseModelForUpdate
    {
        /// <summary>
        ///     Метод расширения обновляющий модель из базы
        /// </summary>
        /// <param name="original">Модель из базы</param>
        /// <param name="ticket">Модель из реквеста</param>
        /// <returns></returns>
        public static Ticket UpdateModel(this Ticket original, Ticket ticket, string id)
        {
            original.Id = id;
            if (ticket.Name != null) original.Name = ticket.Name;
            if (ticket.LocationEvent != null) original.LocationEvent = ticket.LocationEvent;
            if (ticket.AdditionalData != null) original.AdditionalData = ticket.AdditionalData;
            original.CreatedDate = ticket.CreatedDate;
            if (ticket.EventLink != null) original.EventLink = ticket.EventLink;
            original.Free = ticket.Free;
            if (ticket.Id != null) original.Id = ticket.Id;
            if (ticket.PaymentSystems != null) original.PaymentSystems = ticket.PaymentSystems;
            if (ticket.Price != null) original.Price = ticket.Price;
            if (ticket.SellerAdress != null) original.SellerAdress = ticket.SellerAdress;
            if (ticket.SellerPhone != null) original.SellerPhone = ticket.SellerPhone;
            original.Status = ticket.Status;
            original.TimeActual = ticket.TimeActual;
            original.TypeEvent = ticket.TypeEvent;
            if (ticket.User != null) original.User = ticket.User;
            original.RespondedUsers = ticket.RespondedUsers.GetRange(0,ticket.RespondedUsers.Count);
            return original;
        }
    }
}