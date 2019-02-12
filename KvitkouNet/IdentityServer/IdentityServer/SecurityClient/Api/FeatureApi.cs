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
    public interface IFeatureApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="featureName"></param>
        /// <returns>ActionResponse</returns>
        ActionResponse FeatureAddFeature (string featureName);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResponse</returns>
        ActionResponse FeatureDeleteFeature (int? id);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ActionResponse</returns>
        ActionResponse FeatureEditFeature (EditFeatureRequest request);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="perPage"></param>
        /// <param name="page"></param>
        /// <param name="mask"></param>
        /// <returns>FeatureResponse</returns>
        FeatureResponse FeatureGetFeatures (int? perPage, int? page, string mask);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class FeatureApi : IFeatureApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public FeatureApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FeatureApi(String basePath)
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
        /// <param name="featureName"></param> 
        /// <returns>ActionResponse</returns>            
        public ActionResponse FeatureAddFeature (string featureName)
        {
            
            // verify the required parameter 'featureName' is set
            if (featureName == null) throw new ApiException(400, "Missing required parameter 'featureName' when calling FeatureAddFeature");
            
    
            var path = "/api/security/feature";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                                postBody = ApiClient.Serialize(featureName); // http body (model) parameter
    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling FeatureAddFeature: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling FeatureAddFeature: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionResponse) ApiClient.Deserialize(response.Content, typeof(ActionResponse), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param> 
        /// <returns>ActionResponse</returns>            
        public ActionResponse FeatureDeleteFeature (int? id)
        {
            
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling FeatureDeleteFeature");
            
    
            var path = "/api/security/feature/{id}";
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
                throw new ApiException ((int)response.StatusCode, "Error calling FeatureDeleteFeature: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling FeatureDeleteFeature: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionResponse) ApiClient.Deserialize(response.Content, typeof(ActionResponse), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="request"></param> 
        /// <returns>ActionResponse</returns>            
        public ActionResponse FeatureEditFeature (EditFeatureRequest request)
        {
            
            // verify the required parameter 'request' is set
            if (request == null) throw new ApiException(400, "Missing required parameter 'request' when calling FeatureEditFeature");
            
    
            var path = "/api/security/feature";
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
                throw new ApiException ((int)response.StatusCode, "Error calling FeatureEditFeature: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling FeatureEditFeature: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ActionResponse) ApiClient.Deserialize(response.Content, typeof(ActionResponse), response.Headers);
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="perPage"></param> 
        /// <param name="page"></param> 
        /// <param name="mask"></param> 
        /// <returns>FeatureResponse</returns>            
        public FeatureResponse FeatureGetFeatures (int? perPage, int? page, string mask)
        {
            
            // verify the required parameter 'perPage' is set
            if (perPage == null) throw new ApiException(400, "Missing required parameter 'perPage' when calling FeatureGetFeatures");
            
            // verify the required parameter 'page' is set
            if (page == null) throw new ApiException(400, "Missing required parameter 'page' when calling FeatureGetFeatures");
            
    
            var path = "/api/security/features/{per_page}/{page}";
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
                throw new ApiException ((int)response.StatusCode, "Error calling FeatureGetFeatures: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling FeatureGetFeatures: " + response.ErrorMessage, response.ErrorMessage);
    
            return (FeatureResponse) ApiClient.Deserialize(response.Content, typeof(FeatureResponse), response.Headers);
        }
    
    }
}
