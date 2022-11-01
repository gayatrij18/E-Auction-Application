import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { ViewBidsComponent } from './view-bids/view-bids.component';
import { ViewProductsComponent } from './view-products/view-products.component';

const routes: Routes = [
  {path:'view-bids', component:ViewBidsComponent},
  {path:'view-products', component:ViewProductsComponent, canActivate:[AuthGuard]},
  {path:'header', component:HeaderComponent},
  {path:'', redirectTo:'/login', pathMatch:'full'},
  {path:'login', component:LoginComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

  columnNames:string[] = ['id', 'productName'];
}
