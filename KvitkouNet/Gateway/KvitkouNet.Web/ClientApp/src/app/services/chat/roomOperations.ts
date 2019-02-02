/*
 * Code generated by Microsoft (R) AutoRest Code Generator.
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

import * as msRest from "@azure/ms-rest-js";
import * as Models from '../../models/chat';
import * as Mappers from '../../models/chat/roomOperationsMappers';
import * as Parameters from '../../models/chat/parameters';
import { ChatContext } from '../chatContext';

/** Class representing a RoomOperations. */
export class RoomOperations {
  private readonly client: ChatContext;

  /**
   * Create a RoomOperations.
   * @param {ChatContext} client Reference to the service client.
   */
  constructor(client: ChatContext) {
    this.client = client;
  }

  /**
   * @param uid
   * @param [options] The optional parameters
   * @returns Promise<Models.RoomGetRoomsResponse>
   */
  getRooms(uid: string, options?: msRest.RequestOptionsBase): Promise<Models.RoomGetRoomsResponse>;
  /**
   * @param uid
   * @param callback The callback
   */
  getRooms(uid: string, callback: msRest.ServiceCallback<any>): void;
  /**
   * @param uid
   * @param options The optional parameters
   * @param callback The callback
   */
  getRooms(uid: string, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<any>): void;
  getRooms(uid: string, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<any>, callback?: msRest.ServiceCallback<any>): Promise<Models.RoomGetRoomsResponse> {
    return this.client.sendOperationRequest(
      {
        uid,
        options
      },
      getRoomsOperationSpec,
      callback) as Promise<Models.RoomGetRoomsResponse>;
  }

  /**
   * @param room
   * @param uid
   * @param [options] The optional parameters
   * @returns Promise<Models.RoomAddRoomResponse>
   */
  addRoom(room: Models.Room, uid: string, options?: msRest.RequestOptionsBase): Promise<Models.RoomAddRoomResponse>;
  /**
   * @param room
   * @param uid
   * @param callback The callback
   */
  addRoom(room: Models.Room, uid: string, callback: msRest.ServiceCallback<string>): void;
  /**
   * @param room
   * @param uid
   * @param options The optional parameters
   * @param callback The callback
   */
  addRoom(room: Models.Room, uid: string, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<string>): void;
  addRoom(room: Models.Room, uid: string, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<string>, callback?: msRest.ServiceCallback<string>): Promise<Models.RoomAddRoomResponse> {
    return this.client.sendOperationRequest(
      {
        room,
        uid,
        options
      },
      addRoomOperationSpec,
      callback) as Promise<Models.RoomAddRoomResponse>;
  }

  /**
   * @param template
   * @param [options] The optional parameters
   * @returns Promise<Models.RoomSearchRoomResponse>
   */
  searchRoom(template: string, options?: msRest.RequestOptionsBase): Promise<Models.RoomSearchRoomResponse>;
  /**
   * @param template
   * @param callback The callback
   */
  searchRoom(template: string, callback: msRest.ServiceCallback<any>): void;
  /**
   * @param template
   * @param options The optional parameters
   * @param callback The callback
   */
  searchRoom(template: string, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<any>): void;
  searchRoom(template: string, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<any>, callback?: msRest.ServiceCallback<any>): Promise<Models.RoomSearchRoomResponse> {
    return this.client.sendOperationRequest(
      {
        template,
        options
      },
      searchRoomOperationSpec,
      callback) as Promise<Models.RoomSearchRoomResponse>;
  }

  /**
   * @param rid
   * @param historyCountsMessages
   * @param [options] The optional parameters
   * @returns Promise<Models.RoomGetMessagesResponse>
   */
  getMessages(rid: string, historyCountsMessages: number, options?: msRest.RequestOptionsBase): Promise<Models.RoomGetMessagesResponse>;
  /**
   * @param rid
   * @param historyCountsMessages
   * @param callback The callback
   */
  getMessages(rid: string, historyCountsMessages: number, callback: msRest.ServiceCallback<any>): void;
  /**
   * @param rid
   * @param historyCountsMessages
   * @param options The optional parameters
   * @param callback The callback
   */
  getMessages(rid: string, historyCountsMessages: number, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<any>): void;
  getMessages(rid: string, historyCountsMessages: number, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<any>, callback?: msRest.ServiceCallback<any>): Promise<Models.RoomGetMessagesResponse> {
    return this.client.sendOperationRequest(
      {
        rid,
        historyCountsMessages,
        options
      },
      getMessagesOperationSpec,
      callback) as Promise<Models.RoomGetMessagesResponse>;
  }

