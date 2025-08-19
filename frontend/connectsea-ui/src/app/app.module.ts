import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login.component';
import { ShipsListComponent } from './components/ships-list.component';
import { SchedulesListComponent } from './components/schedules-list.component';
import { AuthService } from './services/auth.service';
import { ShipService } from './services/ship.service';
import { ScheduleService } from './services/schedule.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ShipsListComponent,
    SchedulesListComponent
  ],
  imports: [ BrowserModule, HttpClientModule, FormsModule ],
  providers: [AuthService, ShipService, ScheduleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
