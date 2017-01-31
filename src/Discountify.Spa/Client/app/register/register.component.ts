import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subscription } from 'rxjs/Subscription';

import { RegisterService } from './register.service';
import { User } from '../models/user.model';

@Component({
    moduleId: String(module.id),
    templateUrl: './register.component.html'
})

export class RegisterComponent implements OnInit {
    user: FormGroup;

    constructor(
        private formBuilder: FormBuilder,
        private registerService: RegisterService) { }

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
                .subscribe((user) => { console.log(user); },
                    (error) => { console.log(error); });
        }
    }
}