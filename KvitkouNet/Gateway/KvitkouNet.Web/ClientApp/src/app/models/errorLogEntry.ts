export class ErrorLogEntry{
    id : string;
    eventDate: Date;
    serviceName : string;
    exceptionType : string;
    hResult : number;
    innerExceptionString : string;
    message : string;
    source : string;
    stackTrace : string;
    targetSiteName : string;
}