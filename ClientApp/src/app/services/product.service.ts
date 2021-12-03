import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import SaveProduct from "../models/requests/saveProduct";
import Product from "../models/responses/product";
import * as config from "../config/endpoints.json";

@Injectable()
export default class ProductService {
  private readonly ProductsEndpoint = config.productsEndpoint;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  createProduct(saveProduct: SaveProduct) {
    return this.http.post<Product>(
      `${this.baseUrl}${this.ProductsEndpoint}`,
      saveProduct
    );
  }
}
