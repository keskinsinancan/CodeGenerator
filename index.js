const express = require("express");
const app = express();
const fs = require("fs");
const Handlebars = require("handlebars");
var request = require("request");
var test ="sinan can keskin";


function GetTypeFromRef(_ref) {
  if (_ref[0] === "#") {
    return _ref.slice(_ref.lastIndexOf("/") + 1);
  }
  return property.$ref;
}

function RegisterHelpers() {
  Handlebars.registerHelper("getType", function(property) {
    //Returns type of property
    if (property.type) {
      switch (property.type) {
        case "integer": //if type is integer
          switch (property.format) {
            case "int64":
              return "Int64";
              break;
            default:
              return "int";
          }
          break;
        case "number":
          return "float";
          break;

        case "boolean": //if type is boolean
          return "bool";
          break;

        case "string": //if type is string
          switch (property.format) {
            case "date-time":
              return "DateTime";
              break;
            default:
              return "string";
          }
          break;

        case "array": //if type is array
          if (property.items.type) {
            return property.items.type + "[]";
          } else if (property.items.$ref) {
            return GetTypeFromRef(property.items.$ref) + "[]";
          }
          return "Array";
          break;

        default:
          return property.type;
      }
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
  Handlebars.registerHelper("distinct", function(context,options) {
    let out = "";
    var data;
    if (options.data) {
        data = Handlebars.createFrame(options.data);
    }

    var result = [];
    var name = '';
    var change = Object.keys(context)[0].split("/")[1];
    for (var propertyName in context) {
      var temp = propertyName.split("/")[1];
      if (data) {
        data.group = name !== temp ;
        data.key = propertyName;
        data.changed = change !== temp;
      }
      result.push( options.fn(context[propertyName], {data: data}));
      name = temp;
      change = temp;
    }
    return result.join('');
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
