FROM golang:alpine as deps
EXPOSE 9001
WORKDIR /

COPY ./go.mod ./
COPY ./go.sum ./
RUN go mod download -x

FROM deps AS builder
COPY ./ ./
RUN go build -v -o /bin/server ./cmd/main.go

FROM arm64v8/golang:alpine
WORKDIR /app
COPY --from=builder /bin/server ./
CMD ["./server"]
