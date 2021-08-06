import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import SaveSupplier from "./../models/saveSupplier";

@Injectable()
export default class SupplierService {
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getSuppliers() {
    return [];
  }

  createSupplier(supplier: SaveSupplier) {
    return [];
  }
}
