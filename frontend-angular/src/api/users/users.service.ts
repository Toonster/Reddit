/**
 * Generated by orval v7.3.0 🍺
 * Do not edit manually.
 * RedditPoC.Api
 * OpenAPI spec version: 1.0
 */
import { HttpClient } from "@angular/common/http";
import type { HttpContext, HttpEvent, HttpHeaders, HttpParams, HttpResponse as AngularHttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import type { Command, Void } from "../reddit.schemas";

type HttpClientOptions = {
  headers?:
    | HttpHeaders
    | {
        [header: string]: string | string[];
      };
  context?: HttpContext;
  observe?: any;
  params?:
    | HttpParams
    | {
        [param: string]: string | number | boolean | ReadonlyArray<string | number | boolean>;
      };
  reportProgress?: boolean;
  responseType?: any;
  withCredentials?: boolean;
};

@Injectable({ providedIn: "root" })
export class UsersService {
  constructor(private http: HttpClient) {}
  postApiV1Users<TData = Void>(command: Command, options?: Omit<HttpClientOptions, "observe"> & { observe?: "body" }): Observable<TData>;
  postApiV1Users<TData = Void>(command: Command, options?: Omit<HttpClientOptions, "observe"> & { observe?: "response" }): Observable<AngularHttpResponse<TData>>;
  postApiV1Users<TData = Void>(command: Command, options?: Omit<HttpClientOptions, "observe"> & { observe?: "events" }): Observable<HttpEvent<TData>>;
  postApiV1Users<TData = Void>(command: Command, options?: HttpClientOptions): Observable<TData> {
    return this.http.post<TData>(`/api/v1/users`, command, options);
  }
  getApiV1UsersId<TData = Void>(id: string, options?: Omit<HttpClientOptions, "observe"> & { observe?: "body" }): Observable<TData>;
  getApiV1UsersId<TData = Void>(id: string, options?: Omit<HttpClientOptions, "observe"> & { observe?: "response" }): Observable<AngularHttpResponse<TData>>;
  getApiV1UsersId<TData = Void>(id: string, options?: Omit<HttpClientOptions, "observe"> & { observe?: "events" }): Observable<HttpEvent<TData>>;
  getApiV1UsersId<TData = Void>(id: string, options?: HttpClientOptions): Observable<TData> {
    return this.http.get<TData>(`/api/v1/users/${id}`, options);
  }
}

export type PostApiV1UsersClientResult = NonNullable<Void>;
export type GetApiV1UsersIdClientResult = NonNullable<Void>;
