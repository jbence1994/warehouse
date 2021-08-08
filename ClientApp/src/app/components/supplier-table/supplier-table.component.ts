import { Component, OnInit } from "@angular/core";
import SupplierService from "./../../services/supplier.service";
import Supplier from "./../../models/supplier";

@Component({
  selector: "app-supplier-table",
  templateUrl: "./supplier-table.component.html",
})
export default class SupplierTableComponent implements OnInit {
  suppliers: Supplier[];

  constructor(private supplierService: SupplierService) {}

  ngOnInit() {
    this.populateSuppliers();
  }

  populateSuppliers() {
    this.suppliers = this.supplierService.getSuppliers();
  }
}