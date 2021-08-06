import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import SaveTechnician from "../models/saveTechnician";
import Technician from "../models/technician";

@Injectable()
export default class TechnicianService {
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getTechnicians() {
    return [];
  }

  getTechnician(id: number): Technician {
    return {
      id: 0,
      firstName: null,
      lastName: null,
      email: null,
      phone: null,
      balance: 0,
    };
  }

  getTechnicianOrders(id: number) {
    return [];
  }

  createTechnician(saveTechnician: SaveTechnician) {
    return [];
  }
}
