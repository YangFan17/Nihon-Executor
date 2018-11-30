import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef, OnInit } from '@angular/core';
import { UserServiceProxy, ChangePasswordDto, UserDto, CreateUserDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { FormGroup, FormBuilder, Validators, FormControl, AsyncValidatorFn, AbstractControl } from '@angular/forms';

import { Observable } from 'rxjs/Observable';

//import * as _ from "lodash";

@Component({
    selector: 'change-password-modal',
    templateUrl: './change-password.component.html'
})
export class ChangePasswordComponent extends AppComponentBase implements OnInit {
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    modalVisible = false;
    isConfirmLoading = false;
    isDisablec = false;
    changePassword: ChangePasswordDto = null;
    oldUser: CreateUserDto = new CreateUserDto();
    isOldPasswordValid = false;
    //roles: RoleDto[] = null;

    validateForm: FormGroup;
    //roles: RoleDto[] = null;
    roles: any = [];

    constructor(
        injector: Injector,
        private _userService: UserServiceProxy,
        private fb: FormBuilder
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.validateForm = this.fb.group({
            orgPassword: [null, [Validators.required]],
            newPassword: [null, [Validators.required]],
            checkPassword: [null, Validators.compose([Validators.required, this.confirmationValidator])]
        });

    }

    show(): void {
        this.reset();
        this.changePassword = new ChangePasswordDto();
        this.modalVisible = true;
        //对isDisablec做初始化
        this.isDisablec = false;
    }

    save(isSave = false): void {
        for (const i in this.validateForm.controls) {
            this.validateForm.controls[i].markAsDirty();
        }
        this.isConfirmLoading = true
        if (this.validateForm.valid) {
            this._userService.checkOldPassword(this.changePassword.orgPassword).subscribe((isValid: boolean) => {
                if (isValid == true) {
                    this._userService.updatePassword(this.changePassword.newPassword)
                        .finally(() => { this.isConfirmLoading = false; })
                        .subscribe(() => {
                            this.notify.info(this.l('修改成功！'), '');
                            this.close();
                            this.modalSave.emit(null);
                        });
                } else {
                    this.isConfirmLoading = false;
                    // this.isOldPasswordValid=true;
                    this.notify.error('原密码错误');

                }
            });
        }
    }

    close(): void {
        this.modalVisible = false;
        //this.modal.hide();
    }

    handleCancel = (e) => {
        this.modalVisible = false;
        this.isConfirmLoading = false;
        this.reset(e);
    }


    /**
     * 新密码确认验证
     */
    confirmationValidator = (control: FormControl): { [s: string]: boolean } => {
        if (!control.value) {
            return { required: true };
        } else if (control.value !== this.validateForm.controls['newPassword'].value) {
            return { confirm: true, error: true };
        }
    }


    getFormControl(name: string) {
        return this.validateForm.controls[name];
    }

    reset(e?): void {
        if (e) {
            e.preventDefault();
        }
        this.validateForm.reset();
        for (const key in this.validateForm.controls) {
            this.validateForm.controls[key].markAsPristine();
        }
    }


}
