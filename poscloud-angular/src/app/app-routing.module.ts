import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from '@app/home/home.component';
import { AppComponent } from '@app/app.component';
import { TenantsComponent } from '@app/system/tenants/tenants.component';
import { RolesComponent } from '@app/system/roles/roles.component';
import { UsersComponent } from '@app/system/users/users.component';
const routes: Routes = [
  {
    path: 'app',
    component: AppComponent,
    canActivate: [AppRouteGuard],
    canActivateChild: [AppRouteGuard],
    children: [
      {
        path: 'home',
        component: HomeComponent,
        canActivate: [AppRouteGuard],
      },
      {
        path: 'tenants',
        component: TenantsComponent,
        canActivate: [AppRouteGuard],
      },
      {
        path: 'roles',
        component: RolesComponent,
        canActivate: [AppRouteGuard],
      },
      {
        path: 'users',
        component: UsersComponent,
        canActivate: [AppRouteGuard],
      },
      {
        path: 'product',
        loadChildren: './product-center/product-center.module#ProductModule', // Lazy load account module
        data: { preload: true },
      },
      {
        path: '**',
        redirectTo: 'home',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
