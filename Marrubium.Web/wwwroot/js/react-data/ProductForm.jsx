import {UserProductService} from "../Services/UserProductService.js";
import {UserProductCategory} from "../Models/UserProductCategory.js";
import {ExceptionHandler} from "../Models/ExceptionHandler.js";

export class ProductForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = { };
        this.userProductService = new UserProductService(undefined)
        this.onLikeButtonClick = this.onLikeButtonClick.bind(this);
    }

    onLikeButtonClick(e) {
        if (e.target.style.backgroundImage === 'url("../img/favourite_click.png")') {
            this.userProductService.deleteUserProductByIdFromCategoryAsync(
                this.props.product.productId, 
                UserProductCategory.Favourite)
                .then(() => e.target.style.backgroundImage = "")
                .catch(x => ExceptionHandler.handle(x));
        }
        else {
            this.userProductService.addProductToUsersCategoryAsync(
                this.props.product.productId,
                UserProductCategory.Favourite)
                .then(() => e.target.style.backgroundImage = 'url("../img/favourite_click.png")')
                .catch(x => ExceptionHandler.handle(x));
        }
    }

    render() {
        const productPageUrl = `/catalog/${this.props.product.productId}`;
        // const favImageUrl = this.props.product.IsInFavourite ? 'url("../img/favourite_click.png")' : ""
        const favImageUrl = ''
        return (
            <div className="product-section">
                <div className="visual">
                    <a className="product-preview" style={{ backgroundImage: `url("${this.props.product.imageUrl}")` }} href={productPageUrl}></a>
                    <a className="set-like favourite" style={{ backgroundImage: favImageUrl }} onClick={this.onLikeButtonClick }></a>
                </div>
                <a className="s2" href={productPageUrl}>{this.props.product.name}</a>
                <p className="s3">{this.props.product.price.toString()}</p>
            </div>
        );
    }
}