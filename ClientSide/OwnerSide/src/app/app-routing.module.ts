import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent} from './dashboard/dashboard/dashboard.component';
import {ConfigurationComponent } from './dashboard/Configuration/configuration/configuration.component';
import {AdminComponent} from './dashboard/Admin/admin/admin.component';
import {ProductComponent} from './dashboard/Product/product/product.component';
import {ReportComponent} from './dashboard/Report/report/report.component';
import {TrackingComponent} from './dashboard/Tracking/tracking/tracking.component';
import {ErrorPageComponent} from './error-page/error-page/error-page.component';
import {LoginComponent} from './login/login/login.component';
import { ProductDetailsComponent} from './dashboard/Product/product/Product-detail/product-details/product-details.component';
const routes: Routes = [
  { path:'dashboard', component:DashboardComponent ,children:[
            {path:'config',component:ConfigurationComponent},
            {path:'admin',component:AdminComponent},
            {path:'product',component:ProductComponent , children:[ {path:'productdetails',component:ProductDetailsComponent}]},
            {path:'report',component:ReportComponent},
            {path:'track',component:TrackingComponent}  
  ]},
  {path:'', component:LoginComponent},
  { path:'**',component:ErrorPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingcomponent=[DashboardComponent,ConfigurationComponent,AdminComponent,
  ProductComponent,ReportComponent,TrackingComponent,LoginComponent];
