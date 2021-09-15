import KeyValuePair from "./keyValuePair";

export default interface SupplierKeyValuePairWithProductKeyValuePairs {
  id: number;
  name: string;
  products: KeyValuePair[];
}
