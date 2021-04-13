import { SaveStock } from './../../models/saveStock';
import { Component } from "@angular/core";

@Component({
    selector: 'app-stock-form',
    templateUrl: './stock-form.component.html'
})
export class StockFormComponent {

    saveStock: SaveStock = {
        productId: 0,
        supplierId: 0,
        quantity: 1
    };

    constructor() { }

    submit() {
        console.log('POST to API ...');
    }
}
