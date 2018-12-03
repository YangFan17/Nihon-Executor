import 'rxjs/add/operator/finally';
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, from as _observableFrom, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

import * as moment from 'moment';
import { API_BASE_URL } from '@shared/service-proxies/service-proxies';

@Injectable()
export class PosCloudHttpClient {

    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    get(url: string, params?: { [key: string]: string }, showLoading?: boolean): Observable<any> {
        url = this.baseUrl + url;
        return this.request(url + this._formatUrl(params), "get", null, showLoading);
    }

    post(url: string, body?: any, params?: { [key: string]: any }, showLoading?: boolean): Observable<any> {
        url = this.baseUrl + url;
        if (params) {
            url += this._formatUrl(params);
        }
        return this.request(url, "post", body, showLoading);
    }

    delete(url: string, params?: { [key: string]: string }, showLoading?: boolean): Observable<any> {
        url = this.baseUrl + url;
        return this.deleteRequest(url + this._formatUrl(params), showLoading);
    }

    deleteRequest(url_: string, showLoading?: boolean): Observable<any> {
        url_ = url_.replace(/[?&]$/, "");
        let options_: any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
            })
        };
        return this.http.request("delete", url_, options_).pipe(_observableMergeMap((response_: any) => {
            return this.processDelete(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processDelete(<any>response_);
                } catch (e) {
                    return <any>_observableThrow(e);
                }
            } else
                return <any>_observableThrow(response_);
        }));

    }

    protected processDelete(response: HttpResponseBase): Observable<void> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
                (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); } };
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
                return _observableOf<void>(<any>null);
            }));
        } else if (status === 401) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
                return throwException("A server error occurred.", status, _responseText, _headers);
            }));
        } else if (status === 403) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
                return throwException("A server error occurred.", status, _responseText, _headers);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<void>(<any>null);
    }

    request(url_: string, method: string, body?: any, showLoading?: boolean): Observable<any> {
        url_ = url_.replace(/[?&]$/, "");
        let options_: any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/json"
            })
        };
        if (body) {
            const content_ = JSON.stringify(body);
            options_.body = content_;
        }
        return this.http.request(method, url_, options_).pipe(_observableMergeMap((response_: any) => {
            return this.process(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.process(<any>response_);
                } catch (e) {
                    return <any>_observableThrow(e);
                }
            } else
                return <any>_observableThrow(response_);
        }));

    }

    /**
     * 将字典转为QueryString
     */
    private _formatUrl(params?: { [key: string]: string }): string {
        if (!params) return '';

        let fegment = [];
        for (let k in params) {
            let v: any = params[k];
            if (v) {
                if (v instanceof Date) {
                    v = moment(v).format('YYYY-MM-DD HH:mm:SS');
                }
                fegment.push(`${k}=${v}`);
            }
        }
        return '?' + fegment.join('&');
    }

    private process(response: HttpResponseBase): Observable<any> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
                (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); } };
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 ? resultData200 : _observableOf<any>(<any>null);
                return _observableOf(result200);
            }));
        } else if (status === 401) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
                return throwException("服务器错误。", status, _responseText, _headers);
            }));
        } else if (status === 403) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
                return throwException("服务器错误。", status, _responseText, _headers);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
                return throwException("服务器异常错误", status, _responseText, _headers);
            }));
        }
        return _observableOf<null>(<any>null);
    }
}

export class SwaggerException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = function () {
                observer.next(this.result);
                observer.complete();
            }
            reader.readAsText(blob);
        }
    });
}
