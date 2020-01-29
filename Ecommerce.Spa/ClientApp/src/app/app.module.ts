import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";

import { HomeComponent } from "./admin/home/home.component";
import { NotFoundComponent } from "./core/not-found/not-found.component";
import { DashboardModule } from './admin/dashboard/dashboard.module';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [AppComponent, HomeComponent, NotFoundComponent],
    imports: [BrowserModule, HttpClientModule, CommonModule, RouterModule, AppRoutingModule, DashboardModule],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
