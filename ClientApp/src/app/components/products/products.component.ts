import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import ProductService from "src/app/services/product.service";
import PhotoService from "../../services/photo.service";
import Product from "src/app/models/product";
import ProductPhoto from "../../models/productPhoto";

@Component({
  selector: "app-products",
  templateUrl: "./products.component.html",
  styleUrls: ["./products.component.css"],
})
export default class Products implements OnInit {
  @ViewChild("fileInput", { read: "", static: true }) fileInput: ElementRef;
  products: Product[];
  productPhotos: ProductPhoto[];

  constructor(
    private productService: ProductService,
    private photoService: PhotoService
  ) {}

  ngOnInit() {
    this.populateProducts();
    this.populatePhotos();
  }

  populateProducts() {
    this.productService
      .getProducts()
      .subscribe((products) => (this.products = products));
  }

  populatePhotos() {
    this.photoService
      .getProductPhotos()
      .subscribe((productPhotos) => (this.productPhotos = productPhotos));
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
