using LiquidGenerator.Core;

namespace LiquidGenerator.Cli.Usecase
{
    public class GenerateLiquidFromJson : IUsecase<bool>
    {
        public GenerateLiquidFromJson(string templatePath, string jsonPath, string outputPath)
        {
            TemplatePath = templatePath;
            JsonPath = jsonPath;
            OutputPath = outputPath;
        }

        public string TemplatePath { get; }
        public string JsonPath { get; }
        public string OutputPath { get; }

        public bool Execute()
        {
            var generator = new Generator();
            generator.Save(TemplatePath, JsonPath, OutputPath);

            return true;
        }
    }
}