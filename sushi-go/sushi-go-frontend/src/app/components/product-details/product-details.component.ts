import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';
import { map } from 'rxjs';
import { ButtonModule } from 'primeng/button';

import { CatalogService } from '../../services/catalog.service';
import { Product } from '../../types/product.interface';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-product-details',
  standalone: true,
  imports: [ButtonModule],
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss'
})
export class ProductDetailsComponent {
  private activatedRoute = inject(ActivatedRoute);
  private catalogService = inject(CatalogService);
  readonly apiUrl = environment.apiUrl;

  id = this.activatedRoute.snapshot.params['id'];
  product = toSignal(
    this.catalogService.fetchProductById(this.id).pipe(map((data: Product) => data))
  )
}
