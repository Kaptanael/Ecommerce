import { NgModule } from "@angular/core";
import { CoreModule } from "./../../core/core.module";

import { DashboardComponent } from "./dashboard.component";
import { DashboardRoutingModule } from "./dashboard.route";

@NgModule({
  declarations: [DashboardComponent],
  imports: [CoreModule, DashboardRoutingModule]
})
export class DashboardModule {}
