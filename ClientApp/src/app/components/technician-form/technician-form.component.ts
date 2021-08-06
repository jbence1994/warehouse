import { Component } from "@angular/core";
import TechnicianService from "src/app/services/technician.service";
import SaveTechnician from "./../../models/saveTechnician";

@Component({
  selector: "app-technician-form",
  templateUrl: "./technician-form.component.html",
})
export default class TechnicianFormComponent {
  saveTechnician: SaveTechnician = {
    lastName: "",
    firstName: "",
    email: "",
    phone: "",
  };

  constructor(private technicianService: TechnicianService) {}

  submit() {
    this.technicianService.createTechnician(this.saveTechnician);
  }
}
