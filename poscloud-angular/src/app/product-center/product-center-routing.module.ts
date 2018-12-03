import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { ProductComponent } from './product/product.component';
import { ProductTagComponent } from './product-tag/product-tag.component';
import { ProductDetailComponent } from './product/product-detail/product-detail.component';

const routes: Routes = [
    {
        path: 'product',
        component: ProductComponent,
        canActivate: [AppRouteGuard],
    },
    {
        path: 'productTag',
        component: ProductTagComponent,
        canActivate: [AppRouteGuard],
    },
    {
        path: 'product-detail',
        component: ProductDetailComponent,
        canActivate: [AppRouteGuard],
    },
    {
        path: 'product-detail/:id',
        component: ProductDetailComponent,
        canActivate: [AppRouteGuard],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class BasicRoutingModule { }
