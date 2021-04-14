import { ProductService } from './../../services/product.service';
import { Component } from "@angular/core";
import { SaveProduct } from "src/app/models/saveProduct";

@Component({
    selector: 'app-product-form',
    templateUrl: './product-form.component.html'
})
export class ProductFormComponent {
    
    saveProduct: SaveProduct = {
        name: null,
        price: 0,
        unit: null,
        supplierId: 0
    };

    constructor(private productService: ProductService) { }
}
