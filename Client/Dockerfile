FROM node:10-alpine as builder
WORKDIR /app
COPY package.json .
RUN npm install
COPY . .
RUN npm run build:prod

FROM nginx:alpine
EXPOSE 80 443
COPY ./nginx/default.conf /etc/nginx/conf.d/default.conf
RUN ls -al
COPY --from=builder /app/dist/Client /usr/share/nginx/html