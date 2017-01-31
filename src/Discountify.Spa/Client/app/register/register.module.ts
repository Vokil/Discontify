import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterRoutingModule, routedComponents } from './register-routing.module';

import { RegisterService } from './register.service';

@NgModule({
    imports: [RegisterRoutingModule, ReactiveFormsModule, BrowserModule],
    declarations: [routedComponents],
    providers: [RegisterService]
})

export class RegisterModule { }