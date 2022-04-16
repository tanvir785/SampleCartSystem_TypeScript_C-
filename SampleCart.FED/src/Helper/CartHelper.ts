import { ICartItemType } from "../Interfaces/ICommon";

export const getTotalItems = (items: ICartItemType[]) => items.reduce((ack: number, item) => ack + item.quantity, 0);

export const handleAddToCart = (clickedItem: ICartItemType, items: ICartItemType[]) => {

    const isItemInCart = items.find(item => item.productID === clickedItem.productID);

    if (isItemInCart) {
      return items.map(item => 
        item.productID === clickedItem.productID ? { ...item, quantity: item.quantity + 1} : item
      )
    }
    //First time item is added
    return [ ...items, {...clickedItem, quantity: 1}]
};

export const handleRemoveFromCart = (productID: string, items: ICartItemType[]) => {
    return items.reduce((ack, item) => {
        if (item.productID === productID) {
          if(item.quantity === 1) return ack;
          return [...ack, {...item, quantity: item.quantity - 1}];
        } else {
          return [...ack, item];
        }
      }, [] as ICartItemType[])    
};