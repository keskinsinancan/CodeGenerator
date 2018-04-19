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
                    return "return JsonConvert.DeserializeObject<List<" + typeHelper.GetTypeName(response) + ">>(_restClient.Execute(request).Content);";
                }else{
                    return "No items in schema!!!!!";
                }
            }else if(schema.$ref){
                return "return JsonConvert.DeserializeObject<" + typeHelper.GetTypeName(response) + ">(_restClient.Execute(request).Content);";
            }else{
                return "return _restClient.Execute(request).Content;";
            }
        }
    }
    return null;
}