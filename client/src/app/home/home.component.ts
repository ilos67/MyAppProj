import { Component, OnInit } from '@angular/core';
import { AccountService } from '../service/account.service';
import { Role } from '../_models/role';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  account = this.accountService.accountValue;
  Role = Role;
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }
  
  logout() {
    this.accountService.logout();
  }

}
