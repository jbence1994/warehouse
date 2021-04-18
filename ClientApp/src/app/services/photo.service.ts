import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Photo } from '../models/photo';

@Injectable()
export class PhotoService {

    constructor(private http: HttpClient,
                @Inject('BASE_URL') private baseUrl: string) { }
    
    getPhotos(productId: number) {
        return this.http.get<Photo[]>(`${this.baseUrl}api/products/${productId}/photos`);
    }

    uploadPhoto(productId: number, photoToUpload: File) {
        var formData = new FormData();
        formData.append('photoToUpload', photoToUpload);

        return this.http.post<Photo>(`${this.baseUrl}api/products/${productId}/photos`, formData);
    }
}