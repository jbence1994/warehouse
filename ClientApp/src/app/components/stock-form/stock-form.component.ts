import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { StockService } from 'src/app/services/stock.service';
import { SaveStock } from './../../models/saveStock';
import { SupplierWithProducts } from 'src/app/models/supplierWithProducts';
import { KeyValuePair } from './../../models/keyValuePair';

@Component({
    selector: 'app-stock-form',
    templateUrl: './stock-form.component.html'
})
export class StockFormComponent implements OnInit {

    suppliers: SupplierWithProducts[];
    products: KeyValuePair[];

    saveStock: SaveStock = {
        productId: 0,
        supplierId: 0,
        quantity: 1
    };

    constructor(
        private stockService: StockService,
        private router: Router
    ) { }

    ngOnInit() {
        this.populateSuppliers();
    }

    onSupplierChange() {
        this.populateProducts();

        delete this.saveStock.productId;
    }

    submit() {
        this.stockService.createStock(this.saveStock).subscribe();
        this.router.navigate(['/raktarkeszlet/']);
    }

    populateSuppliers() {
        this.stockService.getSuppliers()
            .subscribe(suppliers => this.suppliers = suppliers);
    }

    populateProducts() {
        let selectedSupplier = this.suppliers
            .find(supplier => supplier.id == this.saveStock.supplierId);
        
        this.products = selectedSupplier ? selectedSupplier.products : [];
    }
}
