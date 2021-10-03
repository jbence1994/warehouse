import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import ProductService from "src/app/services/product.service";
import PhotoService from "../../services/photo.service";
import Product from "src/app/models/product";
import ProductPhoto from "../../models/productPhoto";
import Stock from "../../models/stock";
import StockService from "../../services/stock.service";

@Component({
  selector: "app-products",
  templateUrl: "./stocks.component.html",
  styleUrls: ["./stocks.component.css"],
})
export default class StocksComponent implements OnInit {
  @ViewChild("fileInput", { read: "", static: true }) fileInput: ElementRef;
  products: Product[];
  stocks: Stock[];
  productPhotos: ProductPhoto[];

  constructor(
    private productService: ProductService,
    private photoService: PhotoService,
    private stockService: StockService
  ) {}

  ngOnInit() {
    this.populateProducts();
    this.populatePhotos();
    this.populateStocks();
  }

  populateProducts() {
    this.productService
      .getProducts()
      .subscribe((products) => (this.products = products));
  }

  populatePhotos() {
    this.photoService
      .getProductPhotos()
      .subscribe((productPhotos) => (this.productPhotos = productPhotos));
  }

  populateStocks() {
    this.stockService.getStocks().subscribe((stocks) => (this.stocks = stocks));
  }

  uploadProductPhoto(productId: number) {
    let nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    let file = nativeElement.files[0];

    nativeElement.value = "";

    this.photoService
      .uploadProductPhoto(productId, file)
      .subscribe((productPhoto) => this.productPhotos.push(productPhoto));
  }
}
