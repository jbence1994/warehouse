import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import Supply from "../models/responses/supply";
import SaveSupplyEntry from "../models/requests/saveSupplyEntry";
import * as config from "../config/endpoints.json";

@Injectable()
export default class SupplyService {
  private readonly SuppliesEndpoint = config.suppliesEndpoint;
  private readonly MerchantKeyValuePairsWithProductKeyValuePairsEndpoint =
    config.merchantKeyValuePairsWithProductKeyValuePairsEndpoint;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getSupplies() {
    return this.http.get<Supply[]>(`${this.baseUrl}${this.SuppliesEndpoint}`);
  }

  createStockEntry(saveSupplyEntry: SaveSupplyEntry) {
    return this.http.post<Supply>(
      `${this.baseUrl}${this.SuppliesEndpoint}`,
      saveSupplyEntry
    );
  }
}
