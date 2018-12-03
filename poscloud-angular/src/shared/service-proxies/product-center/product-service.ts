import 'rxjs/add/operator/finally';
import 'rxjs/add/operator/map';
import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, from as _observableFrom, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { API_BASE_URL } from '@shared/service-proxies/service-proxies';
import { PosCloudHttpClient } from '../poscloud-httpclient';
import { Product } from '@shared/entity/product-center';

@Injectable()
export class ProductServiceProxy {
    private http: HttpClient;
    private _poshttp: PosCloudHttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Inject(PosCloudHttpClient) poshttp: PosCloudHttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
        this._poshttp = poshttp;
    }
    getProductListAsync(params: any): Observable<PagedResultDtoOfProduct> {
        let url_ = "/api/services/app/Product/GetPagedProductListAsync";
        return this._poshttp.get(url_, params).map(data => {
            if (data) {
                return PagedResultDtoOfProduct.fromJS(data);
            } else {
                return null;
            }
        });
    }

    getProductByIdAsync(params: any): Observable<Product> {
        let url_ = "/api/services/app/Product/GetProductByIdAsync";
        return this._poshttp.get(url_, params).map(data => {
            if (data) {
                return Product.fromJS(data);
            } else {
                return null;
            }
        });
    }

    updateProductInfo(room: any): Observable<Product> {
        let url_ = "/api/services/app/Product/CreateOrUpdateProductAsycn";
        return this._poshttp.post(url_, room).map(data => {
            return data;
        });
    }

    getProductById(params: any): Observable<Product> {
        let url_ = "/api/services/app/Product/GetProductByIdAsync";
        return this._poshttp.get(url_, params).map(data => {
            if (data) {
                return Product.fromJS(data);
            } else {
                return null;
            }
        });
    }

    deleteProduct(id: string): Observable<any> {
        let url_ = "/api/services/app/Product/ProductDeleteByIdAsync";
        var param = { id: id };
        return this._poshttp.delete(url_, param).map(data => {
            return data.result;
        });
    }
}

export class PagedResultDtoOfProduct implements IPagedResultDtoOfProduct {
    totalCount: number;
    items: Product[];

    constructor(data?: IPagedResultDtoOfProduct) {
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
                    this.items.push(Product.fromJS(item));
            }
        }
    }

    static fromJS(data: any): PagedResultDtoOfProduct {
        let result = new PagedResultDtoOfProduct();
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
        let result = new PagedResultDtoOfProduct();
        result.init(json);
        return result;
    }
}

export interface IPagedResultDtoOfProduct {
    totalCount: number;
    items: Product[];
}