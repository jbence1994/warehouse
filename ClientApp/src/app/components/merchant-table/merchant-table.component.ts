import { Component, OnInit } from "@angular/core";
import MerchantService from "../../services/merchant.service";
import Merchant from "../../models/responses/merchant";

@Component({
  selector: "app-merchant-table",
  templateUrl: "./merchant-table.component.html",
})
export default class MerchantTableComponent implements OnInit {
  merchants: Merchant[];

  constructor(private merchantService: MerchantService) {}

  ngOnInit() {
    this.populateMerchants();
  }

  populateMerchants() {
    this.merchantService
      .getMerchants()
      .subscribe((merchants) => (this.merchants = merchants));
  }
}
