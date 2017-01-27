import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html'
})

export class DashboardComponent implements OnInit {
    private message: string;

    constructor(private router: Router) { }

    ngOnInit() {
        this.message = 'Welcome';
    }
}