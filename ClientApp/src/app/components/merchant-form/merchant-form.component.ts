import { Component } from "@angular/core";
import MerchantService from "./../../services/merchant.service";
import SaveMerchant from "./../../models/saveMerchant";

@Component({
  selector: "app-merchant-form",
  templateUrl: "./merchant-form.component.html",
})
export default class MerchantFormComponent {
  saveMerchant: SaveMerchant = { name: "", city: "", email: "", phone: "" };

  constructor(private merchantService: MerchantService) {}

  submit() {
    this.merchantService.createMerchant(this.saveMerchant).subscribe();
  }
}
