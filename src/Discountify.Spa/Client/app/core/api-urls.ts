let webApiBaseUrl: string = 'http://localhost:58059/api/';

export let ApiUrls = {
    registerUrl: `${webApiBaseUrl}auth/register`,
    cardsUrl: `${webApiBaseUrl}cards`
};

//import { Injectable } from '@angular/core';

//@Injectable()
//export class ApiUrlsService {
//    private webApiBaseUrl: string = "http://localhost:58059/api/";

//    get registerUrl(): string {
//        return `${this.webApiBaseUrl}register`;
//    }

//    get cardsUrl(): string {
//        return `${this.webApiBaseUrl}cards`;
//    }
//}