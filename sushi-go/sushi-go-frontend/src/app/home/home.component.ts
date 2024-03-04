import { Component, computed, inject, signal } from '@angular/core';
import { map } from 'rxjs';
import { toSignal } from '@angular/core/rxjs-interop';

import { MenuService } from '../services/menu.service';
import { Product } from '../types/product.interface';
import { CommonModule } from '@angular/common';
import { environment } from '../../environments/environment';
import { ProductComponent } from '../components/product/product.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, ProductComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  readonly apiUrl = environment.apiUrl;
  private activatedRoute = inject(ActivatedRoute);
  private menuService = inject(MenuService);

  productsType = signal(this.activatedRoute.snapshot.data['productType']);

  readonly products = computed(() => {
    switch (this.productsType()) {
      case 'rolls':
        return this.rolls();
      case 'sets':
        return this.sets();
      default:
        return [];
    }
  });

  readonly rolls = toSignal(
    this.menuService.fetchRollsMenu().pipe(map((data: Product[]) => data))
  );

  readonly sets = toSignal(
    this.menuService.fetchSetsMenu().pipe(map((data: Product[]) => data))
  );
}
