module.exports.GetTypeName = function (prop) {
    if (prop.type) {
        if (prop.type === "array") {
            // If type is array get type of items in array
            return this.GetTypeName(prop.items);
        } else {
            if (prop.format) {
                // If property has format return format equivalent
                return types[prop.format];
            } else {
                // If property has not format return type equivalent
                return types[prop.type];
            }
        }
    } else if (prop.schema) {
        if (prop.schema.type) {
            // If property has schema get type in schema
            return this.GetTypeName(prop.schema);
        } else if (prop.schema.$ref) {
            // If property has schema get type in schema reference
            return GetTypeFromRef(prop.schema.$ref);
        } else {
            return "** Empty Schema **";
        }
    } else if (prop.$ref) {
        // If property has referance then parse referance
        return GetTypeFromRef(prop.$ref);
    } else {
        return "** Empty type,schema,ref **";
    }
};

//String equivalent of data types
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

// Parse referance to get type
function GetTypeFromRef(_ref) {
    _ref = String(_ref);
    return _ref[0] === "#" ? _ref.slice(_ref.lastIndexOf("/") + 1) : _ref;
}
