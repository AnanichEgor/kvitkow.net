using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace IdentityServer.SecurityClient.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class EditFeatureRequest {
    /// <summary>
    /// Gets or Sets FeatureId
    /// </summary>
    [DataMember(Name="featureId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "featureId")]
    public int? FeatureId { get; set; }

    /// <summary>
    /// Gets or Sets RightsIds
    /// </summary>
    [DataMember(Name="rightsIds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rightsIds")]
    public List<int?> RightsIds { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class EditFeatureRequest {\n");
      sb.Append("  FeatureId: ").Append(FeatureId).Append("\n");
      sb.Append("  RightsIds: ").Append(RightsIds).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public  new string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
