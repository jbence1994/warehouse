import { Router } from '@angular/router';
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/services/product.service';
import { Product } from 'src/app/models/product';

@Component({
    selector: 'app-view-product',
    templateUrl: './view-product.component.html'
})
export class ViewProductComponent implements OnInit {
    product: Product = {
        id: 0,
        name: null,
        price: 0,
        unit: null,
        supplierName: null
    };
    
    productId: number;
    photos: any[];
    progess: any;

    constructor(
        private productService: ProductService,
        private route: ActivatedRoute,
        private router: Router
    ) {
        this.route.params.subscribe(p => {
            this.productId = +p['id'];

            if (isNaN(this.productId) || this.productId <= 0) {
              this.router.navigate(['/termeklista']);
              return; 
            }
        });
    }

    ngOnInit() {
        this.productService.getProduct(this.productId)
            .subscribe(product => this.product = product);
    }

    uploadPhoto() {
        console.log("uploading photo to API ...");
    }
}
