import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { AdminHeaderComponent } from "./admin-header/admin-header.component";
import { AdminSidebarComponent } from "./admin-sidebar/admin-sidebar.component";
import { AdminFooterComponent } from "./admin-footer/admin-footer.component";

@NgModule({
  imports: [CommonModule, RouterModule],
  declarations: [
    AdminHeaderComponent,
    AdminSidebarComponent,
    AdminFooterComponent
  ]
})
export class CoreModule {}
