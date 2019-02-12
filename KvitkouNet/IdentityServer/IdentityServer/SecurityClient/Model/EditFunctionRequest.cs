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
  public class EditFunctionRequest {
    /// <summary>
    /// Gets or Sets FunctionId
    /// </summary>
    [DataMember(Name="functionId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "functionId")]
    public int? FunctionId { get; set; }

    /// <summary>
    /// Gets or Sets RightIds
    /// </summary>
    [DataMember(Name="rightIds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "rightIds")]
    public List<int?> RightIds { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class EditFunctionRequest {\n");
      sb.Append("  FunctionId: ").Append(FunctionId).Append("\n");
      sb.Append("  RightIds: ").Append(RightIds).Append("\n");
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
