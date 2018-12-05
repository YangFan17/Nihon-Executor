// Angular Imports
import { NgModule } from '@angular/core';
import { ProductComponent } from './product/product.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { LayoutModule } from '@app/layout/layout.module';
import { SharedModule } from '@shared/shared.module';
import { AbpModule } from 'abp-ng2-module/dist/src/abp.module';
import { LocalizationService } from 'abp-ng2-module/dist/src/localization/localization.service';
import { ProductTagComponent } from './product-tag/product-tag.component';
import { BasicRoutingModule } from './product-center-routing.module';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';
import { CreateTagComponent } from './product-tag/create-tag/create-tag.component';
import { EditTagComponent } from './product-tag/edit-tag/edit-tag.component';

// This Module's Components

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule,
        LayoutModule,
        SharedModule,
        AbpModule,
        BasicRoutingModule
    ],
    declarations: [
        ProductComponent,
        ProductTagComponent,
        ProductDetailComponent,
        EditTagComponent,
        CreateTagComponent
    ],
    entryComponents: [
    ],
    providers: [LocalizationService],
})
export class ProductModule { }
