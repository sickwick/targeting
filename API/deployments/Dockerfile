FROM golang:alpine as build
EXPOSE 9001
WORKDIR /build
COPY ./ ./

RUN apk --update --no-cache add git
RUN go mod download -x
RUN go build -o server ./cmd/main.go

FROM arm64v8/golang:alpine
WORKDIR /app
COPY --from=build /build/server server
CMD "/app/server"
