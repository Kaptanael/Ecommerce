import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";

import { AdminHeaderComponent } from "./admin-header/admin-header.component";
import { AdminSidebarComponent } from "./admin-sidebar/admin-sidebar.component";
import { AdminFooterComponent } from "./admin-footer/admin-footer.component";
import { AuthService } from './services/auth.service';
import { AuthGuard } from './guards/auth.guard';

@NgModule({
    imports: [
        CommonModule,
        RouterModule],
    declarations: [
        AdminHeaderComponent,
        AdminSidebarComponent,
        AdminFooterComponent
    ],
    providers: [
        AuthService,
        AuthGuard
    ],
    exports: [
        AdminHeaderComponent,
        AdminSidebarComponent,
        AdminFooterComponent
    ]
})
export class CoreModule { }
