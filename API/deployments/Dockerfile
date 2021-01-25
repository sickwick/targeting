#FROM golang:1.14-buster AS deps
#EXPOSE 8081
#WORKDIR /
#
#
#COPY ./go.mod ./
#COPY ./go.sum ./
#RUN go mod download -x
#
#FROM deps AS builder
#COPY ./ ./
#RUN go build -v -o /bin/server ./cmd/main.go
#
#FROM debian:buster-slim
#RUN set -x && apt-get update && \
#  DEBIAN_FRONTEND=noninteractive apt-get install -y ca-certificates && \
#  rm -rf /var/lib/apt/lists/*
#
#WORKDIR /app
#COPY --from=builder /bin/server ./
#
#CMD ["./server"]
FROM golang:alpine  as build
EXPOSE 8081
WORKDIR /build
COPY ./ ./

RUN apk --update --no-cache add git
RUN go mod download
RUN go build -o server ./cmd/main.go

FROM alpine:latest
WORKDIR /app
COPY --from=build /build/server server
CMD "/app/server"
