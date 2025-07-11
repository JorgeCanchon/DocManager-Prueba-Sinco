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

export const ENDPOINTS = {
    Expediente,
    ExpedienteType
}