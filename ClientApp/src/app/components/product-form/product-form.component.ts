import { KeyValuePair } from "./../../models/keyValuePair";
import { ProductService } from "./../../services/product.service";
import { Component, OnInit } from "@angular/core";
import { SaveProduct } from "src/app/models/saveProduct";

@Component({
  selector: "app-product-form",
  templateUrl: "./product-form.component.html",
})
export class ProductFormComponent implements OnInit {
  suppliers: KeyValuePair[];

  saveProduct: SaveProduct = {
    name: null,
    price: 0,
    unit: null,
    supplierId: 0,
  };

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.populateSuppliers();
  }

  submit() {
    console.log("POST request to REST API ...");
  }

  populateSuppliers() {
    this.productService
      .getSupplierKeyValuePairs()
      .subscribe((suppliers) => (this.suppliers = suppliers));
  }
}
