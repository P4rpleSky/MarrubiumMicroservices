import {IProductService} from "./IServices/IProductService.js";
import {BaseService} from "./BaseService.js";
import {ApiMethod} from "../Models/ApiMethod.js";
import {ApiRequest} from "../Models/ApiRequest.js";
import {ProductDto} from "../Models/ProductDto.js";
import {CategoryListsModel} from "../Models/CategoryListsModel.js";


export class ProductService extends BaseService implements IProductService {
    
    constructor(baseUrl: string)  {
        super(baseUrl)
    }

    getProductByIdAsync(productId: number): Promise<ProductDto> {
        return this.sendAsync(new ApiRequest(
            ApiMethod.DELETE,
            `api/products/productId=${productId}`
        ))
            .then(x => Object.assign(new ProductDto(), x));
    }

    getProductsAsync(): Promise<Array<ProductDto>> {
        return this.sendAsync(new ApiRequest(
            ApiMethod.GET,
            "api/products"
        ))
            .then(x => Object.assign(new Array<ProductDto>(), x));
    }

    getProductCategoriesAsync(): Promise<CategoryListsModel> {
        return this.sendAsync(new ApiRequest(
            ApiMethod.GET,
            "api/products/categories"
        ))
            .then(x => Object.assign(new CategoryListsModel(), x));
    }
}