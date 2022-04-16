import Button from "@material-ui/core/Button";

//Types
import { ICartItemType } from "../Interfaces/ICommon";

//Styles
import { Wrapper } from "./CartItem.styles";

type Props = {
  item: ICartItemType;
  items: ICartItemType[];
  addToCart: (clickedItem: ICartItemType) => void;
  removeFromCart: (productID: string) => void;
};

const CartItem: React.FC<Props> = ({ item, items, addToCart, removeFromCart }) => (
  <Wrapper>
    <div>
      <h3>{item.title}</h3>
      <div className="information">
        <p>Price: $ {item.price}</p>
      </div>
      <div className="buttons">
        <Button
          size="small"
          disableElevation
          variant="contained"
          onClick={() => removeFromCart(item.productID)}
        > - </Button>
        <p>{item.quantity}</p>
        <Button
          size="small"
          disableElevation
          variant="contained"
          onClick={() => addToCart(item)}
        > + </Button>
      </div>
    </div>
  </Wrapper>
);

export default CartItem;
