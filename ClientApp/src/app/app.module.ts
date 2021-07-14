import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import AppComponent from "./app.component";
import NavMenuComponent from "./components/nav-menu/nav-menu.component";
import HomeComponent from "./components/home/home.component";
import StockTableComponent from "./components/stock-table/stock-table.component";
import StockFormComponent from "./components/stock-form/stock-form.component";
import ProductTableComponent from "./components/product-table/product-table.component";
import ProductFormComponent from "./components/product-form/product-form.component";
import ViewProductComponent from "./components/view-product/view-product.component";
import TechniciansTableComponent from "./components/technician-table/technicians-table.component";
import TechnicianFormComponent from "./components/technician-form/technician-form.component";
import TechnicianProfileComponent from "./components/technician-profile/technician-profile.component";
import SupplierTableComponent from "./components/supplier-table/supplier-table.component";
import SupplierFormComponent from "./components/supplier-form/supplier-form.component";

import DateService from "./services/date.service";
import StockService from "./services/stock.service";
import ProductService from "./services/product.service";
import PhotoService from "./services/photo.service";
import TechnicianService from "src/app/services/technician.service";
import SupplierService from "./services/supplier.service";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    StockTableComponent,
    StockFormComponent,
    ProductTableComponent,
    ProductFormComponent,
    ViewProductComponent,
    TechniciansTableComponent,
    TechnicianFormComponent,
    TechnicianProfileComponent,
    SupplierTableComponent,
    SupplierFormComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "raktarkeszlet", component: StockTableComponent },
      { path: "raktarkeszlet/uj", component: StockFormComponent },
      { path: "termeklista", component: ProductTableComponent },
      { path: "termeklista/uj", component: ProductFormComponent },
      { path: "termeklista/:id", component: ViewProductComponent },
      { path: "technikus-info", component: TechniciansTableComponent },
      { path: "technikus-info/uj", component: TechnicianFormComponent },
      { path: "technikus-info/:id", component: TechnicianProfileComponent },
      { path: "beszallitok", component: SupplierTableComponent },
      { path: "beszallitok/uj", component: SupplierFormComponent },
    ]),
  ],
  providers: [
    DateService,
    StockService,
    ProductService,
    PhotoService,
    TechnicianService,
    SupplierService,
  ],
  bootstrap: [AppComponent],
})
export default class AppModule {}
