import { DateService } from "./../../services/date.service";
import { Component } from "@angular/core";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
})
export class HomeComponent {
  today: string;

  constructor(private dateService: DateService) {
    this.today = this.dateService.getCurrentDate();
  }
}
