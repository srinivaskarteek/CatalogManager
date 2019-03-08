import { Component, OnInit } from '@angular/core';
import { IPackageDetails } from '../models/packageDetails';
import { PackageService } from '../services/package.service';
import { IPackage } from '../models/package';

@Component({
  selector: 'app-packagedetails',
  templateUrl: './packagedetails.component.html',
  styleUrls: ['./packagedetails.component.css']
})
export class PackageDetailsComponent implements OnInit {

  constructor(private packageSerive:PackageService) { }

  ngOnInit() {
    this.getPackages();
  }

  PackageDetails:IPackage;
  errorMessage:any;

  getPackages(): void {
    this.packageSerive.getPackageDetails()
    .subscribe(products => {
        this.PackageDetails = products;
    }, error => this.errorMessage = <any>error);
  }

}
