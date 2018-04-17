module.exports.GetFunctionParameter =  function(parameters) {
    var str = "";
    //{{this.dataType.typeName}} {{this.name}}
    for (var parameter in parameters){
        var param = parameters[parameter]; 
        str += param.dataType.typeName + " " + param.name + ", ";
    }
    if(str){
        return str.substring(0, str.length - 2);
    }else{
        return "";
    }
}