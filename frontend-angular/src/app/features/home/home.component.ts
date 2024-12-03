import { ChangeDetectionStrategy, Component, inject, OnInit } from "@angular/core";
import { OidcSecurityService } from "angular-auth-oidc-client";
import { NgIf } from "@angular/common";
import { MatButtonModule } from "@angular/material/button";

@Component({
  selector: "app-home",
  imports: [NgIf, MatButtonModule],
  templateUrl: "./home.component.html",
  styleUrl: "./home.component.css",
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomeComponent implements OnInit {
  isAuthenticated = false;
  readonly #securityService = inject(OidcSecurityService);
  readonly configuration$ = this.#securityService.getConfiguration();
  readonly userData$ = this.#securityService.getUserData();

  ngOnInit(): void {
    this.#securityService.isAuthenticated$.subscribe(({ isAuthenticated }) => {
      this.isAuthenticated = isAuthenticated;
      console.warn("authenticated: ", isAuthenticated);
    });
  }

  login(): void {
    this.#securityService.authorize();
  }

  logout(): void {
    this.#securityService.logoff();
  }

  /*  readonly postsResource = rxResource({
      loader: () => this.#securityService.getApiV1Posts(),
    });*/
}
