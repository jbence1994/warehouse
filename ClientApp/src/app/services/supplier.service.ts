import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import Supplier from "./../models/supplier";
import SaveSupplier from "./../models/saveSupplier";

@Injectable()
export default class SupplierService {
  private readonly SuppliersEndpoint = "api/suppliers";

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getSuppliers() {
    return this.http.get<Supplier[]>(
      `${this.baseUrl}${this.SuppliersEndpoint}`
    );
  }

  createSupplier(supplier: SaveSupplier) {
    return this.http.post<Supplier>(
      `${this.baseUrl}${this.SuppliersEndpoint}`,
      supplier
    );
  }
}
