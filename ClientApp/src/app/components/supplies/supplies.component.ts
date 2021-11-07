import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import ProductService from "../../services/product.service";
import PhotoService from "../../services/photo.service";
import SupplyService from "../../services/supply.service";
import ProductPhoto from "../../models/responses/productPhoto";
import Supply from "../../models/responses/supply";

@Component({
  selector: "app-supplies",
  templateUrl: "./supplies.component.html",
  styleUrls: ["./supplies.component.css"],
})
export default class SuppliesComponent implements OnInit {
  @ViewChild("fileInput", { read: "", static: true }) fileInput: ElementRef;
  supplies: Supply[];
  productPhotos: ProductPhoto[];

  constructor(
    private productService: ProductService,
    private photoService: PhotoService,
    private supplyService: SupplyService
  ) {}

  ngOnInit() {
    this.populateProductPhotos();
    this.populateSupplies();
  }

  populateProductPhotos() {
    this.photoService
      .getProductPhotos()
      .subscribe((productPhotos) => (this.productPhotos = productPhotos));
  }

  populateSupplies() {
    this.supplyService
      .getSupplies()
      .subscribe((supplies) => (this.supplies = supplies));
  }

  uploadProductPhoto(productId: number) {
    let nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    let file = nativeElement.files[0];

    nativeElement.value = "";

    this.photoService
      .uploadProductPhoto(productId, file)
      .subscribe((productPhoto) => this.productPhotos.push(productPhoto));
  }
}
