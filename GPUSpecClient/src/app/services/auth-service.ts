import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, tap, Observable } from 'rxjs';
import { environment } from './../../environments/environment';
import { LoginResult } from '../interfaces/auth/login-result';
import { LoginRequest } from '../interfaces/auth/login-request';
import { UserPayload } from '../interfaces/auth/user-payload';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private tokenKey: string = 'token';

  private _authStatus = new BehaviorSubject<boolean>(false);
  public authStatus = this._authStatus.asObservable();

  private _user = new BehaviorSubject<UserPayload | null>(null);
  public user = this._user.asObservable();

  constructor(protected http: HttpClient) {}

  isAuthenticated(): boolean {
    return this.getToken() !== null;
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  init(): void {
    if (this.isAuthenticated()) {
      this.setAuthStatus(true);
      const token = this.getToken();
      if (token) {
        const decoded = jwtDecode<UserPayload>(token);
        this._user.next(decoded);
      }
    }
  }

  login(item: LoginRequest): Observable<LoginResult> {
    var url = `${environment.baseUrl}api/Account/Login`;
    return this.http.post<LoginResult>(url, item).pipe(
      tap((loginResult) => {
        if (loginResult.success && loginResult.token) {
          this.setAuthStatus(true);
          localStorage.setItem(this.tokenKey, loginResult.token);
          const decoded = jwtDecode<UserPayload>(loginResult.token);
          this._user.next(decoded);
        }
      })
    );
  }

  logout() {
    this.setAuthStatus(false);
    localStorage.removeItem(this.tokenKey);
    this._user.next(null);
  }

  private setAuthStatus(isAuthenticated: boolean): void {
    this._authStatus.next(isAuthenticated);
  }
}
