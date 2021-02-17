import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AccountLayoutComponent } from './account-layout/account-layout.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { VerifyEmailComponent } from './verify-email/verify-email.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
 },
  {
      path: '', 
      children: [
          { path: 'login', component: LoginComponent },
          { path: 'register', component: RegisterComponent },
          { path: 'verify-email', component: VerifyEmailComponent },
          { path: 'forgot-password', component: ForgotPasswordComponent },
          { path: 'reset-password', component: ResetPasswordComponent }
      ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
