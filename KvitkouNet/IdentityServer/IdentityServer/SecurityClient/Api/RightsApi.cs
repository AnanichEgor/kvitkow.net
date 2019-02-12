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
    public interface IRightsApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="rightNames"></param>
        /// <returns>AccessRightResponse</returns>
        AccessRightResponse RightsAddRights (List<string> rightNames);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResponse</returns>
        ActionResponse RightsDeleteRight (int? id);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="perPage"></param>
        /// <param name="page"></param>
        /// <param name="mask"></param>
        /// <returns>AccessRightResponse</returns>
        AccessRightResponse RightsGetRights (int? perPage, int? page, string mask);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class RightsApi : IRightsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RightsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public RightsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="RightsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public RightsApi(String basePath)
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
        /// <param name="rightNames"></param> 
        /// <returns>AccessRightResponse</returns>            
        public AccessRightResponse RightsAddRights (List<string> rightNames)
        {
            
            // verify the required parameter 'rightNames' is set
            if (rightNames == null) throw new ApiException(400, "Missing required parameter 'rightNames' when calling RightsAddRights");
            
    
            var path = "/api/security/rights";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(rightNames); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling RightsAddRights: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RightsAddRights: " + response.ErrorMessage, response.ErrorMessage);
    
            return (AccessRightResponse) ApiClient.Deserialize(response.Content, typeof(AccessRightResponse), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>ActionResponse</returns>            
        public ActionResponse RightsDeleteRight (int? id)
        {
            
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling RightsDeleteRight");
            
    
            var path = "/api/security/right/{id}";
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
                throw new ApiException ((int)response.StatusCode, "Error calling RightsDeleteRight: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RightsDeleteRight: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionResponse) ApiClient.Deserialize(response.Content, typeof(ActionResponse), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="perPage"></param> 
        /// <param name="page"></param> 
        /// <param name="mask"></param> 
        /// <returns>AccessRightResponse</returns>            
        public AccessRightResponse RightsGetRights (int? perPage, int? page, string mask)
        {
            
            // verify the required parameter 'perPage' is set
            if (perPage == null) throw new ApiException(400, "Missing required parameter 'perPage' when calling RightsGetRights");
            
            // verify the required parameter 'page' is set
            if (page == null) throw new ApiException(400, "Missing required parameter 'page' when calling RightsGetRights");
            
    
            var path = "/api/security/rights/{per_page}/{page}";
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
                throw new ApiException ((int)response.StatusCode, "Error calling RightsGetRights: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling RightsGetRights: " + response.ErrorMessage, response.ErrorMessage);
    
            return (AccessRightResponse) ApiClient.Deserialize(response.Content, typeof(AccessRightResponse), response.Headers);
        }
    
    }
}
