import { Component, OnInit } from "@angular/core";
import { TechnicianService } from "src/app/services/technician.service";
import { Technician } from "src/app/models/technician";

@Component({
  selector: "app-technicians-table",
  templateUrl: "./technicians-table.component.html",
})
export class TechniciansTableComponent implements OnInit {
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
