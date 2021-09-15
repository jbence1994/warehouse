import { Component, OnInit } from "@angular/core";
import ProductService from "src/app/services/product.service";
import PhotoService from "../../services/photo.service";
import Product from "src/app/models/product";
import Photo from "../../models/photo";

@Component({
  selector: "app-product-table",
  templateUrl: "./product-table.component.html",
})
export default class ProductTableComponent implements OnInit {
  products: Product[];
  photos: Photo[];

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
}
