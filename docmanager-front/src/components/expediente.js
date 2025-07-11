import React, { useState, Fragment, useEffect } from 'react';
import { Table, Button, Spin , message, Popconfirm, Layout} from 'antd';
import { GetAll } from '../services/expediente';
const { Header, Content, Footer } = Layout;

export function Expediente(){

    const [loading, setLoading] = useState(false);
    const [expedienteState, setExpedienteState] = useState([]);
    // const { expedientes } = useSelector(
    //     (expediente: any) => ({
    //     expedientes: expediente
    //     }),
    //     shallowEqual
    // );
    const expedientes = expedienteState;
    
    const handleDelete = async (key) => {    
        // let res = await DeleteTodo(key);
        // if(res.status === 200){
        //     message.success('Tarea eliminada con éxito');
        //     let data = todoState.filter(x => x.id !== key);
        //     setTodoState(data);
        //     dispatch(deleteTodo(key));
        // }else{
        // message.error('Ocurrio un error al eliminar la tarea');
        // }
    }

      useEffect(() => {
        getDataExpediente();
    }, []);

    const getDataExpediente = async () => {
        let data = await GetAll();
        console.log(data.data.result);
        switch(data.status){
        case 200:
            data = data.data.result.expedientes.map((x) => ({ ...x, key: x.id }));
            setExpedienteState(data);
            break;
        case 204:
            message.warning('No se encontraron expedientes');
            break;
        default:
            message.error('Ocurrio un error al consultar los datos');
        }
        setLoading(false);
    }

    const columns = [
        {
        title: 'Id',
        dataIndex: 'id',
        width: '10%',
        },
        {
        title: 'Nombre expediente',
        dataIndex: 'expedienteType.name',
        render: (text, record) => 
            expedientes.length >= 1 ? (
                <Fragment>{record.expedienteType.name}</Fragment> 
            ) : null,
        },
        {
        title: 'Identificador',
        dataIndex: 'uniqueIdentifier',
        width: '20%',
        },
        {
        title: 'Detalle',
        dataIndex: 'Campos',
        render: (text, record) =>
            expedientes.length >= 1 ? (
                 <Fragment>
                    <a href='/campos'>Ver</a>
                </Fragment> 
            ) : null,
        },
        {
        title: 'Documentos',
        dataIndex: 'Documentos',
        render: (text, record) =>
            expedientes.length >= 1 ? (
                <Fragment>
                    <a href={`document?expedienteId=${record.id}`}>Ver</a>
                </Fragment> 
            ) : null,
        },
        {
        title: 'Eliminar',
        dataIndex: 'Eliminar',
        render: (text, record) =>
            expedientes.length >= 1 ? (
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
        <Table columns={columns} dataSource={expedienteState} rowKey="id" />
        </Fragment>
    );
}