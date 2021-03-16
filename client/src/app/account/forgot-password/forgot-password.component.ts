import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { finalize } from 'rxjs/internal/operators/finalize';
import { first } from 'rxjs/internal/operators';
import { AccountService } from 'src/app/service/account.service';
import { AlertService } from 'src/app/service/alert.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {
  form: FormGroup;
  loading = false;
  submitted = false;

  constructor(
      private formBuilder: FormBuilder,
      private accountService: AccountService,
      private alertService: AlertService
  ) { }

  ngOnInit() {
      this.form = this.formBuilder.group({
          email: ['', [Validators.required, Validators.email]]
      });
  }

  // convenience getter for easy access to form fields
  get f() { return this.form.controls; }

  onSubmit() {
      this.submitted = true;

      // reset alerts on submit
      this.alertService.clear();

      // stop here if form is invalid
      if (this.form.invalid) {
          return;
      }

      this.loading = true;
      this.alertService.clear();
      this.accountService.forgotPassword(this.f.email.value)
          .pipe(first())
          .pipe(finalize(() => this.loading = false))
          .subscribe({
              next: () => this.alertService.success('Please check your email for password reset instructions'),
              error: error => this.alertService.error(error)
          });
  }
}



