import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../core/services/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    loginFormGroup: FormGroup;

    constructor(private fb: FormBuilder, private router: Router, public authService: AuthService) { }

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
                    console.log('Success');
                    //this.growlMessage = [];
                    //this.growlMessage.push({ severity: 'success', summary: 'Logged in successfully', detail: '' });
                },
                error => {
                    console.log(error);
                    //this.growlMessage = [];
                    //this.growlMessage.push({ severity: 'error', summary: error, detail: '' });
                }, () => {
                    this.router.navigate(['/dashboard']);
                }
            );
        }
    }
}
