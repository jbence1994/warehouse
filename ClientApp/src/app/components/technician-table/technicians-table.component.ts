import { Component, OnInit } from "@angular/core";
import TechnicianService from "../../services/technician.service";
import Technician from "../../models/responses/technician";

@Component({
  selector: "app-technicians-table",
  templateUrl: "./technicians-table.component.html",
})
export default class TechniciansTableComponent implements OnInit {
  technicians: Technician[];

  constructor(private technicianService: TechnicianService) {}

  ngOnInit() {
    this.populateTechnicians();
  }

  populateTechnicians() {
    this.technicianService
      .getTechnicians()
      .subscribe((technicians) => (this.technicians = technicians));
  }
}
