import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from "./core/not-found/not-found.component";

const routes: Routes = [
    {
        path: "",
        component: HomeComponent,
        children: [
            {
                path: "dashboard",
                loadChildren: "./admin/dashboard/dashboard.module#DashboardModule"
            }
        ]
    },
    {
        path: 'login',        
        loadChildren:'./login/login.module#LoginModule'        
    },
    {
        path: "**",
        component: NotFoundComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
