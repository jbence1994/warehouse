import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import SaveStockEntry from "../models/saveStockEntry";

@Injectable()
export default class StockService {
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getStocks() {
    return [];
  }

  createStockEntry(saveStockEntry: SaveStockEntry) {
    return [];
  }

  getSuppliersKeyValuePairWithProductKeyValuePairs() {
    return [];
  }
}
