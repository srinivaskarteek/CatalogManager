import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-packagelist',
  templateUrl: './packagelist.component.html',
  styleUrls: ['./packagelist.component.css']
})
export class PackagelistComponent implements OnInit {

  constructor() { }

  ngOnInit() {
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
