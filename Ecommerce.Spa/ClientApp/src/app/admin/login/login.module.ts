import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { LoginRoutingModule } from './login.route';

@NgModule({
    declarations: [LoginComponent],
    imports: [
        CommonModule, LoginRoutingModule
  ]
})
export class LoginModule { }
