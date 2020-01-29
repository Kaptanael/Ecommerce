import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { LoginRoutingModule } from './login.route';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';

@NgModule({
    declarations: [LoginComponent],
    imports: [
        CommonModule, FormsModule, ReactiveFormsModule, ToastModule, LoginRoutingModule
    ],
    providers: [MessageService]
})
export class LoginModule { }
