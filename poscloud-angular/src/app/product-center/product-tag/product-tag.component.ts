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
        // this.employeeService.getAll(params).subscribe((result: PagedResultDtoOfEmployee) => {
        //     this.loading = false;
        //     this.employeeList = result.items;
        //     this.query.total = result.totalCount;
        //     console.log(result);

        // })
    }
}
