import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import Photo from "../models/photo";
import * as config from "../config/endpoints.json";

@Injectable()
export default class PhotoService {
  private readonly ProductsEndpoint = config.productsEndpoint;
  private readonly TechniciansEndpoint = config.techniciansEndpoint;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getProductPhotos() {
    // TODO: refactor hard-coded resource id in route ...
    return this.http.get<Photo[]>(
      `${this.baseUrl}${this.ProductsEndpoint}/1/photos`
    );
  }

  getTechnicianPhotos(technicianId: number) {
    return this.http.get<Photo[]>(
      `${this.baseUrl}${this.TechniciansEndpoint}/${technicianId}/photos`
    );
  }

  uploadProductPhoto(productId: number, photoToUpload: File) {
    const formData = new FormData();
    formData.append("photoToUpload", photoToUpload);

    return this.http.post<Photo>(
      `${this.baseUrl}${this.ProductsEndpoint}/${productId}/photos`,
      formData
    );
  }

  uploadTechnicianPhoto(technicianId: number, photoToUpload: File) {
    const formData = new FormData();
    formData.append("photoToUpload", photoToUpload);

    return this.http.post<Photo>(
      `${this.baseUrl}${this.TechniciansEndpoint}/${technicianId}/photos`,
      formData
    );
  }
}
