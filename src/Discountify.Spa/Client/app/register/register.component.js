var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { RegisterService } from './register.service';
var RegisterComponent = (function () {
    function RegisterComponent(formBuilder, registerService) {
        this.formBuilder = formBuilder;
        this.registerService = registerService;
    }
    RegisterComponent.prototype.ngOnInit = function () {
        this.user = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required],
            repeatpassword: ['', Validators.required],
            email: ['', Validators.required],
            firstname: ['', Validators.required],
            lastname: ['', Validators.required],
            age: [''],
            gender: ['']
        });
    };
    RegisterComponent.prototype.onSubmit = function (_a) {
        var value = _a.value, valid = _a.valid;
        if (valid) {
            this.registerService.register(value)
                .subscribe(function (user) { console.log(user); }, function (error) { console.log(error); });
        }
    };
    return RegisterComponent;
}());
RegisterComponent = __decorate([
    Component({
        moduleId: String(module.id),
        templateUrl: './register.component.html'
    }),
    __metadata("design:paramtypes", [FormBuilder,
        RegisterService])
], RegisterComponent);
export { RegisterComponent };
//# sourceMappingURL=register.component.js.map