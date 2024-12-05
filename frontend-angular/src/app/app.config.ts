import { ApplicationConfig, provideZoneChangeDetection } from "@angular/core";
import { provideRouter } from "@angular/router";

import { routes } from "./app.routes";
import { authConfig } from "./auth/auth.config";
import { authInterceptor, provideAuth, withAppInitializerAuthCheck } from "angular-auth-oidc-client";
import { provideHttpClient, withInterceptors, withInterceptorsFromDi } from "@angular/common/http";
import { provideAnimationsAsync } from "@angular/platform-browser/animations/async";

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(withInterceptorsFromDi(), withInterceptors([authInterceptor()])),
    provideAuth(authConfig, withAppInitializerAuthCheck()),
    provideAnimationsAsync(),
  ],
};
