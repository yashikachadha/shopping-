import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {DashboardComponent} from './dashboard/dashboard.component';
import {AloginComponent} from './alogin/alogin.component';
import {BregisterComponent} from './bregister/bregister.component';
import {CregisterProductComponent} from './cregister-product/cregister-product.component';
import {DisplayProductsComponent} from './display-products/display-products.component';
import {EsearchProductComponent} from './esearch-product/esearch-product.component';
import {FcartactionsComponent} from './fcartactions/fcartactions.component';
import {Page404Component} from './page404/page404.component';
import {DisplayUsersComponent} from './display-users/display-users.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'login', component:AloginComponent},
  { path: 'register', component:BregisterComponent},
  { path: 'registerProduct', component:CregisterProductComponent},
  { path: 'displayProducts', component:DisplayProductsComponent},
  { path: 'search', component:EsearchProductComponent},
  {path: 'cart',component:FcartactionsComponent},
  {path: 'displayUsers', component:DisplayUsersComponent},
  {path:"**", component:Page404Component},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
 