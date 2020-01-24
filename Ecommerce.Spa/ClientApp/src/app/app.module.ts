import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminHeaderComponent } from './admin-header/admin-header.component';
import { AdminFooterComponent } from './core/admin-footer/admin-footer.component';
import { AdminSidebarComponent } from './core/admin-sidebar/admin-sidebar.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminHeaderComponent,
    AdminFooterComponent,
    AdminSidebarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
