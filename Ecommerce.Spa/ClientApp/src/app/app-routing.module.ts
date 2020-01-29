import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AuthGuard } from './core/guards/auth.guard';

import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from "./core/not-found/not-found.component";

const routes: Routes = [
    {
        path: "",
        component: HomeComponent,
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {
                path: "dashboard",
                loadChildren: "./admin/dashboard/dashboard.module#DashboardModule"
            },
            {
                path: "menu",
                loadChildren: "./admin/menu/menu.module#MenuModule"
            },
            {
                path: "category",
                loadChildren: "./admin/category/category.module#CategoryModule"
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
