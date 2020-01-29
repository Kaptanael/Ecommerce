import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";

import { HomeComponent } from "./admin/home/home.component";
import { NotFoundComponent } from "./core/not-found/not-found.component";

@NgModule({
    declarations: [AppComponent, HomeComponent, NotFoundComponent],
  imports: [BrowserModule, CommonModule, RouterModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
