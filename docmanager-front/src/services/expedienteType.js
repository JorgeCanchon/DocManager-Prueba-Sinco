import axios from 'axios';
import * as constants from '../utils/constants';

export const GetAll = async () => {
    try{
        let result = await axios.get(constants.ENDPOINTS.ExpedienteType.GET);
        let data = result;
        return data;
    }catch(e){
        console.log(e);
        return { status: 500 };
    }
}