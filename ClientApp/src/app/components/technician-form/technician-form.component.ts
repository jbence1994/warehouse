import { Component, OnInit } from "@angular/core";
import { SaveTechnician } from "./../../models/saveTechnician";

@Component({
  selector: "app-technician-form",
  templateUrl: "./technician-form.component.html",
})
export class TechnicianFormComponent implements OnInit {
  saveTechnician: SaveTechnician = {
    lastName: "",
    firstName: "",
    email: "",
    phone: "",
  };

  constructor() {}

  ngOnInit() {}

  submit() {
    console.log("POST request to REST API ...");
  }
}
