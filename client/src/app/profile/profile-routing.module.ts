import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProfileLayoutComponent } from './profile-layout/profile-layout.component';
import { ProfileUpdateComponent } from './profile-update/profile-update.component';
import { ProfileDetailComponent } from './profile-detail/profile-detail.component';

const routes: Routes = [
  {
      path: '', component: ProfileLayoutComponent,
      children: [
          { path: '', component: ProfileDetailComponent },
          { path: 'update', component: ProfileUpdateComponent }
      ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfileRoutingModule { }
