import { Routes } from "@angular/router";
import { HomeComponent } from "./features/home/home.component";
import { AuthComponent } from "./features/auth/auth.component";
import { environment } from "../environments/environment";
import { CommunityComponent } from "./features/community/community.component";
import { UnauthorizedComponent } from "./features/unauthorized/unauthorized.component";

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
    path: "r/:community",
    title: "App Community Page",
    component: CommunityComponent,
  },
  {
    path: "auth",
    title: "Auth Page",
    component: AuthComponent,
  },
  {
    path: "unauthorized",
    title: "Unauthorized Page",
    component: UnauthorizedComponent,
  },
];

export const secureApiEndpoints: string[] = [`${environment.apiUrl}/api/v1/posts`];
