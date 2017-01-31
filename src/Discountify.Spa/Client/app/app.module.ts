import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import './core/rxjs-extensions';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { RegisterModule } from './register/register.module';
import { CoreModule } from './core/core.module';
import { ToastModule } from 'ng2-toastr/ng2-toastr';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        AppRoutingModule,
        DashboardModule,
        RegisterModule,
        CoreModule,
        NgbModule.forRoot(),
        ToastModule.forRoot()
    ],
    declarations: [AppComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }