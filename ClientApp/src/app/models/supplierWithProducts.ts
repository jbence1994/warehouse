import KeyValuePair from "./keyValuePair";

export default interface SupplierWithProducts {
  id: number;
  name: string;
  products: KeyValuePair[];
}
