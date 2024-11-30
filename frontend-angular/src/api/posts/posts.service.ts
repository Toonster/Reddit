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
export class PostsService {
  constructor(private http: HttpClient) {}
  getApiV1Posts<TData = number>(options?: Omit<HttpClientOptions, "observe"> & { observe?: "body" }): Observable<TData>;
  getApiV1Posts<TData = number>(options?: Omit<HttpClientOptions, "observe"> & { observe?: "response" }): Observable<AngularHttpResponse<TData>>;
  getApiV1Posts<TData = number>(options?: Omit<HttpClientOptions, "observe"> & { observe?: "events" }): Observable<HttpEvent<TData>>;
  getApiV1Posts<TData = number>(options?: HttpClientOptions): Observable<TData> {
    return this.http.get<TData>(`/api/v1/posts`, options);
  }
  getApiV1PostsId<TData = number>(id: number, options?: Omit<HttpClientOptions, "observe"> & { observe?: "body" }): Observable<TData>;
  getApiV1PostsId<TData = number>(id: number, options?: Omit<HttpClientOptions, "observe"> & { observe?: "response" }): Observable<AngularHttpResponse<TData>>;
  getApiV1PostsId<TData = number>(id: number, options?: Omit<HttpClientOptions, "observe"> & { observe?: "events" }): Observable<HttpEvent<TData>>;
  getApiV1PostsId<TData = number>(id: number, options?: HttpClientOptions): Observable<TData> {
    return this.http.get<TData>(`/api/v1/posts/${id}`, options);
  }
}

export type GetApiV1PostsClientResult = NonNullable<number>;
export type GetApiV1PostsIdClientResult = NonNullable<number>;