using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.Json;
using RazorEngine;
using RazorEngine.Templating;

namespace LiquidGenerator.Core
{
    public class RazorTemplateRenderer
    {
        public RazorTemplateRenderer()
        {
        }

        public static LoadedTemplateSource LoadRazorTemplate(string templatePath)
        {
            if (!File.Exists(templatePath))
            {
                throw new ArgumentException($"Template {templatePath} does not exist!");
            }

            string templateText = File.ReadAllText(templatePath);
            return new LoadedTemplateSource(templateText);
        }

        public string Render(LoadedTemplateSource template, ExpandoObject content)
        {            
            return Engine.Razor.RunCompile(template, "razorTemplate", null, content);
        }
    }
}
