import { IDevice } from "./device";

export interface IPackage{

    id: Int32Array;
    checked: boolean;
    name: string;
    deviceFamilyId: string;
    productFamilyId: string;
    status: number;
    productFamily: any;
    deviceFamily: any;
    productName: string;
    OrderNumber: string;
    hwVersion: string;
    profileType: string;
    ownerId: string;
    uploadDate: Date;
    productId: string;
    swVersion: string;
    fileName: string;
    blobURL: string;
    comments: string;
    lastModified: Date;
    createdOn: Date;
}
