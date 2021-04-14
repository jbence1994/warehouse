import { SaveProduct } from './../models/saveProduct';
import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";

export class ProductService {

    private readonly ProductsEndpoint = 'api/products';

    constructor(private http: HttpClient,
                @Inject('BASE_URL') private baseUrl: string) { }

    createProduct(saveProduct: SaveProduct) {
        return this.http.post<SaveProduct>(`${this.ProductsEndpoint}`, saveProduct);
    }
}
