import { Component } from '@angular/core';
@Component({
  selector: 'app-root',
  template: `
    <div style="font-family: Arial, sans-serif; padding: 20px; max-width:900px; margin:auto;">
      <h1>ConnectSea Demo</h1>
      <app-login></app-login>
      <hr/>
      <app-ships-list></app-ships-list>
      <hr/>
      <app-schedules-list></app-schedules-list>
    </div>
  `
})
export class AppComponent {}
