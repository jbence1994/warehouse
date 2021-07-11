import { Injectable } from "@angular/core";

@Injectable()
export class DateService {
  getCurrentDate(): string {
    return new Date().toLocaleDateString("hu-HU", {
      year: "numeric",
      month: "long",
      day: "numeric",
      weekday: "long",
    });
  }
}
