import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import TechnicianService from "../../services/technician.service";
import PhotoService from "../../services/photo.service";
import Technician from "../../models/responses/technician";
import Photo from "../../models/responses/photo";
import Order from "../../models/responses/order";

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
    this.populateSales();
  }

  uploadPhoto() {
    let nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    let file = nativeElement.files[0];
    nativeElement.value = "";

    this.photoService
      .uploadTechnicianPhoto(this.technicianId, file)
      .subscribe((photo) => this.photos.push(photo));
  }

  populatePhotos() {
    this.photoService
      .getTechnicianPhotos(this.technicianId)
      .subscribe((photos) => (this.photos = photos));
  }

  populateTechnician() {
    this.technicianService
      .getTechnician(this.technicianId)
      .subscribe((technician) => (this.technician = technician));
  }

  populateSales() {
    this.technicianService
      .getTechnicianOrders(this.technicianId)
      .subscribe((orders) => (this.orders = orders));
  }
}
