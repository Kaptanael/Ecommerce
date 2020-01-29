import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from "./app-routing.module";
import { DashboardModule } from './admin/dashboard/dashboard.module';

import { AppComponent } from "./app.component";
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from "./core/not-found/not-found.component";

@NgModule({
    declarations: [AppComponent, HomeComponent, NotFoundComponent],
    imports: [BrowserModule,        
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        AppRoutingModule,
        DashboardModule],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
