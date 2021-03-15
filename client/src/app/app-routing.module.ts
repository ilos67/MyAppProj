import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './products/products/products.component';
import { ReceipiesPanelComponent } from './receipie/receipies-panel/receipies-panel.component';
import { ReceipiesComponent } from './receipie/receipies/receipies.component';
import { AuthGuard } from './_helper/auth.guard';
import { Role } from './_models/role';


const accountModule = () => import('./account/account.module').then(x => x.AccountModule);
const adminModule = () => import('./admin/admin.module').then(x => x.AdminModule);
const profileModule = () => import('./profile/profile.module').then(x => x.ProfileModule);
const productModule = () => import('./products/products.module').then(x => x.ProductsModule);
const receipieModule = () => import('./receipie/receipie.module').then(x => x.ReceipieModule);

const routes: Routes = [
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
    { path: '', component: ProductsComponent},
    { path: 'recepies', component: ReceipiesComponent},
    { path: 'account', loadChildren: accountModule },
    { path: 'profile', loadChildren: profileModule, canActivate: [AuthGuard] },
    { path: 'admin', loadChildren: adminModule, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];


@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
