import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Technician } from 'src/app/models/technician';
import { Sale } from './../models/sale';

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

    getTechnicianSales(id: number) {
        return this.http.get<Sale[]>(`${this.baseUrl}${this.TechniciansEndpoint}/${id}/sales`);
    }
}
