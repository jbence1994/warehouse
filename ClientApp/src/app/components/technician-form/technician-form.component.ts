import { Component, OnInit } from "@angular/core";
import { SaveTechnician } from "./../../models/saveTechnician";

@Component({
  selector: "app-technician-form",
  templateUrl: "./technician-form.component.html",
})
export class TechnicianFormComponent {
  saveTechnician: SaveTechnician = {
    lastName: "",
    firstName: "",
    email: "",
    phone: "",
  };

  submit() {
    console.log("POST request to REST API ...");
  }
}
