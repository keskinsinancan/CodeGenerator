const Handlebars = require("handlebars");

module.exports.GetFunctionParameter = function (parameters) {
    var params = []; // For all parameters except nullable ones
    var nullableParams = []; // For nullable parameters
    for (var parameter in parameters) {
        var param = parameters[parameter];
        var str = "";
        if(param.required){ // If parameter cannot be nullable then add parameter type and name
            if (param.name === "body") {
                str = param.dataType.typeName + " " + param.dataType.typeName.replace("[]", "").toLowerCase();
            } else {
                str = param.dataType.typeName + " " + param.name;
            }
            params.push(str);
        } else{ // If parameter can be nullable then add parameter type and name
            if (param.name === "body") {
                str = param.dataType.typeName + " " + param.dataType.typeName.replace("[]", "").toLowerCase() + " = null";
            } else {
                str = param.dataType.typeName + " " + param.name + " = null";
            }
            nullableParams.push(str);
        }
    }
    str = "";
    params = params.concat(nullableParams);
    for(var param in params){
        str += params[param] + ", ";
    }

    if (str) {
        return new Handlebars.SafeString(str.substring(0, str.length - 2));
    } else {
        return "";
    }
}

module.exports.GetRequestParameter = function (parameter) {
    // If parameter is not required then add parameter if it is not null
    var start = "";
    var end = ""
    if(!parameter.required){
        start = "if(" + parameter.name + " != null) { " 
        end = " }";
    }
    switch (parameter.paramType) {
        case "body":
            if (parameter.name === "body") {
                return new Handlebars.SafeString(
                    "request.AddBody(" + parameter.dataType.typeName.replace("[]", "").toLowerCase() + ");");
            } else {
                return new Handlebars.SafeString(
                    "request.AddBody(\"" + parameter.dataType.typeName + "\");*******");
            }
        case "query":
            if (parameter.dataType.isArray) {
                return new Handlebars.SafeString( start + 
                    "foreach( var p in " + parameter.name + "){ " +
                    "request.AddQueryParameter(\"" + parameter.name +
                    "\", p); "+ end + " } ");
            }
            return new Handlebars.SafeString( start +
                "request.AddQueryParameter(\"" + parameter.name + "\"," + parameter.name + ");" + end);
        case "path":
            return new Handlebars.SafeString( start +
                "request.AddUrlSegment(\"" + parameter.name + "\"," + parameter.name + ");" + end);
        case "header":
            return new Handlebars.SafeString( start +
                "request.AddHeader(\"" + parameter.name + "\"," + parameter.name + ");" + end);
        case "formData":
            return new Handlebars.SafeString( start +
                "request.AddParameter(\"" + parameter.name + "\"," + parameter.name + ");" + end );
        default :
            return "UNDEFINED TYPE!!!";
    }


}