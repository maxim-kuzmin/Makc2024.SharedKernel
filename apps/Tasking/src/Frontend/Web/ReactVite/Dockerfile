ARG APP_PACKAGE=package*.json

FROM node:20.10-alpine as build
ARG APP_PATH
WORKDIR /app
ENV PATH /app/node_modules/.bin:$PATH
COPY $APP_PATH$APP_PACKAGE .
RUN npm ci
COPY $APP_PATH .
RUN npm run build

FROM nginx:stable-alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]