import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import Stock from "../models/stock";
import SaveStockEntry from "../models/saveStockEntry";
import SupplierKeyValuePairWithProductKeyValuePairs from "../models/supplierKeyValuePairWithProductKeyValuePairs";

@Injectable()
export default class StockService {
  private readonly StocksEndpoint = "api/stocks";
  private readonly SupplierKeyValuePairsWithProductKeyValuePairsEndpoint =
    "api/suppliers/supplierKeyValuePairsWithProductKeyValuePairs";

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getStocks() {
    return this.http.get<Stock[]>(`${this.baseUrl}${this.StocksEndpoint}`);
  }

  createStockEntry(saveStockEntry: SaveStockEntry) {
    return this.http.post<Stock>(
      `${this.baseUrl}${this.StocksEndpoint}`,
      saveStockEntry
    );
  }

  getSuppliersKeyValuePairWithProductKeyValuePairs() {
    return this.http.get<SupplierKeyValuePairWithProductKeyValuePairs[]>(
      `${this.baseUrl}${this.SupplierKeyValuePairsWithProductKeyValuePairsEndpoint}`
    );
  }
}
