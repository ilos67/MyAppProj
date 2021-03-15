import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products/products.component';
import { Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'product',
    pathMatch: 'full'
 },
  {
      path: '', 
      children: [
          { path: 'product', component: ProductsComponent }
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
