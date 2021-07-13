import { KeyValuePair } from "./keyValuePair";

export interface SupplierWithProducts {
  id: number;
  name: string;
  products: KeyValuePair[];
}
