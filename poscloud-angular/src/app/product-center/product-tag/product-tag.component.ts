import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { Router } from '@angular/router';
import { ProductServiceProxy } from '@shared/service-proxies/product-center/product-service';
import { Product } from '@shared/entity/product-center';

@Component({
    moduleId: module.id,
    selector: 'product-tag',
    templateUrl: 'product-tag.component.html',
    styleUrls: ['product-tag.component.less']
})
export class ProductTagComponent extends AppComponentBase implements OnInit {
    search: any = {};
    loading = false;
    product: Product[] = [];
    constructor(injector: Injector
        , private router: Router
        , private productService: ProductServiceProxy) {
        super(injector);
    }

    ngOnInit(): void {
    }
}
