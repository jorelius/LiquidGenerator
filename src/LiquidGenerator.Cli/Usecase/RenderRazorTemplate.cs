using System.Dynamic;
using LiquidGenerator.Core;

namespace LiquidGenerator.Cli.Usecase
{
    public class RenderRazorTemplate : IUsecase<string>
    {
        public RenderRazorTemplate(string templatePath, ExpandoObject data)
        {
            TemplatePath = templatePath;
            Data = data;
        }

        public string TemplatePath { get; }
        public ExpandoObject Data { get; }

        public string Execute()
        {
            var template = RazorTemplateRenderer.LoadRazorTemplate(TemplatePath);

            var generator = new RazorTemplateRenderer();
            return generator.Render(template, Data); 
        }
    }
}