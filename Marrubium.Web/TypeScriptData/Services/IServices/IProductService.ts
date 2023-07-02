import {ProductDto} from "../../Models/ProductDto.js";
import {CategoryListsModel} from "../../Models/CategoryListsModel.js";

export interface IProductService {
    getProductsAsync() : Promise<Array<ProductDto>>
    getProductByIdAsync(productId: number) : Promise<ProductDto>
    getProductCategoriesAsync() : Promise<CategoryListsModel>
}