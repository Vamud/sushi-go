import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { Product } from '../types/product.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  private apiUrl = environment.apiUrl;
  private http = inject(HttpClient);

  fetchRollsMenu(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl + '/api/menu/rolls');
  }

  fetchSetsMenu(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl + '/api/menu/sets');
  }

  fetchProductById(id: number): Observable<Product> {
    return this.http.get<Product>(this.apiUrl + '/api/menu/rolls/' + id);
  }
}
