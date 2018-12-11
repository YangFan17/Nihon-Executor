import { Component, OnInit, Output, EventEmitter, Input, Injector } from '@angular/core';
import { ModalFormComponentBase } from '@shared/component-base/modal-form-component-base';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { ProductTag } from '@shared/entity/product-center';
import { AppComponentBase } from '@shared/app-component-base';
import { ProductServiceProxy } from '@shared/service-proxies/product-center';

@Component({
    moduleId: module.id,
    selector: 'edit-tag',
    templateUrl: 'edit-tag.component.html',
    styleUrls: ['edit-tag.component.less']
})

export class EditTagComponent extends AppComponentBase implements OnInit {
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

    show(id: number) {
        this.isVisible = true;
        let params: any = {};
        params.id = id;
        this.productService.getProductTagByIdAsync(params).subscribe((result: ProductTag) => {
            this.productTag = result;
        });
    }

    handleCancel = (e) => {
        this.isVisible = false;
        this.loading = false;
    }

    save(data: ProductTag) {
        if (this.validateForm.valid) {
            this.loading = true;
            this.productTag = data;
            this.productService.updateProductTag(data).finally(() => { this.loading = false; })
                .subscribe((result: ProductTag) => {
                    this.notify.info('保存成功', '');
                    this.modalSelect.emit();
                    this.isVisible = false;
                });
        }
    }
}
