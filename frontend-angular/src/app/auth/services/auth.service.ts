import { BehaviorSubject, Observable } from "rxjs";
import { User } from "../../../api";

export class AuthService {
  private user$ = new BehaviorSubject<User | null>(null);

  getUser(): Observable<User | null> {
    return this.user$.asObservable();
  }

  setUser(user: User | null) {
    this.user$.next(user);
  }
}
