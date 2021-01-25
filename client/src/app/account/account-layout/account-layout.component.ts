import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/service/account.service';

@Component({
  selector: 'app-account-layout',
  templateUrl: './account-layout.component.html',
  styleUrls: ['./account-layout.component.scss']
})
export class AccountLayoutComponent  {

  constructor(
    private router: Router,
    private accountService: AccountService
) {
    // redirect to home if already logged in
    if (this.accountService.accountValue) {
        this.router.navigate(['/']);
    }
}
}