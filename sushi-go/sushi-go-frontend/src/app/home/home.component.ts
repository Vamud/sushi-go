import { Component, inject } from '@angular/core';
import { map } from 'rxjs';
import { toSignal } from '@angular/core/rxjs-interop';

import { CatalogService } from '../services/catalog.service';
import { Product } from '../types/product.interface';
import { CommonModule } from '@angular/common';
import { environment } from '../../environments/environment';
import { ProductComponent } from '../components/product/product.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, ProductComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  readonly apiUrl = environment.apiUrl;
  private catalogService = inject(CatalogService);

  readonly products = toSignal(
    this.catalogService.fetchProducts().pipe(map((data: Product[]) => data))
  );
}
