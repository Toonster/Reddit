import { Routes } from "@angular/router";
import { HomeComponent } from "./features/home/home.component";
import { AuthComponent } from "./features/auth/auth.component";

export const routes: Routes = [
  {
    path: "",
    redirectTo: "home",
    pathMatch: "full",
  },
  {
    path: "home",
    title: "App Home Page",
    component: HomeComponent,
  },
  {
    path: "auth",
    title: "Auth Page",
    component: AuthComponent,
  },
];
