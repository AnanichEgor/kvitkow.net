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
    public interface IFunctionsApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ActionResponse</returns>
        ActionResponse FunctionsAddFunction (AddFunctionRequest request);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResponse</returns>
        ActionResponse FunctionsDeleteFunction (int? id);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ActionResponse</returns>
        ActionResponse FunctionsEditFunction (EditFunctionRequest request);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="perPage"></param>
        /// <param name="page"></param>
        /// <param name="mask"></param>
        /// <returns>AccessFunctionResponse</returns>
        AccessFunctionResponse FunctionsGetFunctions (int? perPage, int? page, string mask);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class FunctionsApi : IFunctionsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public FunctionsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FunctionsApi(String basePath)
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
        /// <param name="request"></param> 
        /// <returns>ActionResponse</returns>            
        public ActionResponse FunctionsAddFunction (AddFunctionRequest request)
        {
            
            // verify the required parameter 'request' is set
            if (request == null) throw new ApiException(400, "Missing required parameter 'request' when calling FunctionsAddFunction");
            
    
            var path = "/api/security/function";
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
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling FunctionsAddFunction: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling FunctionsAddFunction: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionResponse) ApiClient.Deserialize(response.Content, typeof(ActionResponse), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>ActionResponse</returns>            
        public ActionResponse FunctionsDeleteFunction (int? id)
        {
            
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling FunctionsDeleteFunction");
            
    
            var path = "/api/security/function/{id}";
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
                throw new ApiException ((int)response.StatusCode, "Error calling FunctionsDeleteFunction: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling FunctionsDeleteFunction: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionResponse) ApiClient.Deserialize(response.Content, typeof(ActionResponse), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="request"></param> 
        /// <returns>ActionResponse</returns>            
        public ActionResponse FunctionsEditFunction (EditFunctionRequest request)
        {
            
            // verify the required parameter 'request' is set
            if (request == null) throw new ApiException(400, "Missing required parameter 'request' when calling FunctionsEditFunction");
            
    
            var path = "/api/security/function";
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
                throw new ApiException ((int)response.StatusCode, "Error calling FunctionsEditFunction: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling FunctionsEditFunction: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionResponse) ApiClient.Deserialize(response.Content, typeof(ActionResponse), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="perPage"></param> 
        /// <param name="page"></param> 
        /// <param name="mask"></param> 
        /// <returns>AccessFunctionResponse</returns>            
        public AccessFunctionResponse FunctionsGetFunctions (int? perPage, int? page, string mask)
        {
            
            // verify the required parameter 'perPage' is set
            if (perPage == null) throw new ApiException(400, "Missing required parameter 'perPage' when calling FunctionsGetFunctions");
            
            // verify the required parameter 'page' is set
            if (page == null) throw new ApiException(400, "Missing required parameter 'page' when calling FunctionsGetFunctions");
            
    
            var path = "/api/security/functions{per_page}/{page}";
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
                throw new ApiException ((int)response.StatusCode, "Error calling FunctionsGetFunctions: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling FunctionsGetFunctions: " + response.ErrorMessage, response.ErrorMessage);
    
            return (AccessFunctionResponse) ApiClient.Deserialize(response.Content, typeof(AccessFunctionResponse), response.Headers);
        }
    
    }
}
