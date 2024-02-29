import { Component, Input } from '@angular/core';
import { ButtonModule } from 'primeng/button';

import { Product } from '../../types/product.interface';
import { environment } from '../../../environments/environment';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [ButtonModule, RouterLink],
  templateUrl: './product.component.html',
  styleUrl: './product.component.scss',
})
export class ProductComponent {
  @Input() product!: Product;

  readonly apiUrl = environment.apiUrl;
}
