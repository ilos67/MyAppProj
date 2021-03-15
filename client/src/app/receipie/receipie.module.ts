import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReceipiesComponent } from './receipies/receipies.component';
import { ReceipieRoutingModule } from './receipie-routing.module';
import { ReceipiesPanelComponent } from './receipies-panel/receipies-panel.component';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { AccordionModule } from 'ngx-bootstrap/accordion';



@NgModule({
  declarations: [ReceipiesComponent, ReceipiesPanelComponent],
  imports: [
    CommonModule,
    ReceipieRoutingModule,
    AccordionModule.forRoot()
  ],
  exports: [
    ReceipiesComponent, ReceipiesPanelComponent,AccordionModule
  ]
})
export class ReceipieModule { }
