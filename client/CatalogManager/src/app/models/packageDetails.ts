import { IDevice } from "./device";

export interface IPackageDetails {
        productName: string;
        OrderNumber: string;
        hwVersion: string;
        profileType: string;
        status: string;
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
