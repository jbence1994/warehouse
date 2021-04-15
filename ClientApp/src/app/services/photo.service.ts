import { HttpClient } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Photo } from '../models/photo';

export class PhotoService {

    constructor(private http: HttpClient,
                @Inject('BASE_URL') private baseUrl: string) { }
    
    getPhotos(productId: number) {
        return this.http.get<Photo[]>(`${this.baseUrl}api/products/${productId}/photos`);
    }
}
