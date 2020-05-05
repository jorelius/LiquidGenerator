using System.Threading.Tasks;
using LiquidGenerator.Cli.Usecase;
using PowerArgs;

namespace LiquidGenerator.Cli
{
    [ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
    [ArgDescription("Apply a Liquid template to a bundle of data (e.g. json)")]
    public class Controller
    {
        [ArgActionMethod, ArgDescription("Apply Liquid Template"), ArgShortcut("a")]
        public async Task Apply(ApplyArgs args)
        {
            IUsecase<bool> usecase = new GenerateLiquidFromJson(args.TemplatePath, args.DataSourcePath, args.OutputFilePath);
            usecase.Execute();
        }
        
    }
}