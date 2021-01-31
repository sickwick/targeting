FROM arm64v8/node:alpine

WORKDIR /app

COPY package.json /app/package.json
RUN npm install && npm install -g @angular/cli && npm cache clean --force

COPY . /app

CMD ng serve --host 0.0.0.0 --prod
