import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { CouponsComponent } from './coupons/coupons.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DisplayProductsComponent } from './display-products/display-products.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { MediaComponent } from './media/media.component';
import { PagesComponent } from './pages/pages.component';
import { ProductsComponent } from './products/products.component';
import { SettingsComponent } from './settings/settings.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { StatisticsComponent } from './statistics/statistics.component';
import { ViewBidsComponent } from './view-bids/view-bids.component';
import { ViewProductsComponent } from './view-products/view-products.component';

const routes: Routes = [
  {path:'view-bids', component:ViewBidsComponent},
  {path:'view-products', component:ViewProductsComponent, canActivate:[AuthGuard]},
  {path:'header', component:HeaderComponent},
  {path:'', redirectTo:'/login', pathMatch:'full'},
  {path:'login', component:LoginComponent},
  {path: 'display-products', component:DisplayProductsComponent},
  {path: 'sidenav', component:SidenavComponent},
  {path: 'dashboard', component:DashboardComponent},
  {path: 'products', component:ViewProductsComponent},
  {path: 'statistics', component:StatisticsComponent},
  {path: 'coupons', component:ViewProductsComponent},
  {path: 'pages', component:PagesComponent},
  {path: 'media', component:MediaComponent},
  {path: 'settings', component:SettingsComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

  columnNames:string[] = ['id', 'productName'];
}
