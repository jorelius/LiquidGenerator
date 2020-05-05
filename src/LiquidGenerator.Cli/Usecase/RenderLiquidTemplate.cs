using System.Dynamic;
using LiquidGenerator.Core;

namespace LiquidGenerator.Cli.Usecase
{
    public class RenderLiquidTemplate : IUsecase<string>
    {
        public RenderLiquidTemplate(string templatePath, ExpandoObject data)
        {
            TemplatePath = templatePath;
            Data = data;
        }

        public string TemplatePath { get; }
        public ExpandoObject Data { get; }

        public string Execute()
        {
            var template = LiquidTemplateRenderer.LoadLiquidTemplate(TemplatePath);

            var generator = new LiquidTemplateRenderer();
            return generator.Render(template, Data); 
        }
    }
}