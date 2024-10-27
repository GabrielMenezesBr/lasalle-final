FROM node:18 AS build

ENV NODE_ENV=Production

WORKDIR /app

COPY package.json package-lock.json ./
COPY ./public ./public
COPY ./src ./src

RUN npm install

RUN npm run build

FROM nginx:alpine

COPY --from=build /app/build /usr/share/nginx/html

COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
