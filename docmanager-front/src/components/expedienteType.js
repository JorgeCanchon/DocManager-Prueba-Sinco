import React, { useState, Fragment, useEffect } from 'react';
import { Table, Button, Spin , message, Popconfirm, Layout} from 'antd';
import { GetAll } from '../services/expedienteType';

const { Header, Content, Footer } = Layout;

export function ExpedienteType(){

    const [loading, setLoading] = useState(false);
    const [expedienteTypeState, setExpedientesType] = useState([]);
    // const { expedientes } = useSelector(
    //     (expediente: any) => ({
    //     expedientes: expediente
    //     }),
    //     shallowEqual
    // );
    const expedientesType = expedienteTypeState;
    
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
        getDataExpedienteType();
    }, []);

    const getDataExpedienteType = async () => {
        let data  = await GetAll();
        console.log(data.data.result);
        switch(data.status){
        case 200:
            data = data.data.result.expedienteTypes.map((x) => ({ ...x, key: x.id }));
            setExpedientesType(data);
            break;
        case 204:
            message.warning('No se encontraron tipos de expedientes');
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
        title: 'Nombre',
        dataIndex: 'name',
        render: (text, record) => 
            expedientesType.length >= 1 ? (
                <Fragment>{record.name}</Fragment> 
            ) : null,
        },
        {
        title: 'Descripción',
        dataIndex: 'description',
        width: '20%',
        },
        {
        title: 'Expedientes',
        dataIndex: 'Campos',
        render: (text, record) =>
            expedientesType.length >= 1 ? (
                 <Fragment>
                    <a href='/expedientes'>Ver</a>
                </Fragment> 
            ) : null,
        },
        {
        title: 'Campos',
        dataIndex: 'Campos',
        render: (text, record) =>
            expedientesType.length >= 1 ? (
                 <Fragment>
                    <a href='/campos'>Ver</a>
                </Fragment> 
            ) : null,
        },
        {
        title: 'Fecha creación',
        dataIndex: 'created',
        width: '20%',
        },
        {
        title: 'Eliminar',
        dataIndex: 'Eliminar',
        render: (text, record) =>
            expedientesType.length >= 1 ? (
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
        <Table columns={columns} dataSource={expedienteTypeState} rowKey="id" />
        </Fragment>
    );
}