import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import NavMenuComponent from "./components/nav-menu/nav-menu.component";
import HomeComponent from "./components/home/home.component";
import SuppliesComponent from "./components/supplies/supplies.component";
import ProductFormComponent from "./components/product-form/product-form.component";
import TechniciansTableComponent from "./components/technician-table/technicians-table.component";
import TechnicianFormComponent from "./components/technician-form/technician-form.component";
import TechnicianProfileComponent from "./components/technician-profile/technician-profile.component";
import MerchantTableComponent from "./components/merchant-table/merchant-table.component";
import MerchantFormComponent from "./components/merchant-form/merchant-form.component";

import DateService from "./services/date.service";
import SupplyService from "./services/supply.service";
import ProductService from "./services/product.service";
import PhotoService from "./services/photo.service";
import TechnicianService from "src/app/services/technician.service";
import MerchantService from "./services/merchant.service";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SuppliesComponent,
    ProductFormComponent,
    TechniciansTableComponent,
    TechnicianFormComponent,
    TechnicianProfileComponent,
    MerchantTableComponent,
    MerchantFormComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "raktarkeszlet", component: SuppliesComponent },
      { path: "raktarkeszlet/termek/uj", component: ProductFormComponent },
      { path: "technikus-info", component: TechniciansTableComponent },
      { path: "technikus-info/uj", component: TechnicianFormComponent },
      { path: "technikus-info/:id", component: TechnicianProfileComponent },
      { path: "kereskedok", component: MerchantTableComponent },
      { path: "kereskedok/uj", component: MerchantFormComponent },
    ]),
  ],
  providers: [
    DateService,
    SupplyService,
    ProductService,
    PhotoService,
    TechnicianService,
    MerchantService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
