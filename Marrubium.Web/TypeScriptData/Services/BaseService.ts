import {ApiRequest} from "../Models/ApiRequest.js";
import {ApiMethod} from "../Models/ApiMethod.js";
import {ExceptionHandler} from "../Models/ExceptionHandler.js";

export class BaseService {

    readonly baseUrl: string;
    constructor(baseUrl: string) {
        this.baseUrl = baseUrl;
    }
    protected sendAsync(apiRequest: ApiRequest): Promise<object> {
        const apiMethod=  apiRequest.apiMethod.toString();
        return fetch(this.baseUrl + apiRequest.urn, {
            body: apiRequest.apiMethod === ApiMethod.GET ? undefined : JSON.stringify(apiRequest.data),
            method: apiMethod,
            headers: { "Accept": "application/json", "Content-Type": "application/json" }
        })
            .then(x => x.json())
    }

}