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
  public class EditRoleRequest {
    /// <summary>
    /// Gets or Sets RoleId
    /// </summary>
    [DataMember(Name="roleId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "roleId")]
    public int? RoleId { get; set; }

    /// <summary>
    /// Gets or Sets FunctionIds
    /// </summary>
    [DataMember(Name="functionIds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "functionIds")]
    public List<int?> FunctionIds { get; set; }

    /// <summary>
    /// Gets or Sets AccessRightsIds
    /// </summary>
    [DataMember(Name="accessRightsIds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "accessRightsIds")]
    public List<int?> AccessRightsIds { get; set; }

    /// <summary>
    /// Gets or Sets DeniedRightsIds
    /// </summary>
    [DataMember(Name="deniedRightsIds", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "deniedRightsIds")]
    public List<int?> DeniedRightsIds { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class EditRoleRequest {\n");
      sb.Append("  RoleId: ").Append(RoleId).Append("\n");
      sb.Append("  FunctionIds: ").Append(FunctionIds).Append("\n");
      sb.Append("  AccessRightsIds: ").Append(AccessRightsIds).Append("\n");
      sb.Append("  DeniedRightsIds: ").Append(DeniedRightsIds).Append("\n");
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
