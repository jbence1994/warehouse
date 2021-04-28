import { SaleDetail } from './saleDetail';

export interface Sale {
    id: number;
    total: number;
    createdAt: string;
    saleDetails: SaleDetail[]
}
