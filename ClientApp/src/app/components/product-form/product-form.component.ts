import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
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
    name: "",
    price: 0,
    unit: "",
    supplierId: 0,
  };

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit() {
    this.populateSuppliers();
  }

  submit() {
    this.productService.createProduct(this.saveProduct).subscribe();
    this.router.navigate(["/termeklista/"]);
  }

  populateSuppliers() {
    this.productService
      .getSupplierKeyValuePairs()
      .subscribe((suppliers) => (this.suppliers = suppliers));
  }
}
