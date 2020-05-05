using System;
using System.Dynamic;
using System.IO;
using System.Text.Json;
using Fermin.Text.Json.Converters;
using LiquidGenerator.Core;

namespace LiquidGenerator.Cli.Usecase
{
    public class LoadJsonData : IUsecase<ExpandoObject>
    {
        public LoadJsonData(string jsonPath)
        {
            JsonPath = jsonPath;
        }

        public string JsonPath { get; }

        public ExpandoObject Execute()
        {
            if (!File.Exists(JsonPath))
            {
                throw new ArgumentException($"Json file {JsonPath} does not exist!");
            }

            string json = File.ReadAllText(JsonPath);

            var options = new JsonSerializerOptions().AddDynamicConverter();
            return JsonSerializer.Deserialize<ExpandoObject>(json, options);
        }
    }
}