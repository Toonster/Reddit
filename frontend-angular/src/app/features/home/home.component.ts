import { ChangeDetectionStrategy, Component, inject, OnInit } from "@angular/core";
import { OidcSecurityService } from "angular-auth-oidc-client";
import { NgIf } from "@angular/common";
import { MatButtonModule } from "@angular/material/button";
import { rxResource } from "@angular/core/rxjs-interop";
import { PostsService } from "../../../api";

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
  readonly #postsService = inject(PostsService);
  readonly postsResource = rxResource({
    loader: () => this.#postsService.getApiV1Posts({}),
  });

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
}
