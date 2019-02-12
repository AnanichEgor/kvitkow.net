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
  public class AddFunctionRequest {
    /// <summary>
    /// Gets or Sets FunctionName
    /// </summary>
    [DataMember(Name="functionName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "functionName")]
    public string FunctionName { get; set; }

    /// <summary>
    /// Gets or Sets FeatureId
    /// </summary>
    [DataMember(Name="featureId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "featureId")]
    public int? FeatureId { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddFunctionRequest {\n");
      sb.Append("  FunctionName: ").Append(FunctionName).Append("\n");
      sb.Append("  FeatureId: ").Append(FeatureId).Append("\n");
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
