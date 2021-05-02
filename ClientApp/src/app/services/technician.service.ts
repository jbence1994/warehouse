import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Technician } from 'src/app/models/technician';
import { Order } from '../models/order';

@Injectable()
export class TechnicianService {

    private readonly TechniciansEndpoint = 'api/technicians';

    constructor(private http: HttpClient,
                @Inject('BASE_URL') private baseUrl: string) { }

    getTechnicians() {
        return this.http.get<Technician[]>(`${this.baseUrl}${this.TechniciansEndpoint}`);
    }

    getTechnician(id: number) {
        return this.http.get<Technician>(`${this.baseUrl}${this.TechniciansEndpoint}/${id}`);
    }

    getTechnicianOrders(id: number) {
        return this.http.get<Order[]>(`${this.baseUrl}${this.TechniciansEndpoint}/${id}/orders`);
    }
}
