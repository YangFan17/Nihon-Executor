export class Product implements IProduct {
    id: string;
    name: string;
    photoUrl: string;
    productTagId: number;
    retailPrice: number;
    purchasePrice: number;
    unit: string;
    barCode: string;
    desc: string;
    showPhoto: string;
    pinYinCode: string;
    isEnable: number;
    lable: string;
    grade: number;
    productTagName: string;

    isDeleted: boolean;
    creationTime: Date;
    creatorUserId: number;
    lastModificationTime: Date;
    lastModifierUserId: number;
    deletionTime: Date;
    deleterUserId: number;
    constructor(data?: IProduct) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.id = data["id"];
            this.name = data["name"];
            this.photoUrl = data["photoUrl"];
            this.productTagId = data["productTagId"];
            this.retailPrice = data["retailPrice"];
            this.purchasePrice = data["purchasePrice"];
            this.unit = data["unit"];
            this.barCode = data["barCode"];
            this.desc = data["desc"];
            this.pinYinCode = data["pinYinCode"];
            this.isEnable = data["isEnable"];
            this.lable = data["lable"];
            this.grade = data["grade"];
            this.productTagName = data["productTagName"];
            this.isDeleted = data["isDeleted"];
            this.creationTime = data["creationTime"];
            this.creatorUserId = data["creatorUserId"];
            this.lastModificationTime = data["lastModificationTime"];
            this.lastModifierUserId = data["lastModifierUserId"];
            this.deletionTime = data["deletionTime"];
            this.deleterUserId = data["deleterUserId"];
        }
    }

    static fromJS(data: any): Product {
        let result = new Product();
        result.init(data);
        return result;
    }

    static fromJSArray(dataArray: any[]): Product[] {
        let array = [];
        dataArray.forEach(result => {
            let item = new Product();
            item.init(result);
            array.push(item);
        });

        return array;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["photoUrl"] = this.photoUrl;
        data["productTagId"] = this.productTagId;
        data["retailPrice"] = this.retailPrice;
        data["purchasePrice"] = this.purchasePrice;
        data["unit"] = this.unit;
        data["barCode"] = this.barCode;
        data["desc"] = this.desc;
        data["pinYinCode"] = this.pinYinCode;
        data["isEnable"] = this.isEnable;
        data["lable"] = this.lable;
        data["grade"] = this.grade;
        data["isDeleted"] = this.isDeleted;
        data["creationTime"] = this.creationTime;
        data["creatorUserId"] = this.creatorUserId;
        data["lastModificationTime"] = this.lastModificationTime;
        data["lastModifierUserId"] = this.lastModifierUserId;
        data["deletionTime"] = this.deletionTime;
        data["deleterUserId"] = this.deleterUserId;
        return data;
    }

    clone() {
        const json = this.toJSON();
        let result = new Product();
        result.init(json);
        return result;
    }
}
export interface IProduct {
    id: string;
    name: string;
    photoUrl: string;
    productTagId: number;
    retailPrice: number;
    purchasePrice: number;
    unit: string;
    barCode: string;
    desc: string;
    showPhoto: string;
    pinYinCode: string;
    isEnable: number;
    lable: string;
    grade: number;
    productTagName: string;

    isDeleted: boolean;
    creationTime: Date;
    creatorUserId: number;
    lastModificationTime: Date;
    lastModifierUserId: number;
    deletionTime: Date;
    deleterUserId: number;
}