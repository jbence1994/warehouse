import { Component } from "@angular/core";
import SupplierService from "./../../services/supplier.service";
import SaveSupplier from "./../../models/saveSupplier";

@Component({
  selector: "app-supplier-form",
  templateUrl: "./supplier-form.component.html",
})
export default class SupplierFormComponent {
  saveSupplier: SaveSupplier = { name: "", city: "", email: "", phone: "" };

  constructor(private supplierService: SupplierService) {}

  submit() {
    this.supplierService.createSupplier(this.saveSupplier).subscribe();
  }
}
