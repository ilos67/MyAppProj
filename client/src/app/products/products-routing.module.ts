import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products/products.component';
import { Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'products',
    pathMatch: 'full'
 },
  {
      path: '', 
      children: [
          { path: 'products', component: ProductsComponent }
      ]
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class ProductsRoutingModule { }
