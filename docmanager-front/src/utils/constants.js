export const API_URL = 'http://localhost:5038/api/';

export const Expediente = {
    GETBYID: `${API_URL}Expediente`,
    GET: `${API_URL}Expediente`,
    DELETE: `${API_URL}Expediente`,
    ADD: `${API_URL}Expediente`,
    PUT: `${API_URL}Expediente`
}

export const ExpedienteType = {
    GETBYID: `${API_URL}ExpedienteType`,
    GET: `${API_URL}ExpedienteType`,
    DELETE: `${API_URL}ExpedienteType`,
    ADD: `${API_URL}ExpedienteType`,
    PUT: `${API_URL}ExpedienteType`
}

export const Document = {
    GETBYID: `${API_URL}Document`,
    GET: `${API_URL}Document`,
    DELETE: `${API_URL}Document`,
    ADD: `${API_URL}Document`,
    PUT: `${API_URL}Document`,
    GET_BY_EXPEDIENTE_ID: `${API_URL}Document/Expediente/`,
    DOWNLOAD:  `${API_URL}Document/download/`
}

export const ENDPOINTS = {
    Expediente,
    ExpedienteType,
    Document
}