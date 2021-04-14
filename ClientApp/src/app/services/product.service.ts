import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { SaveProduct } from './../models/saveProduct';
import { KeyValuePair } from './../models/keyValuePair';

export class ProductService {

    private readonly ProductsEndpoint = 'api/products';
    private readonly SuppliersEndpoint = 'api/suppliers';

    constructor(private http: HttpClient,
                @Inject('BASE_URL') private baseUrl: string) { }

    createProduct(saveProduct: SaveProduct) {
        return this.http.post<SaveProduct>(`${this.ProductsEndpoint}`, saveProduct);
    }

    getSuppliers() {
        return this.http.get<KeyValuePair[]>(`${this.SuppliersEndpoint}`);
    }
}
