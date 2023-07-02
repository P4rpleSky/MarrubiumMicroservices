import {ProductService} from "../Services/ProductService.js";
import {ExceptionHandler} from "../Models/ExceptionHandler.js";
import {addProductsToThePage} from "../react-data/add_products_to_the_page.jsx";

const productService = new ProductService("https://localhost:7259/");

let productTypesBox = document.getElementById('type-of-product');
let functionsBox = document.getElementById('function');
let skinTypesBox = document.getElementById('skin-type');

productService.getProductCategoriesAsync()
    .then(x => {
        x.productTypes.forEach(y => productTypesBox.innerHTML += `<option value="${y}">${y}</option>`);
        x.functions.forEach(y => functionsBox.innerHTML += `<option value="${y}">${y}</option>`);
        x.skinTypes.forEach(y => skinTypesBox.innerHTML += `<option value="${y}">${y}</option>`);
    })
    .catch(x => ExceptionHandler.handle(x));

productService.getProductsAsync()
    .then(products => addProductsToThePage(products))
    .catch(x => ExceptionHandler.handle(x));
