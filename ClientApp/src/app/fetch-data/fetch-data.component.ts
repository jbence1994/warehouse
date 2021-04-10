import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public stocks: Stock[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Stock[]>(baseUrl + 'api/stocks')
      .subscribe(stocks => this.stocks = stocks);
  }
}

interface Stock {
  product: Product,
  quantity: number;
}

interface Product extends KeyValuePair {
  price: number;
  unit: string;
}

interface KeyValuePair {
  id: number;
  name: string;
}
