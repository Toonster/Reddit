import { ChangeDetectionStrategy, Component, inject } from "@angular/core";
import { PostsService } from "../../../api";
import { rxResource } from "@angular/core/rxjs-interop";

@Component({
  selector: "app-home",
  imports: [],
  templateUrl: "./home.component.html",
  styleUrl: "./home.component.css",
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HomeComponent {
  readonly #postsService = inject(PostsService);

  readonly postsResource = rxResource({
    loader: () => this.#postsService.getApiV1Posts(),
  });
}
