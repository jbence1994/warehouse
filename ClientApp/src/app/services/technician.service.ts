import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import Technician from "../models/responses/technician";
import SaveTechnician from "../models/requests/saveTechnician";
import Order from "../models/responses/order";
import * as config from "../config/endpoints.json";

@Injectable()
export default class TechnicianService {
  private readonly TechniciansEndpoint = config.techniciansEndpoint;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getTechnicians() {
    return this.http.get<Technician[]>(
      `${this.baseUrl}${this.TechniciansEndpoint}`
    );
  }

  getTechnician(id: number) {
    return this.http.get<Technician>(
      `${this.baseUrl}${this.TechniciansEndpoint}/${id}`
    );
  }

  getTechnicianOrders(id: number) {
    return this.http.get<Order[]>(
      `${this.baseUrl}${this.TechniciansEndpoint}/${id}/orders`
    );
  }

  createTechnician(saveTechnician: SaveTechnician) {
    return this.http.post<Technician>(
      `${this.baseUrl}${this.TechniciansEndpoint}`,
      saveTechnician
    );
  }
}
