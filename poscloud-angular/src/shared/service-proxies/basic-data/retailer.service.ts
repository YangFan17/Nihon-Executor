import 'rxjs/add/operator/finally';
import 'rxjs/add/operator/map';
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, from as _observableFrom, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { API_BASE_URL } from '@shared/service-proxies/service-proxies';
import { PosCloudHttpClient } from '../poscloud-httpclient';
import { Retailer } from '@shared/entity/basic-data';

@Injectable()
export class RetailerServiceProxy {
    private http: HttpClient;
    private _poshttp: PosCloudHttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Inject(PosCloudHttpClient) poshttp: PosCloudHttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
        this._poshttp = poshttp;
    }
    getRetailerListAsync(params: any): Observable<PagedResultDtoOfRetailer> {
        let url_ = "/api/services/app/Retailer/GetPagedRetailerListAsync";
        return this._poshttp.get(url_, params).map(data => {
            if (data) {
                return PagedResultDtoOfRetailer.fromJS(data);
            } else {
                return null;
            }
        });
    }

    getRetailerByIdAsync(params: any): Observable<Retailer> {
        let url_ = "/api/services/app/Retailer/GetRetailerByIdAsync";
        return this._poshttp.get(url_, params).map(data => {
            if (data) {
                return Retailer.fromJS(data);
            } else {
                return null;
            }
        });
    }

    updateRetailerInfo(room: any): Observable<Retailer> {
        let url_ = "/api/services/app/Retailer/CreateOrUpdateRetailerByIdAsync";
        return this._poshttp.post(url_, room).map(data => {
            return data;
        });
    }


    getRetailerById(params: any): Observable<Retailer> {
        let url_ = "/api/services/app/Retailer/GetRetailerByIdAsync";
        return this._poshttp.get(url_, params).map(data => {
            if (data) {
                return Retailer.fromJS(data);
            } else {
                return null;
            }
        });
    }

    deleteRetailer(id: string): Observable<any> {
        let url_ = "/api/services/app/Retailer/DeleteRetailerByIdAsync";
        var param = { id: id };
        return this._poshttp.delete(url_, param).map(data => {
            return data;
        });
    }
}

export class PagedResultDtoOfRetailer implements IPagedResultDtoOfRetailer {
    totalCount: number;
    items: Retailer[];

    constructor(data?: IPagedResultDtoOfRetailer) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.totalCount = data["totalCount"];
            if (data["items"] && data["items"].constructor === Array) {
                this.items = [];
                for (let item of data["items"])
                    this.items.push(Retailer.fromJS(item));
            }
        }
    }

    static fromJS(data: any): PagedResultDtoOfRetailer {
        let result = new PagedResultDtoOfRetailer();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["totalCount"] = this.totalCount;
        if (this.items && this.items.constructor === Array) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        return data;
    }

    clone() {
        const json = this.toJSON();
        let result = new PagedResultDtoOfRetailer();
        result.init(json);
        return result;
    }
}

export interface IPagedResultDtoOfRetailer {
    totalCount: number;
    items: Retailer[];
}