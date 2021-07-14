import { Component, OnInit } from "@angular/core";
import { SaveSupplier } from "./../../models/saveSupplier";

@Component({
  selector: "app-supplier-form",
  templateUrl: "./supplier-form.component.html",
})
export class SupplierFormComponent {
  saveSupplier: SaveSupplier = { name: "", city: "", email: "", phone: "" };

  submit() {
    console.log("POST request to REST API ...");
  }
}
