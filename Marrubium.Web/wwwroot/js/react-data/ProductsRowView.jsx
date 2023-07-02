import { ProductForm } from "./ProductForm.jsx"

export class ProductsRowView extends React.Component {

    constructor(props) {
        super(props);
        this.state = {};
    }

    render() {
        const products = [];
        this.props.productsList.forEach((product, index) => {
            products.push(
                <div key={product.productId} className="col-md-3">
                    <ProductForm product={product} ></ProductForm>
                </div>)
        });

        return (
            <div className="row products">
                {products}
            </div>

        );
    }
}