// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace AdminPanel.Logic.Generated.Logging.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class PaymentLogEntry : BaseLogEntryOfInt64
    {
        /// <summary>
        /// Initializes a new instance of the PaymentLogEntry class.
        /// </summary>
        public PaymentLogEntry()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PaymentLogEntry class.
        /// </summary>
        public PaymentLogEntry(long id, System.DateTime created, string content = default(string), object paymentTransaction = default(object))
            : base(id, created, content)
        {
            PaymentTransaction = paymentTransaction;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "paymentTransaction")]
        public object PaymentTransaction { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
