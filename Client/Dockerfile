
FROM node:10-alpine as builder
WORKDIR /app
ADD package.json /app
RUN npm install
ADD . /app
RUN npm run build:prod

FROM nginx:alpine
EXPOSE 4200
COPY /nginx/default.conf /etc/nginx/conf.d/default.conf
COPY --from=builder /app/dist/cßlient /usr/share/nginx/html