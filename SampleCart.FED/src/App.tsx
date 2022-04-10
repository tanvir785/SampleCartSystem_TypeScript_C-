import { useState } from "react";
import { useQuery } from "react-query";

//components
import { Drawer, LinearProgress, Grid, Badge } from "@material-ui/core";
import { AddShoppingCartSharp } from "@material-ui/icons";
import Item from "./Item/Item";
import Cart from "./Cart/Cart";

//styles
import { Wrapper, StyledButton } from "./App.styles";
import { ICartItemType } from "./Interfaces/ICommon";

const getProducts = async (): Promise<ICartItemType[]> => {
  return (await fetch("https://localhost:44327/Product/GetProducts")).json();
};

const App = () => {
  const [cartOpen, setCartOpen] = useState(false);
  const [cartItems, setCartItems] = useState([] as ICartItemType[]);  

  const { data, isLoading, error } = useQuery<ICartItemType[]>(
    "productID",
    getProducts
  );

  const getTotalItems = (items: ICartItemType[]) => items.reduce((ack: number, item) => ack + item.quantity, 0);

  const handleAddToCart = (clickedItem: ICartItemType) => {
    setCartItems(prev => {
      //1. is item already added in the cart?
      const isItemInCart = prev.find(item => item.productID === clickedItem.productID);

      if (isItemInCart) {
        return prev.map(item => 
          item.productID === clickedItem.productID ? { ...item, quantity: item.quantity + 1} : item
        )
      }
      //First time item is added
      return [ ...prev, {...clickedItem, quantity: 1}]
    })
  };

  const handleRemoveFromCart = (productID: string) => {
    setCartItems(prev => (
      prev.reduce((ack, item) => {
        if (item.productID === productID) {
          if(item.quantity === 1) return ack;
          return [...ack, {...item, quantity: item.quantity - 1}];
        } else {
          return [...ack, item];
        }
      }, [] as ICartItemType[])
    ))
  };
  
  if (isLoading) return <LinearProgress />;
  if (error) return <div>Something went wrong ...</div>;
  return (
    <Wrapper>
      <Drawer anchor="right" open={cartOpen} onClose={() => setCartOpen(false)}>
        <Cart
          cartItems={cartItems}
          addToCart={handleAddToCart}
          removeFromCart={handleRemoveFromCart}
        />
      </Drawer>
      <StyledButton onClick={() => setCartOpen(true)}>
        <Badge badgeContent={getTotalItems(cartItems)} color="error">
          <AddShoppingCartSharp />
        </Badge>
      </StyledButton>
      <Grid container spacing={3}>
        {data?.map((item: ICartItemType) => {
          return (
            <Grid item key={item.productID} xs={12} sm={4}>
              <Item item={item} handleAddToCart={handleAddToCart} />
            </Grid>
          );
        })}
      </Grid>
    </Wrapper>
  );
};

export default App;
