import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import Product from "./../models/product";
import SaveProduct from "./../models/saveProduct";

@Injectable()
export default class ProductService {
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getProducts() {
    return [];
  }

  getProduct(id: number): Product {
    return {
      id: 0,
      name: "",
      price: 0,
      unit: "",
      supplierName: "",
    };
  }

  createProduct(saveProduct: SaveProduct) {
    return [];
  }

  getSupplierKeyValuePairs() {
    return [];
  }
}
