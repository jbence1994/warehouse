import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import KeyValuePair from "../models/responses/keyValuePair";
import Merchant from "../models/responses/merchant";
import SaveMerchant from "../models/requests/saveMerchant";
import * as config from "../config/endpoints.json";

@Injectable()
export default class MerchantService {
  private readonly MerchantsEndpoint = config.merchantsEndpoint;
  private readonly MerchantKeyValuePairsEndpoint =
    config.merchantKeyValuePairsEndpoint;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getMerchants() {
    return this.http.get<Merchant[]>(
      `${this.baseUrl}${this.MerchantsEndpoint}`
    );
  }

  getMerchantKeyValuePairs() {
    return this.http.get<KeyValuePair[]>(
      `${this.baseUrl}${this.MerchantKeyValuePairsEndpoint}`
    );
  }

  createMerchant(saveMerchant: SaveMerchant) {
    return this.http.post<Merchant>(
      `${this.baseUrl}${this.MerchantsEndpoint}`,
      saveMerchant
    );
  }
}
