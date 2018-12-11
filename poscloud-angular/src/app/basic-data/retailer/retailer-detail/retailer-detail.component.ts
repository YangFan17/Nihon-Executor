import { Component, OnInit, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzModalRef, NzModalService } from 'ng-zorro-antd';
import { ActivatedRoute, Router } from '@angular/router';
import { Retailer } from '@shared/entity/basic-data';
import { RetailerServiceProxy } from '@shared/service-proxies/basic-data';

@Component({
    moduleId: module.id,
    selector: 'retailer-detail',
    templateUrl: 'retailer-detail.component.html',
    styleUrls: ['retailer-detail.component.less']
})
export class RetailerDetailComponent extends AppComponentBase implements OnInit {
    id: number;
    cardTitle: string;
    retailer: Retailer = new Retailer();
    validateForm: FormGroup;
    isActionTypes: any[] = [{ text: '有效', value: true }, { text: '无效', value: false }];
    // 终端
    terminalTypes = [
        { text: '无', value: 0 },
        { text: '建议终端', value: 1 },
        { text: '普通终端', value: 2 },
        { text: '现代终端', value: 3 },
    ]
    // 订货方式
    orderModeTypes = [
        { text: '无', value: 0 },
        { text: '网上订货', value: 1 },
        { text: '电话订货', value: 2 },
        { text: '手机', value: 3 },
    ]
    confirmModal: NzModalRef;
    isConfirmLoading = false;
    isDelete = false;
    constructor(injector: Injector
        , private fb: FormBuilder
        , private actRouter: ActivatedRoute
        , private router: Router
        , private modal: NzModalService
        , private retailerService: RetailerServiceProxy
    ) {
        super(injector);
        this.id = this.actRouter.snapshot.params['id'];
    }

    ngOnInit(): void {
        this.validateForm = this.fb.group({
            name: [null, Validators.compose([Validators.required, Validators.maxLength(50)])],
            code: [null, Validators.compose([Validators.required, Validators.maxLength(50), Validators.minLength(6)])],
            licenseKey: [null, Validators.compose([Validators.required, Validators.maxLength(50), Validators.minLength(6)])],
            businessAddress: [null, Validators.compose([Validators.maxLength(50)])],
            archivalLevel: [null, Validators.compose([Validators.maxLength(100)])],
            orderCycle: [null, Validators.compose([Validators.maxLength(100)])],
            telephone: [null, Validators.compose([Validators.maxLength(100)])],
            isAction: [null, Validators.compose([Validators.required])],
            branchCompany: [null, Validators.compose([Validators.maxLength(200)])],
            department: [null, Validators.compose([Validators.maxLength(100)])],
            slsmanName: [null, Validators.compose([Validators.maxLength(50)])],
            area: [null, Validators.compose([Validators.maxLength(100)])],
            orderMode: null,
            terminalType: null,
            businessType: [null, Validators.compose([Validators.maxLength(100)])],
            authorizationCode: [null, Validators.compose([Validators.maxLength(100)])]
        });
        this.getRetail();
    }

    getRetail() {
        if (this.id) {
            this.cardTitle = '编辑零售户';
            let params: any = {};
            params.id = this.id;
            this.retailerService.getRetailerByIdAsync(params).subscribe((result: Retailer) => {
                this.retailer = result;
                this.isDelete = true;
            });
        } else {
            this.cardTitle = '新增零售户';
            this.retailer.isAction = true;
        }
    }

    save() {
        for (const i in this.validateForm.controls) {
            this.validateForm.controls[i].markAsDirty();
        }
        if (this.validateForm.valid) {
            this.isConfirmLoading = true;
            this.retailerService.updateRetailerInfo(this.retailer).finally(() => { this.isConfirmLoading = false; })
                .subscribe((result: Retailer) => {
                    this.retailer = result;
                    this.isDelete = true;
                    this.notify.info('保存成功', '');
                });
        }
    }

    delete(): void {
        this.confirmModal = this.modal.confirm({
            nzContent: '是否删除商品?',
            nzOnOk: () => {
                this.retailerService.deleteRetailer(this.retailer.id).subscribe(() => {
                    this.notify.info('删除成功!', '');
                    this.return();
                });
            }
        });
    }

    return() {
        this.router.navigate(['app/basic/retailer']);
    }
}
