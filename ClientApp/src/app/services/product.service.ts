import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { SaveProduct } from "./../models/saveProduct";
import { KeyValuePair } from "./../models/keyValuePair";
import { Product } from "../models/product";

@Injectable()
export class ProductService {
  private readonly ProductsEndpoint = "api/products";
  private readonly SuppliersEndpoint = "api/suppliers/supplierKeyValuePairs";

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getProducts() {
    return this.http.get<Product[]>(`${this.baseUrl}${this.ProductsEndpoint}`);
  }

  getProduct(id: number) {
    return this.http.get<Product>(
      `${this.baseUrl}${this.ProductsEndpoint}/${id}`
    );
  }

  createProduct(saveProduct: SaveProduct) {
    return this.http.post<Product>(
      `${this.baseUrl}${this.ProductsEndpoint}`,
      saveProduct
    );
  }

  getSupplierKeyValuePairs() {
    return this.http.get<KeyValuePair[]>(
      `${this.baseUrl}${this.SuppliersEndpoint}`
    );
  }
}
