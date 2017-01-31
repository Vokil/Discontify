var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { ApiUrls } from '../core';
var RegisterService = (function () {
    function RegisterService(http) {
        this.http = http;
    }
    RegisterService.prototype.register = function (user) {
        var body = JSON.stringify(user);
        var registerUrl = ApiUrls.registerUrl;
        return this.http
            .post(registerUrl, body)
            .map(function (res) { return res.json().data; });
    };
    return RegisterService;
}());
RegisterService = __decorate([
    Injectable(),
    __metadata("design:paramtypes", [Http])
], RegisterService);
export { RegisterService };
//# sourceMappingURL=register.service.js.map