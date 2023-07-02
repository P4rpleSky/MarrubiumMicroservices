import {ProductsRowView} from "../react-data/ProductsRowView.jsx";

export function addProductsToThePage(productsList) {
    let startIndex = 0;
    const productRows = [];
    while (startIndex < productsList.length) {
        let endIndex = Math.min(startIndex + 4, productsList.length);
        productRows.push(
            <ProductsRowView key={startIndex} productsList={productsList.slice(startIndex, endIndex)} />);
        startIndex = endIndex;
    }

    const rowsSection = document.getElementById("product-block")

    ReactDOM.render(
        productRows,
        rowsSection
    );
}