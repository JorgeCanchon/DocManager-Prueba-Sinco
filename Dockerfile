# --- Etapa de construcción (Build Stage) ---
# Usa una imagen de Node.js para construir la aplicación React
FROM node:20-alpine AS build-stage

# Establece el directorio de trabajo dentro del contenedor
WORKDIR /app

# Copia los archivos package.json y package-lock.json para instalar dependencias
COPY package*.json ./

# Instala las dependencias de Node.js
RUN npm install

# Copia el resto de los archivos de la aplicación React
COPY . .

# Construye la aplicación React para producción
RUN npm run build

# --- Etapa de producción (Production Stage) ---
# Usa una imagen ligera de Nginx para servir los archivos estáticos de React
FROM nginx:stable-alpine AS production-stage

# Copia los archivos construidos de React desde la etapa de construcción al directorio de Nginx
COPY --from=build-stage /app/build /usr/share/nginx/html

# Opcional: Copia una configuración personalizada de Nginx si la necesitas
# COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expone el puerto 80, que es el puerto por defecto de Nginx
EXPOSE 80

# Comando para iniciar Nginx cuando el contenedor se ejecute
CMD ["nginx", "-g", "daemon off;"]