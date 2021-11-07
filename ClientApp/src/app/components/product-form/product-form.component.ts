import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import ProductService from "../../services/product.service";
import MerchantService from "../../services/merchant.service";
import SaveProduct from "../../models/requests/saveProduct";
import KeyValuePair from "../../models/responses/keyValuePair";

@Component({
  selector: "app-product-form",
  templateUrl: "./product-form.component.html",
})
export default class ProductFormComponent implements OnInit {
  merchantKeyValuePairs: KeyValuePair[];

  saveProduct: SaveProduct = {
    name: "",
    price: 0,
    unit: "",
    merchantId: 0,
  };

  constructor(
    private productService: ProductService,
    private merchantService: MerchantService,
    private router: Router
  ) {}

  ngOnInit() {
    this.populateMerchants();
  }

  submit() {
    this.productService.createProduct(this.saveProduct).subscribe();
    this.router.navigate(["/raktarkeszlet/"]);
  }

  populateMerchants() {
    this.merchantService
      .getMerchantKeyValuePairs()
      .subscribe((merchant) => (this.merchantKeyValuePairs = merchant));
  }
}
