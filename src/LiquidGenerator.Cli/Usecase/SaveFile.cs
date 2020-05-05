using System.IO;

namespace LiquidGenerator.Cli.Usecase
{
    public class SaveFile : IUsecase<bool>
    {
        public SaveFile(string outputPath, string content)
        {
            OutputPath = outputPath;
            Content = content;
        }

        public string OutputPath { get; }
        public string Content { get; }

        public bool Execute()
        {
            File.WriteAllText(OutputPath, Content);

            return true;
        }
    }
}