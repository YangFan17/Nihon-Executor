import { Component, OnInit, Injector, ViewChild, Input, Output, EventEmitter, TemplateRef } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { Router } from '@angular/router';
import { Product } from '@shared/entity/product-center';
import { NzTreeNode, NzFormatEmitEvent, NzDropdownContextComponent, NzTreeComponent, NzDropdownService } from 'ng-zorro-antd';
import { EditTagComponent } from '../product-tag/edit-tag/edit-tag.component';
import { CreateTagComponent } from '../product-tag/create-tag/create-tag.component';
import { ProductServiceProxy, PagedResultDtoOfProduct } from '@shared/service-proxies/product-center';

@Component({
    moduleId: module.id,
    selector: 'product',
    templateUrl: 'product.component.html',
    styleUrls: ['product.component.less']
})
export class ProductComponent extends AppComponentBase implements OnInit {
    @Output() modalSelect: EventEmitter<any> = new EventEmitter<any>();
    @ViewChild('treeCom') treeCom: NzTreeComponent;
    @ViewChild('createModal') createModal: CreateTagComponent;
    @ViewChild('editModal') editModal: EditTagComponent;
    dropdown: NzDropdownContextComponent;
    activedNode: NzTreeNode;
    tempNode: string = 'root';
    rkeyNode: number;
    nodes = [];
    search: any = {};
    loading = false;
    productList: Product[] = [];
    isEnableTypes: any[] = [{ text: '启用', value: 1 }, { text: '禁用', value: 0 }];
    constructor(injector: Injector
        , private router: Router
        , private productService: ProductServiceProxy
        , private nzDropdownService: NzDropdownService
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.getTreeAsync();
    }

    refreshData(key: string, reset = false, search?: boolean) {
        if (reset) {
            this.query.pageIndex = 1;
            this.search = {};
        }
        if (search) {
            this.query.pageIndex = 1;
        }
        this.loading = true;
        let params: any = {};
        params.NodeKey = key;
        params.SkipCount = this.query.skipCount();
        params.MaxResultCount = this.query.pageSize;
        params.Filter = this.search.filter;
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

    /*************** 商品类型Tree代码***************/
    openFolder(data: NzTreeNode | NzFormatEmitEvent): void {
        if (data instanceof NzTreeNode) {
            data.isExpanded = !data.isExpanded;
        } else {
            data.node.isExpanded = !data.node.isExpanded;
        }
    }

    activeNode(data: NzFormatEmitEvent): void {
        if (this.activedNode) {
            this.treeCom.nzTreeService.setSelectedNodeList(this.activedNode);
        }
        data.node.isSelected = true;
        this.activedNode = data.node;
        this.tempNode = data.node.key;
        this.search = {};
        this.treeCom.nzTreeService.setSelectedNodeList(this.activedNode);
        this.refreshData(data.node.key);
    }

    contextMenu($event: MouseEvent, template: TemplateRef<void>, node: any): void {
        if (node.key != 'root') {
            this.dropdown = this.nzDropdownService.create($event, template);
            this.rkeyNode = node.key;
        }
    }

    showEdit(): void {
        if (this.dropdown) {
            this.dropdown.close();
        }
        this.editModal.show(this.rkeyNode);
    }
    showCreate(): void {
        this.createModal.show();
    }

    getCreateData() {
        this.getTreeAsync();
    }

    selectDropdown(type: string): void {
        this.dropdown.close();
    }

    getTreeAsync() {
        this.productService.getTagsTreeAsync().subscribe(res => {
            this.nodes = res;
            this.refreshData('root');
        });
    }
}
