import { Router } from "@angular/router";
import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import ProductService from "src/app/services/product.service";
import PhotoService from "./../../services/photo.service";
import Product from "src/app/models/product";
import Photo from "src/app/models/photo";

@Component({
  selector: "app-view-product",
  templateUrl: "./view-product.component.html",
  styleUrls: ["./view-product.component.css"],
})
export default class ViewProductComponent implements OnInit {
  product: Product = {
    id: 0,
    name: "",
    price: 0,
    unit: "",
    supplierName: "",
  };

  @ViewChild("fileInput", { read: "", static: true }) fileInput: ElementRef;
  productId: number;
  photos: Photo[];

  constructor(
    private productService: ProductService,
    private photoService: PhotoService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.route.params.subscribe((p) => {
      this.productId = +p["id"];

      if (isNaN(this.productId) || this.productId <= 0) {
        this.router.navigate(["/termeklista"]);
        return;
      }
    });
  }

  ngOnInit() {
    this.photos = this.photoService.getProductPhotos(this.productId);

    this.product = this.productService.getProduct(this.productId);
  }

  uploadPhoto() {
    let nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    let file = nativeElement.files[0];
    nativeElement.value = "";
    this.photos.push(
      this.photoService.uploadProductPhoto(this.productId, file)
    );
  }
}
