import { Component, Output, EventEmitter, Injector, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { ProductServiceProxy } from '@shared/service-proxies/product-center/product-service';
import { ProductTag } from '@shared/entity/product-center';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
    moduleId: module.id,
    selector: 'create-tag',
    templateUrl: 'create-tag.component.html',
    styleUrls: ['create-tag.component.less']
})
export class CreateTagComponent extends AppComponentBase implements OnInit {
    @Output() modalSelect: EventEmitter<any> = new EventEmitter<any>();
    validateForm: FormGroup;
    productTag: ProductTag = new ProductTag();
    loading = false;
    isVisible = false;
    constructor(
        injector: Injector
        , private productService: ProductServiceProxy
        , private fb: FormBuilder
    ) {
        super(injector);
    }

    ngOnInit() {
        this.validateForm = this.fb.group({
            name: [null, Validators.compose([Validators.required, Validators.maxLength(200)])],
            seq: [null, Validators.compose([Validators.required, Validators.pattern('^[0-9]*[1-9][0-9]*$')])]
        });
    }

    show() {
        this.productTag.name = null;
        this.productTag.seq = null;
        this.isVisible = true;
    }

    handleCancel = (e) => {
        this.isVisible = false;
        this.loading = false;
    }

    save(data: ProductTag) {
        if (this.validateForm.valid) {
            this.loading = true;
            this.productTag = data;
            this.productService.createProductTag(data).finally(() => { this.loading = false; })
                .subscribe((result: ProductTag) => {
                    this.notify.info('保存成功', '');
                    this.modalSelect.emit();
                    this.isVisible = false;
                });
        }
    }
}
