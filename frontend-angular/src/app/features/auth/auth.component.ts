import { Component, inject, OnInit } from "@angular/core";
import { UsersService } from "../../../api";
import { OidcSecurityService } from "angular-auth-oidc-client";
import { filter, switchMap, tap } from "rxjs";
import { AuthService } from "../../auth/services/auth.service";
import { Guid } from "guid-typescript";

@Component({
  selector: "app-auth",
  imports: [],
  templateUrl: "./auth.component.html",
  styleUrl: "./auth.component.css",
})
export class AuthComponent implements OnInit {
  readonly #securityService = inject(OidcSecurityService);
  userData$ = this.#securityService.userData$;
  readonly #userService = inject(UsersService);
  readonly #authService = inject(AuthService);

  ngOnInit(): void {
    this.userData$
      .pipe(
        tap((data) => console.log(data)),
        filter(({ userData }) => !!userData.email),
        switchMap(({ userData }) =>
          this.#userService.getApiV1Users({ email: userData.email }).pipe(
            tap(({ data: getUserResult }) => {
              if (getUserResult && getUserResult.email) {
                this.#authService.setUser(getUserResult);
              } else {
                this.createUser(userData.email);
              }
            }),
          ),
        ),
      )
      .subscribe({
        next: () => console.log("User check and setup complete"),
        error: (err) => console.error("Error checking user:", err),
      });
  }

  private createUser(email: string): void {
    const newUser = { id: Guid.create().toString(), email, username: email };
    this.#userService
      .postApiV1Users(newUser)
      .pipe(
        filter((result) => result.isSuccess || false),
        switchMap(() =>
          this.#userService.getApiV1Users({ email: email }).pipe(
            filter(({ data }) => !!data),
            tap(({ data: user }) => this.#authService.setUser(user!)),
          ),
        ),
      )
      .subscribe({
        next: () => console.log("User successfully created and retrieved."),
        error: (err) => console.error("Error during user creation or retrieval:", err),
      });
  }
}
