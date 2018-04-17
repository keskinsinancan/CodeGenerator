const Handlebars = require("handlebars");

module.exports.GetFunctionParameter = function (parameters) {
    var str = "";
    for (var parameter in parameters) {
        var param = parameters[parameter];
        if(param.name === "body"){
            str += param.dataType.typeName + " " + param.dataType.typeName.replace("[]", "").toLowerCase() + ", ";
        }else{
            str += param.dataType.typeName + " " + param.name + ", ";            
        }
        
    }
    if (str) {
        return str.substring(0, str.length - 2);
    } else {
        return "";
    }
}

module.exports.GetRequestParameter = function (parameter) {
    switch (parameter.paramType) {
        case "body":
            if (parameter.name === "body") {
                return new Handlebars.SafeString("request.AddBody(" + parameter.dataType.typeName.replace("[]", "").toLowerCase() + ");");
            } else {
                return new Handlebars.SafeString("request.AddBody(\"" + parameter.dataType.typeName + "\");*******");
            }
        case "query":
            return new Handlebars.SafeString("request.AddQueryParameter(\"" + parameter.name + "\"," + parameter.name + "); // Array geldiginde sorun!!!!!!");
        case "path":
            return new Handlebars.SafeString("request.AddParameter(\"" + parameter.name + "\"," + parameter.name + ");");
        case "header":
            return new Handlebars.SafeString("request.AddHeader(\"" + parameter.name + "\"," + parameter.name + ");");
        case "formData":
            return new Handlebars.SafeString("request.AddParameter(\"" + parameter.name + "\"," + parameter.name + ");//????????");
    }


}