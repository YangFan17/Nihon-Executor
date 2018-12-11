import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { RetailerComponent } from './retailer/retailer.component';
import { RetailerDetailComponent } from './retailer/retailer-detail/retailer-detail.component';

const routes: Routes = [
    {
        path: 'retailer',
        component: RetailerComponent,
        canActivate: [AppRouteGuard],
    },
    {
        path: 'retailer-detail',
        component: RetailerDetailComponent,
        canActivate: [AppRouteGuard],
    },
    {
        path: 'retailer-detail/:id',
        component: RetailerDetailComponent,
        canActivate: [AppRouteGuard],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class BasicRoutingModule { }
