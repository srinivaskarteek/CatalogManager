import { Component, OnInit, TemplateRef, ViewChild, ElementRef } from '@angular/core';
import {  NgbModal } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-packagelist',
  templateUrl: './packagelist.component.html',
  styleUrls: ['./packagelist.component.css']
})
export class PackagelistComponent implements OnInit {
  @ViewChild('addPackage')
  addPackage: ElementRef;

  public modalReference: any;

  constructor(private modalService: NgbModal) { }

  ngOnInit() {
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

  packages= [
    {
      "checked":false,
      "packageName": "sample",
      "deviceFamily": "Leaf Rake",
      "productFamily": "GDN-0011",
      "status": "Approve",
    },{
      "checked":false,
      "packageName": "sample",
      "deviceFamily": "Leaf Rake",
      "productFamily": "GDN-0011",
      "status": "Approve",
    },{
      "checked":false,
      "packageName": "sample",
      "deviceFamily": "Leaf Rake",
      "productFamily": "GDN-0011",
      "status": "Approve",
    },{
      "checked":false,
      "packageName": "sample",
      "deviceFamily": "Leaf Rake",
      "productFamily": "GDN-0011",
      "status": "Approve",
    },{
      "checked":false,
      "packageName": "sample",
      "deviceFamily": "Leaf Rake",
      "productFamily": "GDN-0011",
      "status": "Approve",
    }

  ];
}
