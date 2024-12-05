import { Component, inject, OnInit } from "@angular/core";
import { OidcSecurityService } from "angular-auth-oidc-client";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-community",
  imports: [],
  templateUrl: "./community.component.html",
  styleUrl: "./community.component.css",
})
export class CommunityComponent implements OnInit {
  isAuthenticated = false;
  subreddit!: string;
  readonly #securityService = inject(OidcSecurityService);
  readonly #route = inject(ActivatedRoute);

  ngOnInit(): void {
    this.#securityService.isAuthenticated$.subscribe(({ isAuthenticated }) => {
      this.isAuthenticated = isAuthenticated;
      console.warn("authenticated: ", isAuthenticated);
    });
    this.#route.paramMap.subscribe((paramMap) => {
      this.subreddit = paramMap.get("community") || "unknown";
    });
  }
}
