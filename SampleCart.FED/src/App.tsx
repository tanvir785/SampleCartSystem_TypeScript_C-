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
import { getTotalItems, handleAddToCart, handleRemoveFromCart } from "./Helper/CartHelper";

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

  const addToCart = (clickedItem: ICartItemType) => {
    setCartItems(handleAddToCart(clickedItem, cartItems));
  }

  const removeFromCart = (productID: string) => {
    setCartItems(handleRemoveFromCart(productID, cartItems));
  }

  if (isLoading) return <LinearProgress />;
  if (error) return <div>Something went wrong ...</div>;
  return (
    <Wrapper>
      <Drawer anchor="right" open={cartOpen} onClose={() => setCartOpen(false)}>
        <Cart
          cartItems={cartItems}
          addToCart ={addToCart}
          removeFromCart = {removeFromCart}
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
              <Item item={item} items={cartItems} addToCart ={addToCart}/>
            </Grid>
          );
        })}
      </Grid>
    </Wrapper>
  );
};

export default App;
