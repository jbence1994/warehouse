import { Component, OnInit } from "@angular/core";
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
  products: Product[];
  photos: ProductPhoto[];

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
      .subscribe((photos) => (this.photos = photos));
  }

  uploadPhoto() {}
}