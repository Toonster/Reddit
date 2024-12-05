import { Component } from "@angular/core";
import { RouterLink, RouterOutlet } from "@angular/router";
import { MatButton } from "@angular/material/button";
import { MatToolbar } from "@angular/material/toolbar";

@Component({
  selector: "app-root",
  imports: [RouterOutlet, MatButton, RouterLink, MatToolbar],
  templateUrl: "./app.component.html",
  styleUrl: "./app.component.css",
})
export class AppComponent {
  title = "frontend-angular";
}
