import { NgModule } from '@angular/core';
import { requestOptionsProvider } from './default-request-options.service';

@NgModule({
    providers: [requestOptionsProvider]
})

export class CoreModule { }