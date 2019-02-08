
import { Component, TemplateRef, ViewChild, ElementRef } from '@angular/core';
import {  NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-packageadd',
  templateUrl: './packageadd.component.html',
  styleUrls: ['./packageadd.component.css']
})
export class PackageAddComponent {
  @ViewChild('addPackage')
  addPackage:  ElementRef;

  public modalReference: any;

  constructor(private modalService:  NgbModal) { }
  openModal() {
    this.modalReference = this.modalService.open(this.addPackage);
  }
}
