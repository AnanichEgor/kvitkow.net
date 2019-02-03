// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Swagger3.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class AccountLogEntry : BaseLogEntry
    {
        /// <summary>
        /// Initializes a new instance of the AccountLogEntry class.
        /// </summary>
        public AccountLogEntry()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AccountLogEntry class.
        /// </summary>
        public AccountLogEntry(System.DateTime eventDate, int type, string id = default(string), string userId = default(string), string userName = default(string), string email = default(string))
            : base(eventDate, id)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }

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
