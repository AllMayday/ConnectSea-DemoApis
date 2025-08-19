import { Component, OnInit } from '@angular/core';
import { ShipService } from '../services/ship.service';
@Component({
  selector: 'app-ships-list',
  template: `
    <div>
      <h3>Ships</h3>
      <ul>
        <li *ngFor='let s of ships'>{{s.name}} ({{s.imo}})</li>
      </ul>
    </div>
  `
})
export class ShipsListComponent implements OnInit {
  ships: any[] = [];
  constructor(private svc: ShipService) {}
  ngOnInit() { this.svc.list().subscribe(r => this.ships = r); }
}
