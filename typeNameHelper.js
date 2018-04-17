module.exports.GetTypeName = function (prop) {
    if (prop.type) {
        if (prop.type === "array") {
            return this.GetTypeName(prop.items);
        } else {
            if (prop.format) {
                return types[prop.format];
            } else {
                return types[prop.type];
            }
        }
    } else if (prop.schema) {
        if (prop.schema.type) {
            return this.GetTypeName(prop.schema);
        } else if (prop.schema.$ref) {
            return GetTypeFromRef(prop.schema.$ref);
        } else {
            return "** Empty Schema **";
        }
    } else if (prop.$ref) {
        return GetTypeFromRef(prop.$ref);
    } else {
        return "** Empty type,schema,ref **";
    }
};

const types = {
    int16: "short",
    int32: "int",
    int64: "long",
    float: "float",
    double: "double",
    number: "Decimal",
    string: "string",
    byte: "byte",
    boolean: "bool",
    date: "DateTime",
    file: "File",
    object: "Object",
    "date-time": "DateTime"
};

function GetTypeFromRef(_ref) {
    _ref = String(_ref);
    return _ref[0] === "#" ? _ref.slice(_ref.lastIndexOf("/") + 1) : _ref;
}

// Unused function
/*
function GetTypeFromType(property) {
  switch (property.type) {
    case "integer": //if type is integer
      switch (property.format) {
        case "int64":
          return "long";
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
*/
