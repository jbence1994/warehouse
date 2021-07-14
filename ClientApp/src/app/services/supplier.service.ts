import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Supplier } from "./../models/supplier";

@Injectable()
export class SupplierService {
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
}
