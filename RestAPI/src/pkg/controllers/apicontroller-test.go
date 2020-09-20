package controllers

import (
	"encoding/json"
	"net/http"
)

type testStruct struct {
	TypeName string
	Message  string
}

func GetTestAnswer(w http.ResponseWriter, r *http.Request) {
	response := &testStruct{TypeName: "response", Message: "It's a test controller written in go"}
	res, _ := json.Marshal(response)
	w.Write(res)
}
