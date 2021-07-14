import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import StockService from "../../services/stock.service";
import SupplierWithProducts from "../../models/supplierWithProducts";
import KeyValuePair from "../../models/keyValuePair";
import SaveStockEntry from "../../models/saveStockEntry";

@Component({
  selector: "app-stock-form",
  templateUrl: "./stock-form.component.html",
})
export default class StockFormComponent implements OnInit {
  suppliers: SupplierWithProducts[];
  products: KeyValuePair[];

  saveStockEntry: SaveStockEntry = {
    productId: 0,
    supplierId: 0,
    quantity: 1,
  };

  constructor(private stockService: StockService, private router: Router) {}

  ngOnInit() {
    this.populateSuppliers();
  }

  onSupplierChange() {
    this.populateProducts();

    delete this.saveStockEntry.productId;
  }

  submit() {
    this.stockService.createStockEntry(this.saveStockEntry).subscribe();
    this.router.navigate(["/raktarkeszlet/"]);
  }

  populateSuppliers() {
    this.stockService
      .getSuppliers()
      .subscribe((suppliers) => (this.suppliers = suppliers));
  }

  populateProducts() {
    let selectedSupplier = this.suppliers.find(
      (supplier) => supplier.id == this.saveStockEntry.supplierId
    );

    this.products = selectedSupplier ? selectedSupplier.products : [];
  }
}
