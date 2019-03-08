import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PackageDetailsComponent } from './packagedetails/packagedetails.component';
import { PackagelistComponent } from './packagelist/packagelistcomponent';
import { PackagefamilyComponent } from './packagefamily/packagefamily.component';
import { DevicefamilyComponent } from './devicefamily/devicefamily.component';

const routes: Routes = [
  { path: '',  redirectTo: 'home', pathMatch: 'full' },
  { path: 'home',  component: PackagelistComponent },
  { path: 'viewdetails',  component: PackageDetailsComponent },
  { path: 'packagefamily',  component: PackagefamilyComponent },
  { path: 'devicefamily',  component: DevicefamilyComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
