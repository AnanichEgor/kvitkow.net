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

import { Inject, Injectable, Optional }                      from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams,
         HttpResponse, HttpEvent }                           from '@angular/common/http';
import { CustomHttpUrlEncodingCodec }                        from './encoder';

import { Observable } from 'rxjs';

import { Subscription } from '../../models/notification/subscription';

import { BASE_NOTIFICATION_PATH, COLLECTION_FORMATS, NotificationInjector }                     from './variables';
import { Configuration }                                     from './configuration';


@Injectable()
export class SubscriptionService {

    protected basePath: string = 'http://localhost:5002';
    public defaultHeaders: HttpHeaders = new HttpHeaders();
    public configuration: Configuration = new Configuration();

    constructor(protected httpClient: HttpClient, @Optional() configuration: Configuration) {
      let basePath: string = NotificationInjector.get(BASE_NOTIFICATION_PATH);
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
     * @param id
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public subscriptionGetAll(id: string, observe?: 'body', reportProgress?: boolean): Observable<Array<Subscription>>;
    public subscriptionGetAll(id: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<Subscription>>>;
    public subscriptionGetAll(id: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<Subscription>>>;
    public subscriptionGetAll(id: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (id === null || id === undefined) {
            throw new Error('Required parameter id was null or undefined when calling subscriptionGetAll.');
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

        return this.httpClient.get<Array<Subscription>>(`${this.basePath}/notification/subscription/users/${encodeURIComponent(String(id))}`,
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
     * @param theme
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public subscriptionSubscribe(id?: string, theme?: string, observe?: 'body', reportProgress?: boolean): Observable<Array<Subscription>>;
    public subscriptionSubscribe(id?: string, theme?: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<Subscription>>>;
    public subscriptionSubscribe(id?: string, theme?: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<Subscription>>>;
    public subscriptionSubscribe(id?: string, theme?: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {



        let queryParameters = new HttpParams({encoder: new CustomHttpUrlEncodingCodec()});
        if (id !== undefined && id !== null) {
            queryParameters = queryParameters.set('id', <any>id);
        }
        if (theme !== undefined && theme !== null) {
            queryParameters = queryParameters.set('theme', <any>theme);
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

        return this.httpClient.post<Array<Subscription>>(`${this.basePath}/notification/subscription/test`,
            null,
            {
                params: queryParameters,
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
     * @param theme
     * @param observe set whether or not to return the data Observable as the body, response or events. defaults to returning the body.
     * @param reportProgress flag to report request and response progress.
     */
    public subscriptionUnsubscribe(id: string, theme: string, observe?: 'body', reportProgress?: boolean): Observable<Array<Subscription>>;
    public subscriptionUnsubscribe(id: string, theme: string, observe?: 'response', reportProgress?: boolean): Observable<HttpResponse<Array<Subscription>>>;
    public subscriptionUnsubscribe(id: string, theme: string, observe?: 'events', reportProgress?: boolean): Observable<HttpEvent<Array<Subscription>>>;
    public subscriptionUnsubscribe(id: string, theme: string, observe: any = 'body', reportProgress: boolean = false ): Observable<any> {

        if (id === null || id === undefined) {
            throw new Error('Required parameter id was null or undefined when calling subscriptionUnsubscribe.');
        }

        if (theme === null || theme === undefined) {
            throw new Error('Required parameter theme was null or undefined when calling subscriptionUnsubscribe.');
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

        return this.httpClient.post<Array<Subscription>>(`${this.basePath}/notification/subscription/${encodeURIComponent(String(theme))}/users/${encodeURIComponent(String(id))}`,
            null,
            {
                withCredentials: this.configuration.withCredentials,
                headers: headers,
                observe: observe,
                reportProgress: reportProgress
            }
        );
    }

}
