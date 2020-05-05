using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DotLiquid;
using Fermin.Text.Json.Converters;

namespace LiquidGenerator.Core
{
    public class LiquidTemplateRenderer
    {
        public LiquidTemplateRenderer()
        {
            
        }

        public static Template LoadLiquidTemplate(string templatePath)
        {
            if (!File.Exists(templatePath))
            {
                throw new ArgumentException($"Template {templatePath} does not exist!");
            }

            string templateText = File.ReadAllText(templatePath);
            return Template.Parse(templateText);
        }

        public string Render(Template template, ExpandoObject content)
        {            
            return template.Render(Hash.FromDictionary(ConvertExpandoToDictionary(content)));
        }

        private Dictionary<string, object> ConvertExpandoToDictionary(ExpandoObject expandoObject)
        {
            return ((IDictionary<string, object>)expandoObject).ToDictionary(
                p => p.Key,
                p =>
                {
                    // if it's another IDict (might be a ExpandoObject or
                    //  could also be an actual Dict containing ExpandoObjects) just go through it recursively
                    if (p.Value is ExpandoObject innerExpando)
                    {
                        return ConvertExpandoToDictionary(innerExpando);
                    }

                    // if it's an IEnumerable, it might have ExpandoObjects inside, so check for that
                    if (p.Value is IEnumerable<object> list)
                    {
                        if (list.Any(o => o is ExpandoObject))
                        {
                            // if it does contain ExpandoObjects, take all of those and also go through them recursively
                            return list
                                .Where(o => o is ExpandoObject)
                                .Select(o => ConvertExpandoToDictionary((ExpandoObject)o));
                        }
                    }

                    // neither an IDict nor an IEnumerable -> it's probably fine to just return the value it has
                    return p.Value;
                } 
            );
        }
    }
}
