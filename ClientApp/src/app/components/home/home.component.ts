import { Component } from "@angular/core";
import DateService from "./../../services/date.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
})
export default class HomeComponent {
  today: string;

  constructor(private dateService: DateService) {
    this.today = this.dateService.getCurrentDate();
  }
}
