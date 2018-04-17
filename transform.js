const typeHelper = require("./typeNameHelper");
const paramHelper = require("./parameterHelper");

module.exports.transform = function(spec) {
  const model = {
    apis: transformPaths(spec.paths),
    apiVersion: spec.info.version,
    host: spec.host,
    basePath: spec.basePath,
    consumes: spec.consumes,
    models: transformDefinitions(spec.definitions),
    produces: spec.produces,
    resourcePath: "http://" + spec.host + spec.basePath,
    swaggerVersion: spec.swagger
  };
  return model;
};

const transformDefinitions = definitions => {
  var models = [];
  for (var propertyName in definitions) {
    var value = definitions[propertyName];
    models.push({
      name: propertyName,
      value: {
        id: propertyName,
        properties: transformProperties(value.properties, value.required)
      }
    });
  }
  return models;
};

const transformProperties = (properties, required) => {
  var collection = [];
  for (var propertyName in properties) {
    var value = properties[propertyName];
    var isArray = value.schema? value.schema.type==="array" : value.type === "array";
    //if (isArray) value = value.items;
    collection.push({
      dataType: {
        typeName: isArray? typeHelper.GetTypeName(value) + "[]" : typeHelper.GetTypeName(value),
        enums: value.enum,
        reference: value.schema ? value.schema.$ref : value.$ref,
        defaultValue: value.defaultValue,
        format: value.format,
        maximum: value.maximum,
        minimum: value.minimum,
        type: value.type,
        uniqueItems: true,
        isArray: isArray
      },
      description: null,
      name: propertyName,
      required: required ? required.indexOf(propertyName) >= 0 : false
    });
  }
  return collection;
};

const transformPaths = paths => {
  var apis = [];
  for (var propertyName in paths) {
    var value = paths[propertyName];
    var name = propertyName.split("/")[1];

    var found = apis.filter(item => item.name === name);
    if (found.length > 0) {
      found[0].operations = found[0].operations.concat(
        transformMethods(value, propertyName)
      );
    } else
      apis.push({
        name: name,
        operations: transformMethods(value, propertyName)
      });
  }
  return apis;
};

const transformMethods = (root, path) => {
  var operations = [];
  for (var propertyName in root) {
    var value = root[propertyName];
    operations.push({
      authorizations: {
        oauth2: ["", ""]
      },
      path: path,
      consumes: value.consumes,
      deprecated: value.deprecated,
      method: propertyName.toUpperCase(),
      name: value.operationId,
      parameters: transformParameters(value.parameters),
      produces: value.produces,
      responseMessages: transformResponseMessages(value.responses),
      summary: value.summary,
      parameterString: paramHelper.GetFunctionParameter(transformParameters(value.parameters)) 
    });
  }
  return operations;
};

const transformParameters = parameters => {
  var params = [];
  for (var propertyName in parameters) {
    var value = parameters[propertyName];
    var schema = value.schema;
    var isArray = schema? schema.type==="array" : value.type === "array";
    //var isArray = value.type === "array";
    //if (isArray) value = value.items;
    params.push({
      dataType: {
        typeName: isArray? typeHelper.GetTypeName(value) + "[]" : typeHelper.GetTypeName(value),
        enums: value.enum,
        reference: schema ? schema.$ref : value.$ref,
        defaultValue: value.default,
        format: value.format,
        maximum: value.maximum,
        minimum: value.minimum,
        type: schema ? schema.type : value.type,
        uniqueItems: true,
        isArray: isArray
      },
      allowMultiple: true,
      description: value.description,
      name: value.name,
      paramType: value.in,
      required: value.required
    });
  }
  return params;
};

const transformResponseMessages = responses => {
  var messages = [];
  for (var propertyName in responses) {
    var value = responses[propertyName];
    messages.push({
      code: propertyName,
      message: value.description,
      schema: value.schema
    });
  }
  return messages;
};
