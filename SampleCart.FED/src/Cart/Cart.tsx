import { useEffect, useState } from "react";
import {useNavigate } from "react-router-dom";

import CartItem from "../CartItem/CartItem";
import { Button } from "@material-ui/core";

//Styles
import { Wrapper } from "./Cart.styles";

//Types
import { FetchShippingCost, SaveOrders } from "../API/APICaller";
import { ICartItemType, IOrderType } from "../Interfaces/ICommon";

type Props = {
    cartItems: ICartItemType[];
    addToCart: (clickedItem: ICartItemType) => void;
    removeFromCart: (productID: string) => void;
}

const Cart: React.FC<Props> = ({ cartItems, addToCart, removeFromCart }) => {

    const [orders, setOrders] = useState({} as IOrderType);
    let navigate = useNavigate();

    useEffect(() => {
        calculateTotal(cartItems);
    }, [cartItems]);

    const calculateTotal = async (items: ICartItemType[]) => {
        const newOrder = {} as IOrderType;
        newOrder.totalPrice = items.reduce((previousValue, item) => previousValue +(item.quantity * item.price), 0);
        let orderItems = (items.map((item) => {
            return {
              productID: item.productID,
              quantity: item.quantity         
            }
          }));
        newOrder.items = orderItems;
        setOrders(await (FetchShippingCost(newOrder)));        
    }

    const checkout = async() => {
        await SaveOrders(orders);
        navigate('/thankyou')
    }

    return (
        <Wrapper>
            <h2>Your Shopping Cart</h2>
            {cartItems.length === 0 ? <p>No items in cart.</p> : null}
            {cartItems.map((item: ICartItemType) => 
                <CartItem 
                    key={item.productID}
                    item={item}
                    addToCart={addToCart}
                    removeFromCart={removeFromCart}
                />
            )}
            <h3>Shipping Cost: $ {orders.shippingCost}</h3>
            <h2>Total: $ {orders.totalPrice}</h2>
            <h2><Button 
                    size="small"
                    disableElevation
                    variant="contained" onClick={() => checkout()}> 
                    Checkout
                </Button>
            </h2>
        </Wrapper>
    )
}

export default Cart;