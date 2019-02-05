/*
 * Code generated by Microsoft (R) AutoRest Code Generator.
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

import * as msRest from "@azure/ms-rest-js";
import * as Models from "../../../models/security";
import * as Mappers from "../../../models/security/userRightsOperationsMappers";
import * as Parameters from "../../../models/security/parameters";
import { SecurityContext } from "../securityContext";

/** Class representing a UserRightsOperations. */
export class UserRightsOperations {
  private readonly client: SecurityContext;

  /**
   * Create a UserRightsOperations.
   * @param {SecurityContext} client Reference to the service client.
   */
  constructor(client: SecurityContext) {
    this.client = client;
  }

  /**
   * @param id
   * @param [options] The optional parameters
   * @returns Promise<Models.UserRightsGetUserRightsResponse>
   */
  getUserRights(id: string, options?: msRest.RequestOptionsBase): Promise<Models.UserRightsGetUserRightsResponse>;
  /**
   * @param id
   * @param callback The callback
   */
  getUserRights(id: string, callback: msRest.ServiceCallback<Models.UserRights>): void;
  /**
   * @param id
   * @param options The optional parameters
   * @param callback The callback
   */
  getUserRights(id: string, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<Models.UserRights>): void;
  getUserRights(id: string, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<Models.UserRights>, callback?: msRest.ServiceCallback<Models.UserRights>): Promise<Models.UserRightsGetUserRightsResponse> {
    return this.client.sendOperationRequest(
      {
        id,
        options
      },
      getUserRightsOperationSpec,
      callback) as Promise<Models.UserRightsGetUserRightsResponse>;
  }

  /**
   * @param request
   * @param [options] The optional parameters
   * @returns Promise<Models.UserRightsEditUserRightsResponse>
   */
  editUserRights(request: Models.EditUserRightsRequest, options?: msRest.RequestOptionsBase): Promise<Models.UserRightsEditUserRightsResponse>;
  /**
   * @param request
   * @param callback The callback
   */
  editUserRights(request: Models.EditUserRightsRequest, callback: msRest.ServiceCallback<boolean>): void;
  /**
   * @param request
   * @param options The optional parameters
   * @param callback The callback
   */
  editUserRights(request: Models.EditUserRightsRequest, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<boolean>): void;
  editUserRights(request: Models.EditUserRightsRequest, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<boolean>, callback?: msRest.ServiceCallback<boolean>): Promise<Models.UserRightsEditUserRightsResponse> {
    return this.client.sendOperationRequest(
      {
        request,
        options
      },
      editUserRightsOperationSpec,
      callback) as Promise<Models.UserRightsEditUserRightsResponse>;
  }

  /**
   * @param accessRequest
   * @param [options] The optional parameters
   * @returns Promise<Models.UserRightsCheckUserRightsResponse>
   */
  checkUserRights(accessRequest: Models.CheckAccessRequest, options?: msRest.RequestOptionsBase): Promise<Models.UserRightsCheckUserRightsResponse>;
  /**
   * @param accessRequest
   * @param callback The callback
   */
  checkUserRights(accessRequest: Models.CheckAccessRequest, callback: msRest.ServiceCallback<boolean>): void;
  /**
   * @param accessRequest
   * @param options The optional parameters
   * @param callback The callback
   */
  checkUserRights(accessRequest: Models.CheckAccessRequest, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<boolean>): void;
  checkUserRights(accessRequest: Models.CheckAccessRequest, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<boolean>, callback?: msRest.ServiceCallback<boolean>): Promise<Models.UserRightsCheckUserRightsResponse> {
    return this.client.sendOperationRequest(
      {
        accessRequest,
        options
      },
      checkUserRightsOperationSpec,
      callback) as Promise<Models.UserRightsCheckUserRightsResponse>;
  }
}

// Operation Specifications
const serializer = new msRest.Serializer(Mappers);
const getUserRightsOperationSpec: msRest.OperationSpec = {
  httpMethod: "GET",
  path: "api/security/rights/user/{id}",
  urlParameters: [
    Parameters.id1
  ],
  responses: {
    200: {
      bodyMapper: Mappers.UserRights
    },
    204: {},
    401: {},
    403: {},
    default: {}
  },
  serializer
};

const editUserRightsOperationSpec: msRest.OperationSpec = {
  httpMethod: "PUT",
  path: "api/security/rights/user",
  requestBody: {
    parameterPath: "request",
    mapper: {
      ...Mappers.EditUserRightsRequest,
      required: true
    }
  },
  contentType: "application/json-patch+json; charset=utf-8",
  responses: {
    200: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "Boolean"
        }
      }
    },
    401: {},
    403: {},
    default: {}
  },
  serializer
};

const checkUserRightsOperationSpec: msRest.OperationSpec = {
  httpMethod: "PUT",
  path: "api/security/rights/check",
  requestBody: {
    parameterPath: "accessRequest",
    mapper: {
      ...Mappers.CheckAccessRequest,
      required: true
    }
  },
  contentType: "application/json-patch+json; charset=utf-8",
  responses: {
    200: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "Boolean"
        }
      }
    },
    401: {},
    403: {},
    default: {}
  },
  serializer
};
