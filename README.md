# DocManager-Prueba-Sinco

WebApi con funcionalidad para gestión documental
---

# Ejecutar proyecto
Escriba el siguiente comando en un CLI para ejecutar el docker-compose.yml en la carpeta raiz del proyecto  \DocManager-Prueba-Sinco
```shell
docker-compose -p docmanager-app up --build
```

Una vez descargue y esten listos los contenedores ejecute el siguiente comando para ver los contenedores

```shell
docker ps 
```
Con esto abrá instalado un contenedor con SQLServer

---
# Crear Tablas DB

Para crear las tablas de la base de datos vamos a usar migrations.
Vamos acceder a la siguiente ruta desde una consola: 

- \DocManager-Prueba-Sinco\DocManager.Infrastructure

Luego ejecutamos el siguiente comando para restaurar la migracion.

```shell
dotnet ef --startup-project ../docManager.api/ database update
```

Conectarse a la instancia de SQLServer

HOST: locahost
USER: sa
PASSWORD: docManager!123*

# Ejecutar solución

Abra la solución con visual studio y ejecute el proyecto con DocManager.Api

Importe la collection DocManager.postman_collection.json de postman que esta en la raiz del proyecto y ejecute los requests
