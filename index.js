#!/usr/bin/env node

const program = require("commander");
const fs = require("fs");
const Handlebars = require("handlebars");
const transform = require("./transform");
const helper = require("./helper");
const request = require("request");

program
    .version("0.0.1")
    .option("-l, --list [list]", "list of customers in CSV file")
    .parse(process.argv);

request(
    {
        url: "http://petstore.swagger.io/v2/swagger.json",
        json: true
    },
    function (error, response, body) {
        if (!error && response.statusCode === 200) {
            fs.readFile("template.txt", "utf8", function (err, source) {
                helper.registerHelpers();
                var schema = transform.transform(body);
                //console.log(schema);
                var template = Handlebars.compile(source);
                var result = template(schema);
                fs.writeFileSync("created.cs", result);
            });
        }
    }
);
