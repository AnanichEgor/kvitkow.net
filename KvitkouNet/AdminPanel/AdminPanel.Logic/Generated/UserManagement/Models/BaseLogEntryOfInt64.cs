// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Swagger.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class BaseLogEntryOfInt64
    {
        /// <summary>
        /// Initializes a new instance of the BaseLogEntryOfInt64 class.
        /// </summary>
        public BaseLogEntryOfInt64()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BaseLogEntryOfInt64 class.
        /// </summary>
        public BaseLogEntryOfInt64(long id, System.DateTime created, string content = default(string))
        {
            Id = id;
            Content = content;
            Created = created;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public System.DateTime Created { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
