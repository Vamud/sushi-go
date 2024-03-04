import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { AboutUsComponent } from './about-us/about-us.component';

export const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'rolls',
  },
  {
    path: 'rolls',
    component: HomeComponent,
    data: { productType: 'rolls' },
  },
  {
    path: 'rolls/:id',
    component: ProductDetailsComponent,
    data: { productType: 'rolls' },
  },
  {
    path: 'sets',
    component: HomeComponent,
    data: { productType: 'sets' },
  },
  {
    path: 'sets/:id',
    component: ProductDetailsComponent,
    data: { productType: 'sets' },
  },
  {
    path: 'about-us',
    component: AboutUsComponent,
  },
];
