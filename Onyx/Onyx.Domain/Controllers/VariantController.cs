using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Nitrogen;
using Nitrogen.Content.UserGenerated.Halo4;
using Nitrogen.Scripting.WumboScript.Decompiler;
using System.IO;

namespace Onyx.Domain.Controllers
{
	public class VariantController : ApiController
	{
		// GET api/variant
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/variant/5
		public string Get(int id)
		{
			return "value";
		}

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

			var outputPath = System.IO.Path.GetTempFileName();
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

		// PUT api/variant/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/variant/5
		public void Delete(int id)
		{
		}
	}
}