import axios from 'axios';
import * as constants from '../utils/constants';

export const GetAll = async () => {
    try{
        let result = await axios.get(constants.ENDPOINTS.Document.GET);
        let data = result;
        return data;
    }catch(e){
        console.log(e);
        return { status: 500 };
    }
}


export const GetByExpedienteId = async (expedienteId) => {
    try{
        let result = await axios.get(constants.ENDPOINTS.Document.GET_BY_EXPEDIENTE_ID+expedienteId);
        let data = result;
        return data;
    }catch(e){
        console.log(e);
        return { status: 500 };
    }
}

export const downloadDocument = async (fileName) => {
    try{
        let result = await axios.get(constants.ENDPOINTS.Document.DOWNLOAD+fileName);
        let data = result;
        return data;
    }catch(e){
        console.log(e);
        return { status: 500 };
    }
}