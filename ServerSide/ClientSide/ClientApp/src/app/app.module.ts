import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {NgxChartsModule} from '@swimlane/ngx-charts'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MatProgressBarModule} from "@angular/material/progress-bar";
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { InterceptorService } from './common/loader/interceptor.service';
import { HttpClientModule} from '@angular/common/http';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';
import { AdminComponent } from './dashboard/Admin/admin/admin.component';
import { ConfigurationComponent } from './dashboard/Configuration/configuration/configuration.component';
import { ProductComponent } from './dashboard/Product/product/product.component';
import { ReportComponent } from './dashboard/Report/report/report.component';
import { TrackingComponent } from './dashboard/Tracking/tracking/tracking.component';
import { ErrorPageComponent } from './error-page/error-page/error-page.component';
import { LoginComponent } from './login/login/login.component'
import { MdbModule } from 'mdb-angular-ui-kit';
import { ProductDetailsComponent } from './dashboard/Product/product/Product-detail/product-details/product-details.component';
import { ReactiveFormsModule } from '@angular/forms';
import {ScrollingModule} from '@angular/cdk/scrolling';
import { StoreComponent } from './dashboard/store/store.component';
import { MailComponent } from './dashboard/mail/mail.component';


@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    AdminComponent,
    ConfigurationComponent,
    ProductComponent,
    ReportComponent,
    TrackingComponent,
    ErrorPageComponent,
    LoginComponent,
    ProductDetailsComponent,
    StoreComponent,
    MailComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    NgxChartsModule,
    AppRoutingModule,
    MatProgressBarModule,
    HttpClientModule,
    MdbModule,
    ReactiveFormsModule,
    ScrollingModule
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS,useClass:InterceptorService,multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


