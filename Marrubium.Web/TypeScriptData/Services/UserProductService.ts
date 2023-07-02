import {IUserProductService} from "./IServices/IUserProductService.js";
import {ProductDto} from "../Models/ProductDto.js";
import {UserProductCategory} from "../Models/UserProductCategory.js";
import {BaseService} from "./BaseService.js";

export class UserProductService extends BaseService implements IUserProductService {

    constructor(baseUrl: string)  {
        super(baseUrl)
    }
    
    addProductToUsersCategoryAsync(productId: number, category: UserProductCategory): Promise<ProductDto> {
        throw new Error("Not Implemented")
    }

    deleteUserProductByIdFromCategoryAsync(productId: number, category: UserProductCategory): Promise<ProductDto> {
        throw new Error("Not Implemented")
    }

    getUserProductsFromCategoryAsync(category: UserProductCategory): Promise<Array<ProductDto>> {
        throw new Error("Not Implemented")
    }
    
}