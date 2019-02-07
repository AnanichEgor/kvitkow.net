/**
 * My Title
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 *
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
/* tslint:disable:no-unused-variable member-ordering */

import { Inject, Injectable, Optional } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,
         HttpResponse, HttpEvent } from '@angular/common/http';
import { CustomHttpUrlEncodingCodec } from './encoder';

import { Observable } from 'rxjs';

import { AccessFunctionResponse } from '../../models/security/accessFunctionResponse';
import { ActionResponse } from '../../models/security/actionResponse';
import { AddFunctionRequest } from '../../models/security/addFunctionRequest';
import { EditFunctionRequest } from '../../models/security/editFunctionRequest';

import { BASE_PATH, COLLECTION_FORMATS } from './variables';
import { Configuration } from './configuration';


@Injectable()
export class FunctionsService {

    protected basePath = 'http://localhost:5000';
    public defaultHeaders = new HttpHeaders();
    public configuration = new Configuration();

    constructor(protected httpClient: HttpClient, @Optional()@Inject(BASE_PATH) basePath: string, @Optional() configuration: Configuration) {
        if (basePath) {
            this.basePath = basePath;
        }
        if (configuration) {
            this.configuration = configuration;
            this.basePath = basePath || configuration.basePath || this.basePath;
        }
    }

    /**
     * @param consumes string[] mime-types
     * @return true: consumes contains 'multipart/form-data', false: otherwise
     */
    private canConsumeForm(consumes: string[]): boolean {
        const form = 'multipart/form-data';
        for (const consume of consumes) {
            if (form === consume) {
                return true;
            }
        }
        return false;
    }


    /**
     *
     *
     * @param request
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public functionsAddFunction(request: AddFunctionRequest, observe?: 'body', reportProgress?: boolean): Observable<ActionResponse>;
    public functionsAddFunction(request: AddFunctionRequest, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ActionResponse>>;
    public functionsAddFunction(request: AddFunctionRequest, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ActionResponse>>;
    public functionsAddFunction(request: AddFunctionRequest, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (request === null || request === undefined) {
            throw new Error('Required parameter request was null or undefined when calling functionsAddFunction.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json-patch+json',
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set('Content-Type', httpContentTypeSelected);
        }

        return this.httpClient.post<ActionResponse>(`${this.basePath}/api/security/function`,
            request,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     *
     *
     * @param id
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public functionsDeleteFunction(id: number, observe?: 'body', reportProgress?: boolean): Observable<ActionResponse>;
    public functionsDeleteFunction(id: number, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ActionResponse>>;
    public functionsDeleteFunction(id: number, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ActionResponse>>;
    public functionsDeleteFunction(id: number, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (id === null || id === undefined) {
            throw new Error('Required parameter id was null or undefined when calling functionsDeleteFunction.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json-patch+json',
            'application/json',
            'text/json',
            'application/_*+json'
        ];

        return this.httpClient.delete<ActionResponse>(`${this.basePath}/api/security/function/${encodeURIComponent(String(id))}`,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     *
     *
     * @param request
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public functionsEditFunction(request: EditFunctionRequest, observe?: 'body', reportProgress?: boolean): Observable<ActionResponse>;
    public functionsEditFunction(request: EditFunctionRequest, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<ActionResponse>>;
    public functionsEditFunction(request: EditFunctionRequest, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<ActionResponse>>;
    public functionsEditFunction(request: EditFunctionRequest, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (request === null || request === undefined) {
            throw new Error('Required parameter request was null or undefined when calling functionsEditFunction.');
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json-patch+json',
            'application/json',
            'text/json',
            'application/_*+json'
        ];
        const httpContentTypeSelected: string | undefined = this.configuration.selectHeaderContentType(consumes);
        if (httpContentTypeSelected != undefined) {
            headers = headers.set('Content-Type', httpContentTypeSelected);
        }

        return this.httpClient.put<ActionResponse>(`${this.basePath}/api/security/function`,
            request,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

    /**
     *
     *
     * @param perPage
     * @param page
     * @param mask
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public functionsGetFunctions(perPage: number, page: number, mask?: string, observe?: 'body', reportProgress?: boolean): Observable<AccessFunctionResponse>;
    public functionsGetFunctions(perPage: number, page: number, mask?: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<AccessFunctionResponse>>;
    public functionsGetFunctions(perPage: number, page: number, mask?: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<AccessFunctionResponse>>;
    public functionsGetFunctions(perPage: number, page: number, mask?: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (perPage === null || perPage === undefined) {
            throw new Error('Required parameter perPage was null or undefined when calling functionsGetFunctions.');
        }

        if (page === null || page === undefined) {
            throw new Error('Required parameter page was null or undefined when calling functionsGetFunctions.');
        }


        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (mask !== undefined && mask !== null) {
            queryParameters = queryParameters.set('mask', <any>mask);
        }

        let headers = this.defaultHeaders;

        // to determine the Accept header
        let httpHeaderAccepts: string[] = [
        ];
        const httpHeaderAcceptSelected: string | undefined = this.configuration.selectHeaderAccept(httpHeaderAccepts);
        if (httpHeaderAcceptSelected != undefined) {
            headers = headers.set('Accept', httpHeaderAcceptSelected);
        }

        // to determine the Content-Type header
        const consumes: string[] = [
            'application/json-patch+json',
            'application/json',
            'text/json',
            'application/_*+json'
        ];

        return this.httpClient.get<AccessFunctionResponse>(`${this.basePath}/api/security/functions${encodeURIComponent(String(perPage))}/${encodeURIComponent(String(page))}`,
            {
                params: queryParameters,
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

}
