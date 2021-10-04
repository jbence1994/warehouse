import Product from "./product";

export default interface Stock {
  id: number;
  product: Product;
  quantity: number;
}
