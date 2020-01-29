import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';
import { MessageService } from 'primeng/api';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    loginFormGroup: FormGroup;

    constructor(private fb: FormBuilder, private router: Router, public authService: AuthService, private messageService: MessageService) { }

    ngOnInit() {
        this.createLoginForm();
    }

    createLoginForm() {
        this.loginFormGroup = this.fb.group({
            email: ['', [Validators.required, Validators.maxLength(64)]],
            password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]]
        });
    }

    onLogin() {
        if (this.loginFormGroup.valid) {
            const loginModel: any = {
                email: this.loginFormGroup.get('email').value,
                password: this.loginFormGroup.get('password').value
            };
            this.authService.login(loginModel).subscribe(
                next => {                    
                    this.messageService.add({ key: 'toastKey1', severity: 'success', summary: 'Logged in successfully', detail: '' });
                },
                error => {
                    console.log(error);
                    if (error.statusText === 'Unknown Error') {
                        this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'Something went wrong on server', detail: '' });                        
                    }
                    else {
                        this.messageService.add({ key: 'toastKey1', severity: 'error', summary: 'The email or password is incorrect', detail: '' });
                    }                    
                }, () => {
                    this.router.navigate(['/dashboard']);
                }
            );
        }
    }
}
