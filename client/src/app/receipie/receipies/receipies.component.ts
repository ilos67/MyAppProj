import { Component, OnInit } from '@angular/core';
import { ReceipieService } from 'src/app/service/receipie.service';
import { IProduct } from 'src/app/_models';
import { IReceipie } from 'src/app/_models/receipie';

@Component({
  selector: 'app-receipies',
  templateUrl: './receipies.component.html',
  styleUrls: ['./receipies.component.scss']
})
export class ReceipiesComponent implements OnInit {

  receipies: Partial<IReceipie[]>;
  stocks: Partial<IReceipie[]>;

  constructor(private receipieService: ReceipieService) { }

  ngOnInit(): void {
    this.getUsersWithRoles();
    // console.log(this.getUsersWithRoles());
    this.getStocks();
  }

  getUsersWithRoles() {
    this.receipieService.getProductsWithStocks().subscribe(receipie => {
      this.receipies = receipie;
      console.log(this.receipies)
    })
  }
  getStocks() {
    this.receipieService.getRecepiesStock().subscribe(stock => {
      this.stocks = stock;
    })
  }

}
