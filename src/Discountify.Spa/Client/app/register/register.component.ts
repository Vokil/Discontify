import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs/Subscription';

import { RegisterService } from './register.service';
import { User } from '../models/user.model';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
    moduleId: String(module.id),
    templateUrl: './register.component.html'
})

export class RegisterComponent implements OnInit {
    user: FormGroup;

    constructor(
        private formBuilder: FormBuilder,
        private registerService: RegisterService,
        public toastr: ToastsManager,
        vcr: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vcr);
    }

    ngOnInit() {
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
    }

    onSubmit({ value, valid }: { value: User, valid: boolean }) {
        if (valid) {
            this.registerService.register(value)
                .subscribe((result) => {
                    this.toastr.success("You're successfully registred!", "Success");
                }, (errorContainer) => {
                    var errors = JSON.parse(errorContainer._body);
                    for (let errorEntry of errors) {
                        this.toastr.success(errorEntry.description, "Error");
                    }
                });
        }
    }
}