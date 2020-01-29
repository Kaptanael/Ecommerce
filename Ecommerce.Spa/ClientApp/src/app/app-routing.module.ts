import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./admin/home/home.component";
import { NotFoundComponent } from "./core/not-found/not-found.component";
import { LoginComponent } from './admin/login/login.component';

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
        //component: LoginComponent
        loadChildren:'./admin/login/login.module#LoginModule'        
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
