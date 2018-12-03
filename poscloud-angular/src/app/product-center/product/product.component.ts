import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { Router } from '@angular/router';
import { ProductServiceProxy, PagedResultDtoOfProduct } from '@shared/service-proxies/product-center/product-service';
import { Product } from '@shared/entity/product-center';

@Component({
    moduleId: module.id,
    selector: 'product',
    templateUrl: 'product.component.html',
    styleUrls: ['product.component.less']
})
export class ProductComponent extends AppComponentBase implements OnInit {
    search: any = {};
    loading = false;
    productList: Product[] = [];
    constructor(injector: Injector
        , private router: Router
        , private productService: ProductServiceProxy) {
        super(injector);
    }

    ngOnInit(): void {
        this.refreshData();
    }

    refreshData(reset = false, search?: boolean) {
        if (reset) {
            this.query.pageIndex = 1;
            this.search = {};
        }
        if (search) {
            this.query.pageIndex = 1;
        }
        this.loading = true;
        let params: any = {};
        params.SkipCount = this.query.skipCount();
        params.MaxResultCount = this.query.pageSize;
        this.productService.getProductListAsync(params).subscribe((result: PagedResultDtoOfProduct) => {
            this.loading = false;
            this.productList = result.items;
            this.query.total = result.totalCount;
        })
    }

    createProduct() {
        this.router.navigate(['app/product/product-detail'])
    }
    goDetail(id: string) {
        this.router.navigate(['app/product/product-detail', id])
    }
}
