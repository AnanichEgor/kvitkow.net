using System;
using System.Collections.Generic;
using IdentityServer.SecurityClient.Client;
using IdentityServer.SecurityClient.Model;
using RestSharp;

namespace IdentityServer.SecurityClient.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IRoleApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns>ActionResponse</returns>
        ActionResponse RoleAddRole (string roleName);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResponse</returns>
        ActionResponse RoleDeleteRole (int? id);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ActionResponse</returns>
        ActionResponse RoleEditRole (EditRoleRequest request);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="perPage"></param>
        /// <param name="page"></param>
        /// <param name="mask"></param>
        /// <returns>RoleResponse</returns>
        RoleResponse RoleGetRoles (int? perPage, int? page, string mask);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class RoleApi : IRoleApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public RoleApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RoleApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="roleName"></param> 
        /// <returns>ActionResponse</returns>            
        public ActionResponse RoleAddRole (string roleName)
        {
            
            // verify the required parameter 'roleName' is set
            if (roleName == null) throw new ApiException(400, "Missing required parameter 'roleName' when calling RoleAddRole");
            
    
            var path = "/api/security/role";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(roleName); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RoleAddRole: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RoleAddRole: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionResponse) ApiClient.Deserialize(response.Content, typeof(ActionResponse), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>ActionResponse</returns>            
        public ActionResponse RoleDeleteRole (int? id)
        {
            
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling RoleDeleteRole");
            
    
            var path = "/api/security/role/{id}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "id" + "}", ApiClient.ParameterToString(id));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RoleDeleteRole: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RoleDeleteRole: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionResponse) ApiClient.Deserialize(response.Content, typeof(ActionResponse), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="request"></param> 
        /// <returns>ActionResponse</returns>            
        public ActionResponse RoleEditRole (EditRoleRequest request)
        {
            
            // verify the required parameter 'request' is set
            if (request == null) throw new ApiException(400, "Missing required parameter 'request' when calling RoleEditRole");
            
    
            var path = "/api/security/role";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(request); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RoleEditRole: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RoleEditRole: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionResponse) ApiClient.Deserialize(response.Content, typeof(ActionResponse), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="perPage"></param> 
        /// <param name="page"></param> 
        /// <param name="mask"></param> 
        /// <returns>RoleResponse</returns>            
        public RoleResponse RoleGetRoles (int? perPage, int? page, string mask)
        {
            
            // verify the required parameter 'perPage' is set
            if (perPage == null) throw new ApiException(400, "Missing required parameter 'perPage' when calling RoleGetRoles");
            
            // verify the required parameter 'page' is set
            if (page == null) throw new ApiException(400, "Missing required parameter 'page' when calling RoleGetRoles");
            
    
            var path = "/api/security/roles/{per_page}/{page}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "per_page" + "}", ApiClient.ParameterToString(perPage));
path = path.Replace("{" + "page" + "}", ApiClient.ParameterToString(page));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (mask != null) queryParams.Add("mask", ApiClient.ParameterToString(mask)); // query parameter
                                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RoleGetRoles: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RoleGetRoles: " + response.ErrorMessage, response.ErrorMessage);
    
            return (RoleResponse) ApiClient.Deserialize(response.Content, typeof(RoleResponse), response.Headers);
        }
    
    }
}
