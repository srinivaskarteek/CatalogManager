import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PackageDetailsComponent } from './packagedetails/packagedetails.component';
import { PackagelistComponent } from './packagelist/packagelistcomponent';

const routes: Routes = [
  { path: '',  redirectTo: 'packagedetails', pathMatch: 'full' },
  { path: 'packagedetails',  component: PackagelistComponent },
  { path: 'viewdetails',  component: PackageDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
