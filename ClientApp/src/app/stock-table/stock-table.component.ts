import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-stock-table',
  templateUrl: './stock-table.component.html'
})
export class StockTableComponent {
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

interface Product {
  id: number;
  name: string;
  price: number;
  unit: string;
  supplierName: string;
}
