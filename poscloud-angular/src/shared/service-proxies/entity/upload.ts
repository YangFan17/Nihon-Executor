export class UploadFileDto implements IUploadFileDto{
    uid: string;
    name: string;
    status: string;
    url: string;
    thumbUrl: string;

    constructor(data?: IUploadFileDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.uid = data["uid"];
            this.name = data["name"];
            this.status = data["status"];
            this.url = data["url"];
            this.thumbUrl = data["thumbUrl"];
        }
    }

    static fromJS(data: any): UploadFileDto {
        let result = new UploadFileDto();
        result.init(data);
        return result;
    }

    static fromJSArray(dataArray: any[]): UploadFileDto[] {
        let array = [];
        dataArray.forEach(result => {
            let item = new UploadFileDto();
            item.init(result);
            array.push(item);
        });

        return array;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["uid"] = this.uid;
        data["name"] = this.name;
        data["status"] = this.status;
        data["url"] = this.url;
        data["thumbUrl"] = this.thumbUrl;
        return data;
    }

    clone() {
        const json = this.toJSON();
        let result = new UploadFileDto();
        result.init(json);
        return result;
    }
}

export interface IUploadFileDto{
    uid: string;
    name: string;
    status: string;
    url: string;
    thumbUrl: string;
}