import { NgModule, Optional, SkipSelf } from '@angular/core';

import { requestOptionsProvider } from './default-request-options.service';

import { throwIfAlreadyLoaded } from './module-import-guard';

@NgModule({
    providers: [requestOptionsProvider]
})

export class CoreModule {
    constructor(
        @Optional()
        @SkipSelf()
        parentModule: CoreModule) {
        throwIfAlreadyLoaded(parentModule, 'CoreModule');
    }
}