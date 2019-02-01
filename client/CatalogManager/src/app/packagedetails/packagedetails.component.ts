import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-packagedetails',
  templateUrl: './packagedetails.component.html',
  styleUrls: ['./packagedetails.component.css']
})
export class PackageDetailsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  PackageDetails= {
      "ProductName":"XYZZZZZZZZZZZZzzzzz",
      "OrderNumber": "123456987",
      "HWVersion": "V 1.023",
      "ProductFamily": "Schneider",
      "DeviceFamily": "Installation",
      "ProfileType": "SLC",
      "StateDescription": "This is Package desciption details",
      "Vendor": "Karteel",
      "Owner": "Karteel",
      "UpdateDate": "Last Updated"
    };
}
