import { Router } from "@angular/router";
import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ProductService } from "src/app/services/product.service";
import { PhotoService } from "./../../services/photo.service";
import { Product } from "src/app/models/product";
import { Photo } from "src/app/models/photo";

@Component({
  selector: "app-view-product",
  templateUrl: "./view-product.component.html",
  styleUrls: ["./view-product.component.css"],
})
export class ViewProductComponent implements OnInit {
  product: Product = {
    id: 0,
    name: null,
    price: 0,
    unit: null,
    supplierName: null,
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
    this.photoService
      .getProductPhotos(this.productId)
      .subscribe((photos) => (this.photos = photos));

    this.productService
      .getProduct(this.productId)
      .subscribe((product) => (this.product = product));
  }

  uploadPhoto() {
    let nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    let file = nativeElement.files[0];
    nativeElement.value = "";

    this.photoService
      .uploadProductPhoto(this.productId, file)
      .subscribe((photo) => this.photos.push(photo));
  }
}
