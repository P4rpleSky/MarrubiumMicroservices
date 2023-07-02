import { BaseService } from "./BaseService.js";
import { ApiMethod } from "../Models/ApiMethod.js";
import { ApiRequest } from "../Models/ApiRequest.js";
import { ProductDto } from "../Models/ProductDto.js";
import { CategoryListsModel } from "../Models/CategoryListsModel.js";
export class ProductService extends BaseService {
    constructor(baseUrl) {
        super(baseUrl);
    }
    getProductByIdAsync(productId) {
        return this.sendAsync(new ApiRequest(ApiMethod.DELETE, `api/products/productId=${productId}`))
            .then(x => Object.assign(new ProductDto(), x));
    }
    getProductsAsync() {
        return this.sendAsync(new ApiRequest(ApiMethod.GET, "api/products"))
            .then(x => Object.assign(new Array(), x));
    }
    getProductCategoriesAsync() {
        return this.sendAsync(new ApiRequest(ApiMethod.GET, "api/products/categories"))
            .then(x => Object.assign(new CategoryListsModel(), x));
    }
}
//# sourceMappingURL=ProductService.js.map