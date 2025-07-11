import React, {StrictMode} from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
import { ConfigProvider } from 'antd';
import esES from 'antd/es/locale/es_ES';
import 'antd/dist/reset.css';
import RouterComponent from './Router';
import { createHashHistory } from 'history';
import { routerMiddleware } from 'connected-react-router';
import {thunk} from 'redux-thunk';
import { createStore, applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import reducers from './redux';
import { BrowserRouter } from "react-router-dom";

const history = createHashHistory();
const root = ReactDOM.createRoot(document.getElementById('root'));
const routeMiddleware = routerMiddleware(history);
const middlewares = [thunk, routeMiddleware];

const store = createStore(reducers(history), applyMiddleware(...middlewares));

root.render(
   <React.StrictMode>
       <BrowserRouter>
        <Provider store={store}>
        <ConfigProvider locale={esES}>
          <RouterComponent history={history} />
        </ConfigProvider>
      </Provider>
    </BrowserRouter>
   </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
