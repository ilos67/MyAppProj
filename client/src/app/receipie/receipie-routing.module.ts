import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReceipiesComponent } from './receipies/receipies.component';
import { Routes } from '@angular/router';
import { ReceipiesPanelComponent } from './receipies-panel/receipies-panel.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'recepies',
    pathMatch: 'full'
 },
  {
      path: '', 
      children: [
          { path: 'recepies', component: ReceipiesPanelComponent },
          { path: 'recepiess', component: ReceipiesComponent }
      ]
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class ReceipieRoutingModule { }
