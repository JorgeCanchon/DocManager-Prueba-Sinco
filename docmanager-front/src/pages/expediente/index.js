import React, { Fragment } from 'react';
import { Helmet } from 'react-helmet';
import { Expediente } from '../../components/expediente';

export const ExpedienteComponent = () => {
    return (
        <Fragment>
            <Expediente />
        </Fragment>
    )
}

export default ExpedienteComponent;