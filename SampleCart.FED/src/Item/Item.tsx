import { Button } from "@material-ui/core";
import React from "react";

//Types
import { ICartItemType } from "../Interfaces/ICommon";

//Styles
import { Wrapper } from "./Item.styles";

type Props = {
  item: ICartItemType;
  items: ICartItemType[];  
  addToCart: (clickedItem: ICartItemType) => void;
};

const Item: React.FC<Props> = ({ item, items, addToCart}) => (
  <Wrapper>
    <div>
      <h3>{item.title}</h3>
      <p>{item.description}</p>
      <h3>$ {item.price}</h3>
    </div>
    <Button onClick={() => addToCart(item)}>Add to cart</Button>
  </Wrapper>
);

export default Item;
