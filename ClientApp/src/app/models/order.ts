import { OrderDetail } from "./orderDetail";

export interface Order {
  id: number;
  total: number;
  createdAt: string;
  orderDetails: OrderDetail[];
}
