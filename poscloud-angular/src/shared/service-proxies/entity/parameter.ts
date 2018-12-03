export class Parameter {
    key: string;
    value: any;

    init(data?: any) {
        if (data) {
            this.key = data["key"];
            this.value = data["value"];
        }
    }

    static fromJS(data: any): Parameter {
        let result = new Parameter();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["key"] = this.key;
        data["value"] = this.value;

        return data;
    }

    static toJSONArray(array: Parameter[]) {
        let dataArray = [];
        array.forEach(para => {
            let data = typeof para === 'object' ? para : {};
            data["key"] = para.key;
            data["value"] = para.value;
        });

        return dataArray;
    }
}

export class ApiResult {
    code: number;
    msg: string;
    data: any;

    init(data?: any) {
        if (data) {
            this.code = data["code"];
            this.msg = data["msg"];
            this.data = data["data"];
        }
    }

    static fromJS(data: any): ApiResult {
        let result = new ApiResult();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["code"] = this.code;
        data["msg"] = this.msg;
        data["data"] = this.data;

        return data;
    }
}