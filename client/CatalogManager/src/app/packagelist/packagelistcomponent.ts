import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import {  NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {PackageListService} from '../services/packages-list.service';
import {IPackage} from '../models/package';
import {  Router } from '@angular/router';

@Component({
  selector: 'app-packagelist',
  templateUrl: './packagelist.component.html',
  styleUrls: ['./packagelist.component.css']
})
export class PackagelistComponent implements OnInit {
  @ViewChild('addPackage')
  addPackage:  ElementRef;
  packages: IPackage[];
  errorMessage: any;

  public modalReference: any;

  constructor(private modalService:  NgbModal,
     private packageSerive: PackageListService,
     private router: Router) { }


  ngOnInit() {
    this.getPackages();
  }
  openModal() {
    console.log('modal', this.addPackage);

    this.modalReference = this.modalService.open(this.addPackage, {
      size:  'lg',
      backdrop:  'static'
      } );
  }
  hidePopUp() {
    this.modalReference.close();
  }

  getPackages(): void {
    this.packageSerive.getProducts()
    .subscribe(products => {
        this.packages = products;
    }, error => this.errorMessage = <any>error);
  }
  checkAll(ev) {
    this.packages.forEach(x => x.checked = ev.target.checked);
  }

  deletePackagesInBulk() {
    const packages = this.getSelectedPackages() as IPackage[];

    console.log('selected length :: ', packages.length);
    packages.forEach(x => {
      console.log('PackageName to delete' , x.name);
    });
  }

  rejectPackagesInBulk() {
    const packages = this.getSelectedPackages() as IPackage[];

    console.log('selected length :: ', packages.length);
    packages.forEach(x => {
      console.log('PackageName to reject' , x.name);
    });
  }

  approvePackagesInBulk() {
    const packages = this.getSelectedPackages() as IPackage[];

    console.log('selected length :: ', packages.length);
    packages.forEach(x => {
      console.log('PackageName to approve' , x.name);
    });
  }

  getSelectedPackages(): IPackage[] {
    const selectedPackages = [] as IPackage[];
    this.packages.forEach(x => {
      if (x.checked) {
        selectedPackages.push(x);
      }
    });
    return selectedPackages;
  }

  getPackageDetails(_package: IPackage) {
    console.log('Selected package :: ' , _package);
    this.router.navigate(['/viewdetails']);
  }

}
