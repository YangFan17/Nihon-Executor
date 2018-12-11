export class Retailer implements IRetailer {
    id: string;
    name: string;
    code: string;
    licenseKey: string;
    businessAddress: string;
    archivalLevel: string;
    orderCycle: string;
    telephone: string;
    isAction: boolean;
    branchCompany: string;
    department: string;
    slsmanId: string;
    slsmanName: string;
    area: string;
    orderMode: number;
    terminalType: number;
    businessType: string;
    authorizationCode: string;
    actionText: string;
    actionType: string;
    retailerAuthorizationCode: string;

    isDeleted: boolean;
    creationTime: Date;
    creatorUserId: number;
    lastModificationTime: Date;
    lastModifierUserId: number;
    deletionTime: Date;
    deleterUserId: number;
    constructor(data?: IRetailer) {
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
            this.code = data["code"];
            this.licenseKey = data["licenseKey"];
            this.businessAddress = data["businessAddress"];
            this.archivalLevel = data["archivalLevel"];
            this.orderCycle = data["orderCycle"];
            this.telephone = data["telephone"];
            this.isAction = data["isAction"];
            this.branchCompany = data["branchCompany"];
            this.department = data["department"];
            this.slsmanId = data["slsmanId"];
            this.slsmanName = data["slsmanName"];
            this.area = data["area"];
            this.orderMode = data["orderMode"];
            this.terminalType = data["terminalType"];
            this.businessType = data["businessType"];
            this.authorizationCode = data["authorizationCode"];
            this.retailerAuthorizationCode = data["retailerAuthorizationCode"];

            this.isDeleted = data["isDeleted"];
            this.creationTime = data["creationTime"];
            this.creatorUserId = data["creatorUserId"];
            this.lastModificationTime = data["lastModificationTime"];
            this.lastModifierUserId = data["lastModifierUserId"];
            this.deletionTime = data["deletionTime"];
            this.deleterUserId = data["deleterUserId"];
        }
    }

    static fromJS(data: any): Retailer {
        let result = new Retailer();
        result.init(data);
        return result;
    }

    static fromJSArray(dataArray: any[]): Retailer[] {
        let array = [];
        dataArray.forEach(result => {
            let item = new Retailer();
            item.init(result);
            array.push(item);
        });

        return array;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["name"] = this.name;
        data["code"] = this.code;
        data["licenseKey"] = this.licenseKey;
        data["businessAddress"] = this.businessAddress;
        data["archivalLevel"] = this.archivalLevel;
        data["orderCycle"] = this.orderCycle;
        data["telephone"] = this.telephone;
        data["isAction"] = this.isAction;
        data["branchCompany"] = this.branchCompany;
        data["department"] = this.department;
        data["slsmanId"] = this.slsmanId;
        data["slsmanName"] = this.slsmanName;
        data["area"] = this.area;
        data["orderMode"] = this.orderMode;
        data["terminalType"] = this.terminalType;
        data["businessType"] = this.businessType;
        data["authorizationCode"] = this.authorizationCode;

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
        let result = new Retailer();
        result.init(json);
        return result;
    }
}
export interface IRetailer {
    id: string;
    name: string;
    code: string;
    licenseKey: string;
    businessAddress: string;
    archivalLevel: string;
    orderCycle: string;
    telephone: string;
    isAction: boolean;
    branchCompany: string;
    department: string;
    slsmanId: string;
    slsmanName: string;
    area: string;
    orderMode: number;
    terminalType: number;
    businessType: string;
    authorizationCode: string;
    actionText: string;
    actionType: string;
    retailerAuthorizationCode: string;

    isDeleted: boolean;
    creationTime: Date;
    creatorUserId: number;
    lastModificationTime: Date;
    lastModifierUserId: number;
    deletionTime: Date;
    deleterUserId: number;
}