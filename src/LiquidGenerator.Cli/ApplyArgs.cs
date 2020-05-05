using PowerArgs;

namespace LiquidGenerator.Cli
{
    [TabCompletion]
    public class ApplyArgs
    {
        [ArgRequired, ArgDescription("Template Path"), ArgShortcut("t"), ArgExistingFile, ArgPosition(1)]
        public string TemplatePath { get; set; }

        [ArgRequired, ArgDescription("Datasource Path"), ArgShortcut("d"), ArgExistingFile, ArgPosition(2)]
        public string DataSourcePath { get; set; }

        [ArgDescription("Path to output file"), ArgShortcut("o"), ArgDefaultValue("output.html"), ArgPosition(3)]
        public string OutputFilePath { get; set; }

        [ArgDescription("Template Engine"), ArgShortcut("e"), ArgDefaultValue(TemplateEngine.Liquid), ArgPosition(4)]
        public TemplateEngine TemplateEngine { get; set; }
    }

    public enum TemplateEngine
    {
        Liquid = 0,
        Razor = 1
    }
}