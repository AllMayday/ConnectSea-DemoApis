import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({providedIn: 'root'})
export class AuthService {
  token: string | null = null;
  constructor(private http: HttpClient) {}
  login(username: string, password: string) {
    return this.http.post<any>('/api/auth/login', { username, password }).toPromise().then(r => { this.token = r.token; return r; });
  }
}
