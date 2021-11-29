import Product from "./product";

export default interface OrderDetail {
  product: Product;
  quantity: number;
  subTotal: number;
}
