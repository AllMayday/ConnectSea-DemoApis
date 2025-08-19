import { Component, OnInit } from '@angular/core';
import { ScheduleService } from '../services/schedule.service';
@Component({
  selector: 'app-schedules-list',
  template: `
    <div>
      <h3>Schedules (next days)</h3>
      <ul>
        <li *ngFor='let s of schedules'>Ship: {{s.ship?.name}} — Berth: {{s.berth?.name}} — {{s.arrival | date:'short'}} to {{s.departure | date:'short'}}</li>
      </ul>
    </div>
  `
})
export class SchedulesListComponent implements OnInit {
  schedules: any[] = [];
  constructor(private svc: ScheduleService) {}
  ngOnInit() { this.svc.list().subscribe(r => this.schedules = r); }
}
