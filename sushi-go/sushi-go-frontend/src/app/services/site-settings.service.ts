import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { SiteSettings } from '../types/site-settings.interface';

@Injectable({
  providedIn: 'root',
})
export class SiteSettingsService {
  private apiUrl = environment.apiUrl;
  private http = inject(HttpClient);

  fetchSiteSettings(): Observable<SiteSettings> {
    return this.http.get<SiteSettings>(this.apiUrl + '/api/settings');
  }
}
