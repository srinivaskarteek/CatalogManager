import { IDevice } from "./device";

export interface IPackageDetails{
    
        ProductName:string,
        OrderNumber:string,
        HWVersion: string,
        ProductFamily: string,
        DeviceFamily: string,
        ProfileType: string,
        StateDescription: string,
        Vendor: string,
        Owner: string,
        UpdateDate: Date,
        DeviceDescription:IDevice
     
}