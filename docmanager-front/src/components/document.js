import React, { useState, Fragment, useEffect } from 'react';
import { Table, Button, Spin , message, Popconfirm, Layout} from 'antd';
import { downloadDocument, GetAll, GetByExpedienteId } from '../services/document';
const { Header, Content, Footer } = Layout;

export function Document(){

    const [loading, setLoading] = useState(false);
    const [documentState, setdocumentState] = useState([]);
    // const { documents } = useSelector(
    //     (document: any) => ({
    //     documents: document
    //     }),
    //     shallowEqual
    // );
    const documents = documentState;
    
    const handleDelete = async (key) => {    

    }

      useEffect(() => {
        getDataDocument();
    }, []);

    const getDataDocument = async () => {
        const value = getQueryParameter('expedienteId');
        let data = await GetByExpedienteId(value);
        console.log(data.data.result);
        switch(data.status){
        case 200:
            data = data.data.result.documents.map((x) => ({ ...x, key: x.id }));
            setdocumentState(data);
            break;
        case 204:
            message.warning('No se encontraron documents');
            break;
        default:
            message.error('Ocurrio un error al consultar los datos');
        }
        setLoading(false);
    }

    const getQueryParameter = (name) => {
        const queryString = window.location.search;
        const urlParams = new URLSearchParams(queryString);
        const value = urlParams.get(name);
        return value;
    }

    const columns = [
        {
        title: 'Id',
        dataIndex: 'id',
        width: '10%',
        },
        {
        title: 'Nombre',
        dataIndex: 'fileName',
        render: (text, record) => 
            documents.length >= 1 ? (
                <Fragment>{record.fileName}</Fragment> 
            ) : null,
        },
        {
        title: 'contentType',
        dataIndex: 'contentType',
        width: '20%',
        },
        {
        title: 'Descargar',
        dataIndex: 'Eliminar',
        render: (text, record) =>
            documents.length >= 1 ? (
            <a href={`http://localhost:5038/api/Document/download/${record.fileName}`} download={`${record.fileName}.pdf`}>Descargar Archivo</a>
            ) : null,
        },
        {
        title: 'Eliminar',
        dataIndex: 'Eliminar',
        render: (text, record) =>
            documents.length >= 1 ? (
                <Popconfirm title="¿Esta seguro de eliminar?" onConfirm= { () => handleDelete(record.key)}>
                    <a>Eliminar</a>
                </Popconfirm> 
            ) : null,
        }
    ];

    const handleAdd = () => {
    }

    if (loading)
      return(
      <Fragment>
          <Spin />
      </Fragment>);
    return(
        <Fragment>
        <Button onClick={handleAdd} type='primary' style ={{marginBottom:16}}>
            Agregar
        </Button>
            {/* <MyModal 
                title='Agregar Tarea'
                content={<FormTodo onFinish={handleOk.bind(this)} checked={checked} onChange={onChangeSwitch} categorias={categorias} />}
                visible={visible}
                handleCancel={handleCancel.bind(this)}
            /> */}
        <Table columns={columns} dataSource={documentState} rowKey="id" />
        </Fragment>
    );
}