  /**
   * @param rid
   * @param template
   * @param [options] The optional parameters
   * @returns Promise<Models.RoomSearchMessageResponse>
   */
  searchMessage(rid: string, template: string, options?: msRest.RequestOptionsBase): Promise<Models.RoomSearchMessageResponse>;
  /**
   * @param rid
   * @param template
   * @param callback The callback
   */
  searchMessage(rid: string, template: string, callback: msRest.ServiceCallback<any>): void;
  /**
   * @param rid
   * @param template
   * @param options The optional parameters
   * @param callback The callback
   */
  searchMessage(rid: string, template: string, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<any>): void;
  searchMessage(rid: string, template: string, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<any>, callback?: msRest.ServiceCallback<any>): Promise<Models.RoomSearchMessageResponse> {
    return this.client.sendOperationRequest(
      {
        rid,
        template,
        options
      },
      searchMessageOperationSpec,
      callback) as Promise<Models.RoomSearchMessageResponse>;
  }

  /**
   * @param message
   * @param rid
   * @param [options] The optional parameters
   * @returns Promise<Models.RoomAddMessageResponse>
   */
  addMessage(message: Models.Message, rid: string, options?: msRest.RequestOptionsBase): Promise<Models.RoomAddMessageResponse>;
  /**
   * @param message
   * @param rid
   * @param callback The callback
   */
  addMessage(message: Models.Message, rid: string, callback: msRest.ServiceCallback<string>): void;
  /**
   * @param message
   * @param rid
   * @param options The optional parameters
   * @param callback The callback
   */
  addMessage(message: Models.Message, rid: string, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<string>): void;
  addMessage(message: Models.Message, rid: string, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<string>, callback?: msRest.ServiceCallback<string>): Promise<Models.RoomAddMessageResponse> {
    return this.client.sendOperationRequest(
      {
        message,
        rid,
        options
      },
      addMessageOperationSpec,
      callback) as Promise<Models.RoomAddMessageResponse>;
  }

  /**
   * @param message
   * @param rid
   * @param [options] The optional parameters
   * @returns Promise<Models.RoomEditMessageResponse>
   */
  editMessage(message: Models.Message, rid: string, options?: msRest.RequestOptionsBase): Promise<Models.RoomEditMessageResponse>;
  /**
   * @param message
   * @param rid
   * @param callback The callback
   */
  editMessage(message: Models.Message, rid: string, callback: msRest.ServiceCallback<string>): void;
  /**
   * @param message
   * @param rid
   * @param options The optional parameters
   * @param callback The callback
   */
  editMessage(message: Models.Message, rid: string, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<string>): void;
  editMessage(message: Models.Message, rid: string, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<string>, callback?: msRest.ServiceCallback<string>): Promise<Models.RoomEditMessageResponse> {
    return this.client.sendOperationRequest(
      {
        message,
        rid,
        options
      },
      editMessageOperationSpec,
      callback) as Promise<Models.RoomEditMessageResponse>;
  }

  /**
   * @param rid
   * @param mid
   * @param [options] The optional parameters
   * @returns Promise<Models.RoomDeleteMessageResponse>
   */
  deleteMessage(rid: string, mid: string, options?: msRest.RequestOptionsBase): Promise<Models.RoomDeleteMessageResponse>;
  /**
   * @param rid
   * @param mid
   * @param callback The callback
   */
  deleteMessage(rid: string, mid: string, callback: msRest.ServiceCallback<string>): void;
  /**
   * @param rid
   * @param mid
   * @param options The optional parameters
   * @param callback The callback
   */
  deleteMessage(rid: string, mid: string, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<string>): void;
  deleteMessage(rid: string, mid: string, options?: msRest.RequestOptionsBase | msRest.ServiceCallback<string>, callback?: msRest.ServiceCallback<string>): Promise<Models.RoomDeleteMessageResponse> {
    return this.client.sendOperationRequest(
      {
        rid,
        mid,
        options
      },
      deleteMessageOperationSpec,
      callback) as Promise<Models.RoomDeleteMessageResponse>;
  }
}

