import {ProductDto} from "../../Models/ProductDto.js";
import {UserProductCategory} from "../../Models/UserProductCategory.js";

export interface IUserProductService {
    getUserProductsFromCategoryAsync(category: UserProductCategory) : Promise<Array<ProductDto>>
    deleteUserProductByIdFromCategoryAsync(productId: number, category: UserProductCategory) : Promise<ProductDto>
    addProductToUsersCategoryAsync(productId: number, category: UserProductCategory) : Promise<ProductDto>
}