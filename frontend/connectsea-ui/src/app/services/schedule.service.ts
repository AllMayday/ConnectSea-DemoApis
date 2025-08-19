import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({providedIn: 'root'})
export class ScheduleService {
  constructor(private http: HttpClient) {}
  list() { return this.http.get<any[]>('/api/schedules'); }
}
