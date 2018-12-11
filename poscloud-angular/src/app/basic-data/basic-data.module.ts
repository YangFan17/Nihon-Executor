// Angular Imports
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { LayoutModule } from '@app/layout/layout.module';
import { SharedModule } from '@shared/shared.module';
import { AbpModule } from 'abp-ng2-module/dist/src/abp.module';
import { LocalizationService } from 'abp-ng2-module/dist/src/localization/localization.service';
import { RetailerComponent } from './retailer/retailer.component';
import { RetailerDetailComponent } from './retailer/retailer-detail/retailer-detail.component';
import { BasicRoutingModule } from './basic-data-routing.module';

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
        RetailerComponent,
        RetailerDetailComponent
    ],
    entryComponents: [
    ],
    providers: [LocalizationService],
})
export class BasicDataModule {

}
