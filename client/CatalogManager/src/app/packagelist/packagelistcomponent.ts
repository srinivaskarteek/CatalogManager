import { Component, OnInit, TemplateRef, ViewChild, ElementRef } from '@angular/core';
import {  NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {PackageListService} from '../services/packages-list.service';
import {IPackage} from '../models/package';

@Component({
  selector: 'app-packagelist',
  templateUrl: './packagelist.component.html',
  styleUrls: ['./packagelist.component.css']
})
export class PackagelistComponent implements OnInit {
  @ViewChild('addPackage')
  addPackage: ElementRef;
  packages: IPackage[];
  errorMessage: any;

  public modalReference: any;

  constructor(private modalService:  NgbModal, private packageSerive: PackageListService) { }


  ngOnInit() {
    this.getPackages();
  }
  openModal() {
    console.log('modal', this.addPackage);

    this.modalReference = this.modalService.open(this.addPackage,{
      size: 'lg',
      backdrop: 'static'
      } );
  }
  hidePopUp()
  {
    this.modalReference.close();
  }

  getPackages(): void {
    this.packageSerive.getProducts()
    .subscribe(products => {
        this.packages = products;
    }, error => this.errorMessage = <any>error);
  }

}
