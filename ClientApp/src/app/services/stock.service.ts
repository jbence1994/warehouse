import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { Stock } from "../models/stock";
import { SaveStock } from './../models/saveStock';
import { SupplierWithProducts } from '../models/supplierWithProducts';

export class StockService {

    private readonly StocksEndpoint = 'api/stocks';
    private readonly SuppliersWithProductsEndpoint = 'api/suppliers/suppliersWithProducts';

    constructor(private http: HttpClient,
                @Inject('BASE_URL') private baseUrl: string) { }

    getStocks() {
        return this.http.get<Stock[]>(`${this.baseUrl}${this.StocksEndpoint}`);
    }

    createStock(saveStock: SaveStock) {
        return this.http.post<SaveStock>(`${this.baseUrl}${this.StocksEndpoint}`, saveStock);
    }

    getSuppliers() {
        return this.http.get<SupplierWithProducts[]>(`${this.baseUrl}${this.SuppliersWithProductsEndpoint}`);
    }
}
