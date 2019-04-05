import { Component, OnInit } from '@angular/core';
import { IPackageDetails } from '../models/packageDetails';
import { PackageService } from '../services/package.service';
import { IPackage } from '../models/package';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-packagedetails',
  templateUrl: './packagedetails.component.html',
  styleUrls: ['./packagedetails.component.css']
})
export class PackageDetailsComponent implements OnInit {
  sub: any;
  id: any;

  constructor(private packageSerive:PackageService, private _Activatedroute:ActivatedRoute) { }

  ngOnInit() {
    this.id = this._Activatedroute.snapshot.params['id'];
    this.getPackages(this.id);
  }

  PackageDetails:IPackage;
  errorMessage:any;

  getPackages(id): void {
    this.packageSerive.getPackageDetailsBasedOnId(this.id)
    .subscribe(products => {
        this.PackageDetails = products;
    }, error => this.errorMessage = <any>error);
  }

}
