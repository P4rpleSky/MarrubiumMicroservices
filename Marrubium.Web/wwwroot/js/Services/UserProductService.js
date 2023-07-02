import { BaseService } from "./BaseService.js";
export class UserProductService extends BaseService {
    constructor(baseUrl) {
        super(baseUrl);
    }
    addProductToUsersCategoryAsync(productId, category) {
        throw new Error("Not Implemented");
    }
    deleteUserProductByIdFromCategoryAsync(productId, category) {
        throw new Error("Not Implemented");
    }
    getUserProductsFromCategoryAsync(category) {
        throw new Error("Not Implemented");
    }
}
//# sourceMappingURL=UserProductService.js.map