using System;
using System.Dynamic;
using System.Threading.Tasks;
using LiquidGenerator.Cli.Usecase;
using PowerArgs;

namespace LiquidGenerator.Cli
{
    [ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
    [ArgDescription("Apply a template to a bundle of data (e.g. json)")]
    public class Controller
    {
        [ArgActionMethod, ArgDescription("Apply Template"), ArgShortcut("a")]
        public async Task Apply(ApplyArgs args)
        {
            ExpandoObject data = new LoadJsonData(args.DataSourcePath).Execute();

            string content = args.TemplateEngine switch
            {                
                TemplateEngine.Razor => new RenderRazorTemplate(args.TemplatePath, data).Execute(),
                TemplateEngine.Liquid => new RenderLiquidTemplate(args.TemplatePath, data).Execute(),
                _ => throw new ArgumentException("Invalid template engine selected")
            };

            new SaveFile(args.OutputFilePath, content).Execute();
        }
    }
}