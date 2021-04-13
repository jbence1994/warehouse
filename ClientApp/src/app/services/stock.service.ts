import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { Stock } from "../models/stock";
import { SaveStock } from './../models/saveStock';
import { Supplier } from './../models/supplier';

export class StockService {

    private readonly StocksEndpoint = 'api/stocks';
    private readonly SuppliersEndpoint = 'api/suppliers';

    constructor(private http: HttpClient,
                @Inject('BASE_URL') private baseUrl: string) { }

    getStocks() {
        return this.http.get<Stock[]>(`${this.baseUrl}${this.StocksEndpoint}`);
    }

    createStock(saveStock: SaveStock) {
        return this.http.post<SaveStock>(`${this.StocksEndpoint}`, saveStock);
    }

    getSuppliers() {
        return this.http.get<Supplier[]>(`${this.baseUrl}${this.SuppliersEndpoint}`);
    }
}
