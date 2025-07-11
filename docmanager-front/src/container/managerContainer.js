import React from 'react';
import { Layout, Spin } from 'antd';
import Home from '../pages/home';
import { Routes,  Route, Link } from "react-router-dom";
import NotFoundPage from '../pages/404';
import ExpedienteTypeComponent from '../pages/expedienteType';
import ExpedienteComponent from '../pages/expediente';
import DocumentComponent from '../pages/document';

const { Header, Content, Footer } = Layout;

export const ManagerContainer = ({ children }) => {

        return (
        <Layout>
            <Header>
                <h3 style={{color:'#ffffff'}}>DocManager</h3>
            </Header>
            <Content style={{margin: '15px'}}>
                <Routes>
                <Route path='/'>
                    <Route index path='/' element={<Home />} />
                    <Route path='/expediente' element={<ExpedienteComponent />} />
                    <Route path='/expedienteType' element={<ExpedienteTypeComponent />} />
                    <Route path='/document' element={<DocumentComponent />} />
                    <Route path='/404' element={<NotFoundPage/>} />
                    <Route path="*" element={NotFoundPage} />
                </Route>
                </Routes>
            </Content>
            <Footer>Copyright&copy; {new Date().getFullYear()} - Página creada por Jorge Canchon - Todos los derechos reservados </Footer>
      </Layout>
    );
}

export default ManagerContainer;