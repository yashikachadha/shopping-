import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HttpHeaders } from '@angular/common/http';
import {FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AloginComponent } from './alogin/alogin.component';
import { BregisterComponent } from './bregister/bregister.component';
import { CregisterProductComponent } from './cregister-product/cregister-product.component';
import { DisplayProductsComponent } from './display-products/display-products.component';
import { EsearchProductComponent } from './esearch-product/esearch-product.component';
import { FcartactionsComponent } from './fcartactions/fcartactions.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { Page404Component } from './page404/page404.component';
import { DisplayUsersComponent } from './display-users/display-users.component';


@NgModule({
  declarations: [
    AppComponent,
    AloginComponent,
    BregisterComponent,
    CregisterProductComponent,
    DisplayProductsComponent,
    EsearchProductComponent,
    FcartactionsComponent,
    DashboardComponent,
    Page404Component,
    DisplayUsersComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
   // HttpHeaders
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
