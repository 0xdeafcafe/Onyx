using Nitrogen.Content.UserGenerated.Halo4;
using Nitrogen.Scripting.WumboScript.Decompiler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Onyx.Cartographer.Controllers
{
    public class VariantController : ApiController
    {
        // POST api/variant
        public string Post()
        {
            if (!(Request.Content is System.Net.Http.StreamContent))
                throw new InvalidOperationException();

            var data = Request.Content as System.Net.Http.StreamContent;

            var variant = Request.Content;
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
    }
}