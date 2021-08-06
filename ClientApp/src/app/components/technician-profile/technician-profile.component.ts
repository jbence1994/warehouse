import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import TechnicianService from "src/app/services/technician.service";
import PhotoService from "src/app/services/photo.service";
import Technician from "src/app/models/technician";
import Photo from "src/app/models/photo";
import Order from "src/app/models/order";

@Component({
  selector: "app-technician-profile",
  templateUrl: "./technician-profile.component.html",
  styleUrls: ["./technician-profile.component.css"],
})
export default class TechnicianProfileComponent implements OnInit {
  technician: Technician = {
    id: 0,
    firstName: null,
    lastName: null,
    email: null,
    phone: null,
    balance: 0,
  };

  @ViewChild("fileInput", { read: "", static: true }) fileInput: ElementRef;
  technicianId: number;
  photos: Photo[];
  orders: Order[];

  constructor(
    private technicianService: TechnicianService,
    private photoService: PhotoService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.route.params.subscribe((p) => {
      this.technicianId = +p["id"];

      if (isNaN(this.technicianId) || this.technicianId <= 0) {
        this.router.navigate(["/technikus-info"]);
        return;
      }
    });
  }

  ngOnInit() {
    this.populatePhotos();
    this.populateTechnician();
    this.populateOrders();
  }

  uploadPhoto() {
    let nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    let file = nativeElement.files[0];
    nativeElement.value = "";

    this.photoService.uploadTechnicianPhoto(this.technicianId, file);
  }

  populatePhotos() {
    this.photos = this.photoService.getTechnicianPhotos(this.technicianId);
  }

  populateTechnician() {
    this.technician = this.technicianService.getTechnician(this.technicianId);
  }

  populateOrders() {
    this.orders = this.technicianService.getTechnicianOrders(this.technicianId);
  }
}