// Operation Specifications
const serializer = new msRest.Serializer(Mappers);
const getRoomsOperationSpec: msRest.OperationSpec = {
  httpMethod: "GET",
  path: "api/chat/rooms/users/{uid}",
  urlParameters: [
    Parameters.uid
  ],
  responses: {
    200: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "Composite",
              className: "Room"
            }
          }
        }
      }
    },
    400: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "String"
        }
      }
    },
    default: {}
  },
  serializer
};

const addRoomOperationSpec: msRest.OperationSpec = {
  httpMethod: "POST",
  path: "api/chat/rooms/room/{uid}",
  urlParameters: [
    Parameters.uid
  ],
  requestBody: {
    parameterPath: "room",
    mapper: {
      ...Mappers.Room,
      required: true
    }
  },
  contentType: "application/json-patch+json; charset=utf-8",
  responses: {
    204: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "String"
        }
      }
    },
    400: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "String"
        }
      }
    },
    default: {}
  },
  serializer
};

const searchRoomOperationSpec: msRest.OperationSpec = {
  httpMethod: "GET",
  path: "api/chat/rooms/{template}",
  urlParameters: [
    Parameters.template
  ],
  responses: {
    200: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "Composite",
              className: "Room"
            }
          }
        }
      }
    },
    400: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "String"
        }
      }
    },
    default: {}
  },
  serializer
};

const getMessagesOperationSpec: msRest.OperationSpec = {
  httpMethod: "GET",
  path: "api/chat/rooms/{rid}/messages/history/{historyCountsMessages}",
  urlParameters: [
    Parameters.rid,
    Parameters.historyCountsMessages
  ],
  responses: {
    200: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "Composite",
              className: "Message"
            }
          }
        }
      }
    },
    400: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "String"
        }
      }
    },
    default: {}
  },
  serializer
};

const searchMessageOperationSpec: msRest.OperationSpec = {
  httpMethod: "GET",
  path: "api/chat/rooms/{rid}/messages/{template}",
  urlParameters: [
    Parameters.rid,
    Parameters.template
  ],
  responses: {
    200: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "Sequence",
          element: {
            type: {
              name: "Composite",
              className: "Message"
            }
          }
        }
      }
    },
    400: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "String"
        }
      }
    },
    default: {}
  },
  serializer
};

const addMessageOperationSpec: msRest.OperationSpec = {
  httpMethod: "POST",
  path: "api/chat/rooms/{rid}/message",
  urlParameters: [
    Parameters.rid
  ],
  requestBody: {
    parameterPath: "message",
    mapper: {
      ...Mappers.Message,
      required: true
    }
  },
  contentType: "application/json-patch+json; charset=utf-8",
  responses: {
    204: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "String"
        }
      }
    },
    400: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "String"
        }
      }
    },
    default: {}
  },
  serializer
};

const editMessageOperationSpec: msRest.OperationSpec = {
  httpMethod: "PATCH",
  path: "api/chat/rooms/{rid}/message",
  urlParameters: [
    Parameters.rid
  ],
  requestBody: {
    parameterPath: "message",
    mapper: {
      ...Mappers.Message,
      required: true
    }
  },
  contentType: "application/json-patch+json; charset=utf-8",
  responses: {
    204: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "String"
        }
      }
    },
    400: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "String"
        }
      }
    },
    default: {}
  },
  serializer
};

const deleteMessageOperationSpec: msRest.OperationSpec = {
  httpMethod: "DELETE",
  path: "api/chat/rooms/{rid}/messages/{mid}",
  urlParameters: [
    Parameters.rid,
    Parameters.mid
  ],
  responses: {
    204: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "String"
        }
      }
    },
    400: {
      bodyMapper: {
        serializedName: "parsedResponse",
        type: {
          name: "String"
        }
      }
    },
    default: {}
  },
  serializer
};
