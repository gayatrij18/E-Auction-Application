import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ViewBidsComponent } from './view-bids/view-bids.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatListModule}  from '@angular/material/list';

import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';

import {MatSortModule} from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ViewProductsComponent } from './view-products/view-products.component';
import { HeaderComponent } from './header/header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { DisplayProductsComponent } from './display-products/display-products.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProductsComponent } from './products/products.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { CouponsComponent } from './coupons/coupons.component';
import { PagesComponent } from './pages/pages.component';
import { MediaComponent } from './media/media.component';
import { SettingsComponent } from './settings/settings.component';
import { AddProductComponent } from './add-product/add-product.component';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatDialogModule} from '@angular/material/dialog';
import { DialogBoxComponent } from './dialog-box/dialog-box.component';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { InterceptorService } from './loader/interceptor.service';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';



//import {MatTableDataSource} from '@angular/material/table';




@NgModule({
  declarations: [
    AppComponent,
    ViewBidsComponent,
    ViewProductsComponent,
    HeaderComponent,
    LoginComponent,
    DisplayProductsComponent,
    SidenavComponent,
    DashboardComponent,
    ProductsComponent,
    StatisticsComponent,
    CouponsComponent,
    PagesComponent,
    MediaComponent,
    SettingsComponent,
    AddProductComponent,
    DialogBoxComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MatIconModule,
    MatToolbarModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatListModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    MatDialogModule,
    MatProgressBarModule,
    MatProgressSpinnerModule
 ],
  providers: [
    { provide:HTTP_INTERCEPTORS, useClass:InterceptorService, multi:true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
