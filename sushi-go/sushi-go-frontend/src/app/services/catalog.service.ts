import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Product } from '../types/product.interface';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CatalogService {
  private apiUrl = environment.apiUrl;
  private http = inject(HttpClient);

  fetchProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl + '/api/menu/rolls');
  }

  fetchProductById(id: number): Observable<Product> {
    return this.http.get<Product>(this.apiUrl + '/api/menu/rolls/' + id);
  }
}
