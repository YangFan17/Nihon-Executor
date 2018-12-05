export class SelectGroup implements ISelectGroup {
    text: string;
    value: string;
    constructor(data?: ISelectGroup) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.text = data["text"];
            this.value = data["value"];
        }
    }

    static fromJS(data: any): SelectGroup {
        let result = new SelectGroup();
        result.init(data);
        return result;
    }

    static fromJSArray(dataArray: any[]): SelectGroup[] {
        let array = [];
        dataArray.forEach(result => {
            let item = new SelectGroup();
            item.init(result);
            array.push(item);
        });

        return array;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["text"] = this.text;
        data["value"] = this.value;
        return data;
    }

    clone() {
        const json = this.toJSON();
        let result = new SelectGroup();
        result.init(json);
        return result;
    }
}
export interface ISelectGroup {
    text: string;
    value: string;
}