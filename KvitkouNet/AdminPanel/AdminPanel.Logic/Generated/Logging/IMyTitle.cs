// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Swagger2
{
    using Models;
    using Newtonsoft.Json;

    /// <summary>
    /// </summary>
    public partial interface IMyTitle : System.IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }


        /// <summary>
        /// Gets the IAccountLog.
        /// </summary>
        IAccountLog AccountLog { get; }

        /// <summary>
        /// Gets the IErrorLog.
        /// </summary>
        IErrorLog ErrorLog { get; }

        /// <summary>
        /// Gets the IPaymentLog.
        /// </summary>
        IPaymentLog PaymentLog { get; }

        /// <summary>
        /// Gets the IQueryLog.
        /// </summary>
        IQueryLog QueryLog { get; }

        /// <summary>
        /// Gets the ITicketActionLog.
        /// </summary>
        ITicketActionLog TicketActionLog { get; }

        /// <summary>
        /// Gets the ITicketDealLog.
        /// </summary>
        ITicketDealLog TicketDealLog { get; }

    }
}
