import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import * as config from "../config/endpoints.json";
import Photo from "../models/photo";
import ProductPhoto from "../models/productPhoto";

@Injectable()
export default class PhotoService {
  private readonly ProductsEndpoint = config.productsEndpoint;
  private readonly TechniciansEndpoint = config.techniciansEndpoint;
  private readonly ProductPhotosEndpoint = config.productPhotosEndpoint;

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getProductPhotos() {
    return this.http.get<ProductPhoto[]>(
      `${this.baseUrl}${this.ProductPhotosEndpoint}`
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

    return this.http.post<ProductPhoto>(
      `${this.baseUrl}${this.ProductPhotosEndpoint}/${productId}`,
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
