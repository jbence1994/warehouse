import { Component, OnInit } from '@angular/core';
import { StockService } from 'src/app/services/stock.service';
import { Stock } from '../../models/stock';

@Component({
  selector: 'app-stock-table',
  templateUrl: './stock-table.component.html'
})
export class StockTableComponent implements OnInit {
  public stocks: Stock[];

  constructor(private stockService: StockService) { }

  ngOnInit() {
    this.populateStocks();
  }

  populateStocks() {
    this.stockService.getStocks()
      .subscribe(stocks => this.stocks = stocks);
  }
}