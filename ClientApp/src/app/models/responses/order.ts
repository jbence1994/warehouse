import OrderDetail from "./orderDetail";

export default interface Order {
  id: number;
  total: number;
  createdAt: string;
  orderDetails: OrderDetail[];
}
