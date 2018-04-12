const express = require("express");
const app = express();
const fs = require("fs");
const Handlebars = require("handlebars");
var request = require("request");

function GetTypeFromRef(_ref) {
  _ref = String(_ref)
  if (_ref[0] === "#") {
    return _ref.slice(_ref.lastIndexOf("/") + 1);
  }
  return _ref;
}

function GetTypeFromType(property) {
  switch (property.type) {
    case "integer": //if type is integer
      switch (property.format) {
        case "int64":
          return "Int64";
        default:
          return "int";
      }

    case "number":
      return "float";

    case "boolean": //if type is boolean
      return "bool";

    case "string": //if type is string
      switch (property.format) {
        case "date-time":
          return "DateTime";
        default:
          return "string";
      }

    case "array": //if type is array
      if (property.items.type) {
        return property.items.type + "[]";
      } else if (property.items.$ref) {
        return GetTypeFromRef(property.items.$ref) + "[]";
      }
      return "Array";
    case "object":
      return "Object";
    case "file":
      return "File";
    default:
      return property.type;
  }
}

function RegisterHelpers() {
  Handlebars.registerHelper("getType", function(property) {
    //Returns type of property
    if (property.type) {
      return GetTypeFromType(property);
    } else if (property.$ref) {
      return GetTypeFromRef(property.$ref);
    }
  });
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

      if(!requestMethod.parameters[parameter].type){
        if(requestMethod.parameters[parameter].schema.$ref){
          let ref = requestMethod.parameters[parameter].schema.$ref;
          str += GetTypeFromRef(ref) + " " +
          GetTypeFromRef(ref).toLowerCase() + ", "; 
        }else if(requestMethod.parameters[parameter].schema.type){
          if(requestMethod.parameters[parameter].schema.type === "array"){
            str += GetTypeFromRef(requestMethod.parameters[parameter].schema.items.$ref) +"[] " +
            GetTypeFromRef(requestMethod.parameters[parameter].schema.items.$ref).toLowerCase() + ", ";
          }else{
            str += "!!!!UNKNOWN!!!!, "
          }
        }
        
      }else{
        str += 
        GetTypeFromType(requestMethod.parameters[parameter]);
        if(!requestMethod.parameters[parameter].required){
          str += "?";
        }
        str += " " + requestMethod.parameters[parameter].name + ", ";
      }
      
    }
    if(str != ""){
      return str.substring(0,str.length - 2);      
    }
    return "";
  });
  Handlebars.registerHelper("getBodyParameter", function(parameter){
    if(parameter.schema.type === "array"){
      return GetTypeFromRef(parameter.schema.items.$ref).toLowerCase();  
    }
    return GetTypeFromRef(parameter.schema.$ref).toLowerCase();
  });
  Handlebars.registerHelper("getRequestPathParameters",function(requestMethod,options){
    var data;
    result = []
    if (options.data) {
      data = Handlebars.createFrame(options.data);
    }
    for(var parameter in requestMethod.parameters){
      if(requestMethod.parameters[parameter].in === "path"){
        result.push(options.fn(requestMethod.parameters[parameter], { data: data }));
      }
    }
    return result.join("");
  });
  Handlebars.registerHelper("getRequestQueryParameters",function(requestMethod,options){
    var data;
    result = []
    if (options.data) {
      data = Handlebars.createFrame(options.data);
    }
    for(var parameter in requestMethod.parameters){
      if (data && requestMethod.parameters[parameter].type !== "array") {
        data.isArray = false;
      }else{
        data.isArray = true;
      }
      if(requestMethod.parameters[parameter].in === "query"){
        result.push(options.fn(requestMethod.parameters[parameter], { data: data }));
      }
    }
    return result.join("");
  });
  Handlebars.registerHelper("getRequestBodyParameters",function(requestMethod,options){
    var data;
    result = []
    if (options.data) {
      data = Handlebars.createFrame(options.data);
    }
    for(var parameter in requestMethod.parameters){
      if(requestMethod.parameters[parameter].in === "body"){
        result.push(options.fn(requestMethod.parameters[parameter], { data: data }));
      }
    }
    return result.join("");
  });
  Handlebars.registerHelper("getReturnType", function(requestMethod){
    let succesResponse = requestMethod.responses["200"];
    if(succesResponse){
      if(succesResponse.schema.type){
        if(succesResponse.schema.type === "array"){
          return new Handlebars.SafeString("List<" + 
          GetTypeFromRef(succesResponse.schema.items.$ref) + ">");
        }else{
          return GetTypeFromType(succesResponse.schema);
        }
        
      }else if(succesResponse.schema.$ref){
        return GetTypeFromRef(succesResponse.schema.$ref);
      }
        
    } 
  });
  Handlebars.registerHelper("getReturnTypeIfObject", function(requestMethod){
    let succesResponse = requestMethod.responses["200"];
    if(succesResponse){
      if(succesResponse.schema.type){
        if(succesResponse.schema.type === "array"){
          return new Handlebars.SafeString("List<" + 
          GetTypeFromRef(succesResponse.schema.items.$ref) + ">");
        }
      }else if(succesResponse.schema.$ref){
        return GetTypeFromRef(succesResponse.schema.$ref);
      }  
    } 
  });
  Handlebars.registerHelper("getReturnTypeIfSingle", function(requestMethod){
    let succesResponse = requestMethod.responses["200"];
    if(succesResponse){
      if(succesResponse.schema.type){
        if(succesResponse.schema.type !== "array"){
          return GetTypeFromType(succesResponse.schema);
        } 
      }
    } 
  });

}
var asd = "";
app.get("/", (req, res) => {
  request(
    {
      url: "http://petstore.swagger.io/v2/swagger.json",
      json: true
    },
    function(error, response, body) {
      if (!error && response.statusCode === 200) {
        fs.readFile("RestClientTemplate.txt", "utf8", function(err, source) {
          RegisterHelpers();
          var template = Handlebars.compile(source);
          var result = template(body);
          res.send(result);
          fs.writeFileSync("created.cs", result);
        });
      }
    }
  );
});

app.listen(3000, () => console.log("Example app listening on port 3000!"));
