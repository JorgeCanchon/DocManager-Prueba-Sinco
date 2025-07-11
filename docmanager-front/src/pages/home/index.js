import { Helmet } from 'react-helmet';
import React, { useEffect, Fragment } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux'; 

export const Home = () => {
const location = useLocation(); 
  const navigate = useNavigate(); 
  const dispatch = useDispatch(); 
 const handleLoginSuccess = () => {
    navigate('/expediente');
  };

  const handleGoBack = () => {
    navigate(-1); 
  };
  useEffect(() => {
    // Si necesitas que Redux sepa sobre los cambios de URL:
    // dispatch(updateRouteState(location.pathname));
    console.log("La ruta actual es:", location.pathname);
  }, [location, dispatch]); 

    return (
        <Fragment>
            <Helmet title='Home' />
           <h1>Bienvenido</h1> 
               <div>
      <p>Componente en ruta: {location.pathname}</p>
      <button onClick={handleLoginSuccess}>Ir a tipos de expediente</button>
      <button onClick={handleGoBack}>Volver</button>
    </div>
        </Fragment>
    )
}

export default Home;