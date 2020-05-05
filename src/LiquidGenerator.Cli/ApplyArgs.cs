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

        [ArgDescription("path to output file"), ArgShortcut("o"), ArgDefaultValue("output.html"), ArgPosition(3)]
        public string OutputFilePath { get; set; }
    }
}