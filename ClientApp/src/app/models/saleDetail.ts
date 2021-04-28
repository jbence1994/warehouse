import { Product } from "./product";

export interface SaleDetail {
    product: Product;
    quantity: number;
    subTotal: number;
}
