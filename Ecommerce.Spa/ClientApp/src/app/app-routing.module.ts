import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./admin/home/home.component";
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
    path: "**",
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
