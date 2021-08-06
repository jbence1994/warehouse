import { Component, OnInit } from "@angular/core";
import ProductService from "./../../services/product.service";
import SaveProduct from "src/app/models/saveProduct";
import KeyValuePair from "./../../models/keyValuePair";

@Component({
  selector: "app-product-form",
  templateUrl: "./product-form.component.html",
})
export default class ProductFormComponent implements OnInit {
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
    this.suppliers = this.productService.getSupplierKeyValuePairs();
  }
}
