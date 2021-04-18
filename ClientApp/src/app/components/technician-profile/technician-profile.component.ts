import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { TechnicianService } from 'src/app/services/technician.service';
import { Technician } from "src/app/models/technician";

@Component({
    selector: 'app-technician-profile',
    templateUrl: './technician-profile.component.html',
    styleUrls: ['./technician-profile.component.css']
})
export class TechnicianProfileComponent implements OnInit {
    technician: Technician = {
        id: 0,
        firstName: null,
        lastName: null,
        email: null,
        phone: null,
    };

    technicianId: number;

    constructor(
        private technicianService: TechnicianService,
        private route: ActivatedRoute,
        private router: Router
    ) {
        this.route.params.subscribe(p => {
            this.technicianId = +p['id'];

            if (isNaN(this.technicianId) || this.technicianId <= 0) {
              this.router.navigate(['/technikus-info']);
              return; 
            }
        });
    }

    ngOnInit() {
        this.technicianService.getTechnician(this.technicianId)
            .subscribe(technician => this.technician = technician);
    }
}
