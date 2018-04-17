const Handlebars = require("handlebars");

module.exports.registerHelpers = function RegisterHelpers() {

  Handlebars.registerHelper("toLowerCase", function(str) {
    return String(str).toLowerCase();
  });

  Handlebars.registerHelper("toUpperCase", function(str) {
    return String(str).toUpperCase();
  });


  

  /*
  Handlebars.registerHelper("getBaseUrl", function(property) {
    //Returns the base url of json
    if (property.schemes[0] === "http") {
      let baseUrl = "http://" + property.host + property.basePath;
      return baseUrl;
    }
  });
  Handlebars.registerHelper("getTitle", function(property) {
    //Returns title from info of json
    let title = property.info.title;
    title = title.replace(" ", "");
    return title;
  });
  Handlebars.registerHelper("toLowerCase", function(str) {
    return str.toLowerCase();
  });
  Handlebars.registerHelper("toUpperCase", function(str) {
    return str.toUpperCase();
  });
  Handlebars.registerHelper("getRoot", function(path) {
    return path.split("/")[1];
  });
  Handlebars.registerHelper("distinct", function(context, options) {
    var data;
    if (options.data) {
      data = Handlebars.createFrame(options.data);
    }

    var result = [];
    var name = "";
    var change = Object.keys(context)[0].split("/")[1];
    for (var propertyName in context) {
      var temp = propertyName.split("/")[1];
      if (data) {
        data.group = name !== temp;
        data.key = propertyName;
        data.changed = change !== temp;
      }
      result.push(options.fn(context[propertyName], { data: data }));
      name = temp;
      change = temp;
    }
    return result.join("");
  });
  Handlebars.registerHelper("getFunctionParameters", function(requestMethod) {
    let str = "";
    for (var parameter in requestMethod.parameters) {
      if (!requestMethod.parameters[parameter].type) {
        if (requestMethod.parameters[parameter].schema.$ref) {
          let ref = requestMethod.parameters[parameter].schema.$ref;
          str +=
            GetTypeFromRef(ref) +
            " " +
            GetTypeFromRef(ref).toLowerCase() +
            ", ";
        } else if (requestMethod.parameters[parameter].schema.type) {
          if (requestMethod.parameters[parameter].schema.type === "array") {
            str +=
              GetTypeFromRef(
                requestMethod.parameters[parameter].schema.items.$ref
              ) +
              "[] " +
              GetTypeFromRef(
                requestMethod.parameters[parameter].schema.items.$ref
              ).toLowerCase() +
              ", ";
          } else {
            str += "!!!!UNKNOWN!!!!, ";
          }
        }
      } else {
        str += GetTypeFromType(requestMethod.parameters[parameter]);
        if (!requestMethod.parameters[parameter].required) {
          str += "?";
        }
        str += " " + requestMethod.parameters[parameter].name + ", ";
      }
    }
    if (str != "") {
      return str.substring(0, str.length - 2);
    }
    return "";
  });
  Handlebars.registerHelper("getBodyParameter", function(parameter) {
    if (parameter.schema.type === "array") {
      return GetTypeFromRef(parameter.schema.items.$ref).toLowerCase();
    }
    return GetTypeFromRef(parameter.schema.$ref).toLowerCase();
  });
  Handlebars.registerHelper("getRequestPathParameters", function(
    requestMethod,
    options
  ) {
    var data;
    result = [];
    if (options.data) {
      data = Handlebars.createFrame(options.data);
    }
    for (var parameter in requestMethod.parameters) {
      if (requestMethod.parameters[parameter].in === "path") {
        result.push(
          options.fn(requestMethod.parameters[parameter], { data: data })
        );
      }
    }
    return result.join("");
  });
  Handlebars.registerHelper("getRequestQueryParameters", function(
    requestMethod,
    options
  ) {
    var data;
    result = [];
    if (options.data) {
      data = Handlebars.createFrame(options.data);
    }
    for (var parameter in requestMethod.parameters) {
      if (data && requestMethod.parameters[parameter].type !== "array") {
        data.isArray = false;
      } else {
        data.isArray = true;
      }
      if (requestMethod.parameters[parameter].in === "query") {
        result.push(
          options.fn(requestMethod.parameters[parameter], { data: data })
        );
      }
    }
    return result.join("");
  });
  Handlebars.registerHelper("getRequestBodyParameters", function(
    requestMethod,
    options
  ) {
    var data;
    result = [];
    if (options.data) {
      data = Handlebars.createFrame(options.data);
    }
    for (var parameter in requestMethod.parameters) {
      if (requestMethod.parameters[parameter].in === "body") {
        result.push(
          options.fn(requestMethod.parameters[parameter], { data: data })
        );
      }
    }
    return result.join("");
  });
  Handlebars.registerHelper("getReturnType", function(requestMethod) {
    let succesResponse = requestMethod.responses["200"];
    if (succesResponse) {
      if (succesResponse.schema.type) {
        if (succesResponse.schema.type === "array") {
          return new Handlebars.SafeString(
            "List<" + GetTypeFromRef(succesResponse.schema.items.$ref) + ">"
          );
        } else {
          return GetTypeFromType(succesResponse.schema);
        }
      } else if (succesResponse.schema.$ref) {
        return GetTypeFromRef(succesResponse.schema.$ref);
      }
    }
  });
  Handlebars.registerHelper("getReturnTypeIfObject", function(requestMethod) {
    let succesResponse = requestMethod.responses["200"];
    if (succesResponse) {
      if (succesResponse.schema.type) {
        if (succesResponse.schema.type === "array") {
          return new Handlebars.SafeString(
            "List<" + GetTypeFromRef(succesResponse.schema.items.$ref) + ">"
          );
        }
      } else if (succesResponse.schema.$ref) {
        return GetTypeFromRef(succesResponse.schema.$ref);
      }
    }
  });
  Handlebars.registerHelper("getReturnTypeIfSingle", function(requestMethod) {
    let succesResponse = requestMethod.responses["200"];
    if (succesResponse) {
      if (succesResponse.schema.type) {
        if (succesResponse.schema.type !== "array") {
          return GetTypeFromType(succesResponse.schema);
        }
      }
    }
  });*/
};
