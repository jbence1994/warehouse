import { KeyValuePair } from './keyValuePair';

export interface Supplier {
    id: number;
    name: string;
    city: string;
    email: string;
    phone: string;
    products: KeyValuePair[]
}
