import { Component, OnInit } from "@angular/core";
import ProductService from "src/app/services/product.service";
import Product from "src/app/models/product";

@Component({
  selector: "app-product-table",
  templateUrl: "./product-table.component.html",
})
export default class ProductTableComponent implements OnInit {
  products: Product[];

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.populateProducts();
  }

  populateProducts() {
    this.productService
      .getProducts()
      .subscribe((products) => (this.products = products));
  }
}
