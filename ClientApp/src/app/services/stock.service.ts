import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { Stock } from "../models/stock";

export class StockService {

    private readonly StocksEndpoint = 'api/stocks';

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    getStocks() {
        return this.http.get<Stock[]>(`${this.baseUrl}${this.StocksEndpoint}`);
    }
}
