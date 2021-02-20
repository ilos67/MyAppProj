import { Component, OnInit } from '@angular/core';
import { AccountService } from '../service/account.service';
import { Role } from '../_models/role';
import { IProduct } from '../_models/product';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  stocks: any[];
  products: IProduct[];
  account = this.accountService.accountValue;
  Role = Role;
  constructor(private accountService: AccountService, private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/products').subscribe((response: any) => {
      this.products = response.data;
    }, error => {
      console.log(error);
    });
   
   

  }
  
  logout() {
    this.accountService.logout();
  }

}
