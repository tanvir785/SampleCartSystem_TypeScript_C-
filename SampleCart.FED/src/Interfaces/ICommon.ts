
export interface IProductItem {
    productID: string;
    description: string;
    price: number;
    title: string;
  };

export interface ICartItemType extends  IProductItem {
    quantity: number;
}
  
export interface IOrder {
    productID: string;
    quantity: number;
}
  
export interface IOrderType {
    items: IOrder[];
    totalPrice: number;
    shippingCost: number;
}