import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import Photo from "../models/photo";

@Injectable()
export default class PhotoService {
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {}

  getProductPhotos(productId: number) {
    return [];
  }

  getTechnicianPhotos(technicianId: number) {
    return [];
  }

  uploadProductPhoto(productId: number, photoToUpload: File): Photo {
    const formData = new FormData();
    formData.append("photoToUpload", photoToUpload);

    return { id: 1, fileName: "" };
  }

  uploadTechnicianPhoto(technicianId: number, photoToUpload: File) {
    const formData = new FormData();
    formData.append("photoToUpload", photoToUpload);

    return [];
  }
}
