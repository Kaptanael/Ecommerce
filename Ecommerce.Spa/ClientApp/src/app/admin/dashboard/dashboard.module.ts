import { RouterModule } from "@angular/router";
import { CoreModule } from "./../../core/core.module";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DashboardComponent } from "./dashboard.component";
import { DashboardRoutingModule } from "./dashboard.route";

@NgModule({
  declarations: [DashboardComponent],
  imports: [CommonModule, RouterModule, CoreModule, DashboardRoutingModule]
})
export class DashboardModule {}
