import { IOrderType } from "../Interfaces/ICommon";

export const FetchShippingCost = async(data: IOrderType) => {

    const fetchedOrder =  await fetch("https://localhost:44327/Order/CalculateShippingCost", {
            method : "PUT",
            body: JSON.stringify(data),
            headers: {
                "Content-type": "application/json;"
            }
    }).then((response) => {
        if (response.status === 200) {
            return response.json();
        }
    })
    .then(receivedData => {
        data.shippingCost = receivedData;
        data.totalPrice += receivedData;
        return data;
    });

    return fetchedOrder;
};

export const SaveOrders = async (data: IOrderType) => {

    await fetch('https://localhost:44327/Order/SaveOrder', {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "Content-type": "application/json;"
        }
    }).then((response) => {
        if (response.status === 200) {
            console.info("Order saved");
        }
    });
};