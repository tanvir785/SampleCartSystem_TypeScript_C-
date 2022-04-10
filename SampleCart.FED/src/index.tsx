import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import { QueryClient, QueryClientProvider } from "react-query";
import {BrowserRouter,Routes,Route} from "react-router-dom";
import { Thankyou } from "./Thankyou";

const client = new QueryClient();

ReactDOM.render(
  <QueryClientProvider client={client}>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<App/>}/>
        <Route path="/thankyou" element={<Thankyou/>}/>
      </Routes>
    </BrowserRouter>
  </QueryClientProvider>, 
document.getElementById("root")
);
