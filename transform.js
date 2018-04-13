
module.exports. transform  = function(spec) {
  const model = {
    apis: transformPaths(spec.paths),
    apiVersion: spec.info.version,
    basePath: spec.basePath,
    consumes: spec.consumes,
    models: transformDefinitions(spec.definitions),
    produces: spec.produces,
    resourcePath: "",
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
        properties: transformProperties(value.properties,value.required)
      }
    });
  }
  return models;
};

const transformProperties = (properties,required) => {
    var properties = [];
    for (var propertyName in properties) {
        var value = properties[propertyName];
        var isArray = value.type === "array";
        if(isArray)
            value = value.items
        properties.push({
            dataType: {
              enums: value.enum,
              reference: value.schema.$ref,
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
            required: required.indexOf(propertyName) >= 0
          });
    }
    return properties;
};

const transformPaths = (paths) => {
    var apis = [];
    for (var propertyName in paths) {
        var value = paths[propertyName];
        var root = propertyName.split('/')[1];

        var found = apis.filter(item => item.path === root);
        if(found.length > 0)
        {
            found[0].operations.concat(transformMethods(value, propertyName));
        }
        else
            apis.push({
                path: root,
                operations: transformMethods(value,propertyName)
            });
    }
    return apis;
}

const transformMethods = (root,path) => {
    var operations = [];
    for (var propertyName in root) {
        var value = root[propertyName];
        operations.push({
            authorizations: {
              oauth2: ["", ""]
            },
            path : path,
            consumes: value.consumes,
            deprecated:value.deprecated,
            method: propertyName,
            name : value.operationId,
            parameters: transformParameters(value.parameters),
            produces:value.produces,
            responseMessages: transformResponseMessages(value.responseMessages),
            summary: value.summary
          });
    }
    return operations;
}

const transformParameters = (parameters) => {
    var params = [];
    for (var propertyName in parameters) {
        var value = parameters[propertyName];
        var schema = value.schema;
        params.push(
              {
                dataType: {
                  enums: value.enum,
                  reference: schema ? schema.$ref : "",
                  defaultValue: value.default,
                  format: value.format,
                  maximum: value.maximum,
                  minimum: value.minimum,
                  type: schema ? schema.type : value.type,
                  uniqueItems: true,
                  isArray: true
                },
                allowMultiple: true,
                description: value.description,
                name: propertyName,
                paramType: value.in,
                required: value.required
              }
            );
    }
    return params;
}

const transformResponseMessages = (responses) => {
    var messages = [];
    for (var propertyName in responses) {
        var value = responses[propertyName];
        messages.push({
            code: propertyName,
            message : value.description
        });
    }
    return messages;
}