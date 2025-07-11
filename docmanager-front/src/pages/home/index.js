import { Helmet } from 'react-helmet';
import React, { useEffect, Fragment } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux'; // Si usas Redux

export const Home = () => {
const location = useLocation(); // Accede al objeto de ubicación (contiene pathname)
  const navigate = useNavigate(); // Obtiene la función de navegación
  const dispatch = useDispatch(); // Hook de Redux
 const handleLoginSuccess = () => {
    // Después de un login exitoso, podrías querer redirigir
    // Esto se puede llamar desde un thunk o saga también
    navigate('/expediente');
  };

  const handleGoBack = () => {
    navigate(-1); // Volver una página
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
      <button onClick={handleLoginSuccess}>Ir al expediente (Ejemplo)</button>
      <button onClick={handleGoBack}>Volver</button>
    </div>
        </Fragment>
    )
}

export default Home;