import { Component, OnInit } from '@angular/core';
import {PackageListService} from '../services/packages-list.service'
import {IPackage} from '../models/package'

@Component({
  selector: 'app-packagelist',
  templateUrl: './packagelist.component.html',
  styleUrls: ['./packagelist.component.css']
})
export class PackagelistComponent implements OnInit {

  constructor(private packageSerive:PackageListService) { }

  ngOnInit() {
    this.getPackages();
  }

  packages:IPackage[];
  errorMessage:any;

  getPackages(): void {
    this.packageSerive.getProducts()
    .subscribe(products => {       
        this.packages = products; 
    }, error => this.errorMessage = <any>error);
  }
 
}
