import { Component, OnInit } from '@angular/core';
import { AccountService } from '../service/account.service';
import { Account } from '../_models/account';
import { Role } from '../_models/role';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  Role = Role;
  account: Account;

  constructor(private accountService: AccountService) {
  }

  logout() {
      this.accountService.logout();
  }
}
