const typeHelper = require("./typeNameHelper");

module.exports.GetFunctionReturnType = function (operation) {
    for (resp in operation.responseMessages) {
        var response = operation.responseMessages[resp];
        if (response.code === "200") {
            if (response.schema.type === "array") {
                return "List<" + typeHelper.GetTypeName(response) + ">";
            }
            return typeHelper.GetTypeName(response);
        }
    }
    return null;
}

module.exports.GetFunctionReturn = function (operation) {
    for (resp in operation.responseMessages) {
        var response = operation.responseMessages[resp];
        if (response.code === "200") {
            var schema = response.schema;
            if (schema.type === "array") {
                if (schema.items) {
                    return "return _restClient.Execute<List<" + typeHelper.GetTypeName(response) + ">>(request).Data;";
                }else{
                    return "return _restClient.Execute(request).Content---------------------";
                }
            }else if(schema.$ref){
                return "return _restClient.Execute<" + typeHelper.GetTypeName(response) + ">(request).Data;";
            }else{
                return "return _restClient.Execute(request).Content;";
            }
        }
    }
    return null;
}