using System;
using System.IO;
using System.Net.Http;
using System.Web.Http;
using Nitrogen.Content.UserGenerated.Halo4;
using Nitrogen.Scripting.WumboScript.Decompiler;

namespace Onyx.Cartographer.Areas.Api.Controllers
{
    public class VariantController : ApiController
    {
        // POST api/variant
        public string Post()
        {
            if (!(Request.Content is StreamContent))
                throw new InvalidOperationException();

            try
            {
                var data = Request.Content as StreamContent;

                var newData = data.ReadAsByteArrayAsync().Result;
                var gt = GameType.Load(newData);
                var decompiler = new WumboScriptDecompiler();
                decompiler.AddScript(gt.Script);

                var outputPath = Path.GetTempFileName();
                using (var output = new StreamWriter(outputPath))
                {
                    output.WriteLine("-- Decompiled with Onyx");
                    output.WriteLine("-- Variant name: " + gt.ContentName);
                    output.WriteLine("-- Base variant: " + gt.MegaloStrings[gt.BaseNameStringIndex].English);
                    output.WriteLine();
                    decompiler.Finish(output);
                }

                return File.ReadAllText(outputPath);
            }
            catch
            {
                throw new InvalidOperationException();
            }
        }
    }
}
