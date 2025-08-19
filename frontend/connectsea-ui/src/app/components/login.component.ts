import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
@Component({
  selector: 'app-login',
  template: `
    <div>
      <h3>Login</h3>
      <form (ngSubmit)='doLogin()'>
        <input [(ngModel)]='username' name='username' placeholder='username' />
        <input [(ngModel)]='password' name='password' placeholder='password' type='password' />
        <button type='submit'>Login</button>
      </form>
      <div *ngIf='message'>{{message}}</div>
    </div>
  `
})
export class LoginComponent {
  username = 'admin';
  password = 'Demo@123';
  message = '';
  constructor(private auth: AuthService) {}
  doLogin() {
    this.auth.login(this.username, this.password).then(() => this.message = 'Logged in (token stored)').catch(e => this.message = 'Login failed');
  }
}
