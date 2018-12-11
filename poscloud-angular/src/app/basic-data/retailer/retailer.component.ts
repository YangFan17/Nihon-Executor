import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { Router } from '@angular/router';
import { Retailer } from '@shared/entity/basic-data';
import { RetailerServiceProxy, PagedResultDtoOfRetailer } from '@shared/service-proxies/basic-data';

@Component({
    moduleId: module.id,
    selector: 'retailer',
    templateUrl: 'retailer.component.html',
    styleUrls: ['retailer.component.less']
})
export class RetailerComponent extends AppComponentBase implements OnInit {
    search: any = { isAction: true };
    loading = false;
    retailerList: Retailer[] = [];
    status = [
        { text: '有效', value: true, type: 'success' },
        { text: '无效', value: false, type: 'error' },
    ];
    constructor(injector: Injector
        , private router: Router
        , private retailerService: RetailerServiceProxy
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.search = { isAction: true }
        this.refreshData();
    }

    refreshData(reset = false, search?: boolean) {
        if (reset) {
            this.query.pageIndex = 1;
            this.search = { isAction: true }
        }
        if (search) {
            this.query.pageIndex = 1;
        }
        this.loading = true;
        let params: any = {};
        params.SkipCount = this.query.skipCount();
        params.MaxResultCount = this.query.pageSize;
        params.Filter = this.search.filter;
        params.IsAction = this.search.isAction;
        this.retailerService.getRetailerListAsync(params).subscribe((result: PagedResultDtoOfRetailer) => {
            this.loading = false;
            let status = 0;
            this.retailerList = result.items.map(i => {
                if (i.isAction) {
                    status = 0;
                } else {
                    status = 1;
                }
                const statusItem = this.status[status];
                i.actionText = statusItem.text;
                i.actionType = statusItem.type;
                return i;
            });
            this.retailerList = result.items;
            this.query.total = result.totalCount;
        })
    }

    createRetailer() {
        this.router.navigate(['app/basic/retailer-detail'])
    }
    goDetail(id: string) {
        this.router.navigate(['app/basic/retailer-detail', id])
    }
}
