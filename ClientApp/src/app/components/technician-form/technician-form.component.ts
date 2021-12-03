import { Component } from "@angular/core";
import TechnicianService from "../../services/technician.service";
import SaveTechnician from "../../models/requests/saveTechnician";

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
    this.technicianService.createTechnician(this.saveTechnician).subscribe();
  }
}
