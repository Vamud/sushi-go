import { Component, computed, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { environment } from '../environments/environment';
import { SiteSettingsService } from './services/site-settings.service';
import { toSignal } from '@angular/core/rxjs-interop';
import { map } from 'rxjs';
import { SiteSettings } from './types/site-settings.interface';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HomeComponent, HeaderComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  readonly apiUrl = environment.apiUrl;
  private siteSettingsService = inject(SiteSettingsService);

  readonly siteLogo = computed(() => this.apiUrl + this.settings()?.siteLogo);

  readonly settings = toSignal(
    this.siteSettingsService.fetchSiteSettings().pipe(map((data: SiteSettings) => data))
  );
}
