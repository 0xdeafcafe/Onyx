using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Onyx.Cartographer.Server;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace Onyx.Cartographer.Server
{
	/// <summary>
	/// The base class for server commands.
	/// </summary>
	public class ServerRequest
	{
		public ServerRequest(string action)
		{
			Action = action;
		}

		/// <summary>
		/// The action string to send to the server.
		/// </summary>
		public string Action { get; set; }
	}

	/// <summary>
	/// The base class for server responses.
	/// </summary>
	public class ServerResponse
	{
		/// <summary>
		/// The time that the server sent the response.
		/// </summary>
		public long Timestamp { get; set; }

		/// <summary>
		/// The resulting error code, or -1 if the request was successful.
		/// </summary>
		public int ErrorCode { get; set; }

		/// <summary>
		/// The message associated with the error code.
		/// </summary>
		public string ErrorMessage { get; set; }

		/// <summary>
		/// True if the server request was successful.
		/// </summary>
		public bool Successful
		{
			get { return ErrorCode == -1; }
		}
	}

	public static class DomainConnector
	{
		/// <summary>
		/// Sends a request object to the server and retrieves the response.
		/// </summary>
		/// <typeparam name="TRequestType">The type of the request object that should be sent. This must inherit from ServerRequest.</typeparam>
		/// <typeparam name="TResultType">The type of the result object that should be returned. This must inherit from ServerResponse.</typeparam>
		/// <param name="commandObj">The command object of type CommandType to send.</param>
		/// <param name="path">The path after /api/ to call on the remote server.</param>
		/// <returns>The server's response, or null if the request failed.</returns>
		public static TResultType SendRequest<TRequestType, TResultType>(TRequestType commandObj, string path)
			where TRequestType : ServerRequest
			where TResultType : ServerResponse
		{
			// Serialize the request object to a MemoryStream
			var jsonSerializer = new JsonSerializer();
			var ms = new MemoryStream();
			var bson = new BsonWriter(ms);
			jsonSerializer.Serialize(bson, commandObj);

			// POST it to the server
			var request = (HttpWebRequest)WebRequest.Create(DomainEndpoint + path);
			request.Method = "POST";
			request.ContentType = "application/octet-stream";
			request.ContentLength = ms.Length;
			Stream dataStream = null;
			try
			{
				dataStream = request.GetRequestStream();
				dataStream.Write(ms.GetBuffer(), 0, (int)ms.Length);
			}
			catch (WebException)
			{
				return null;
			}
			finally
			{
				if (dataStream != null)
					dataStream.Close();
				ms.Close();
			}

			// Retrieve the response and open a stream to it
			WebResponse response = null;
			try
			{
				response = request.GetResponse();
				dataStream = response.GetResponseStream();
			}
			catch (WebException)
			{
				if (response != null)
					response.Close();
				return null;
			}
			if (dataStream == null)
				return null;

			// Deserialize the response
			var resultSerializer = new JsonSerializer();
			var bsonReader = new BsonReader(dataStream);
			var result = resultSerializer.Deserialize(bsonReader, typeof(TResultType)) as TResultType;
			dataStream.Close();
			response.Close();
			return result;
		}

#if DEBUG
		private const string DomainEndpoint = "http://localhost:1337/api/";
#else
		private const string DomainEndpoint = "http:/domain.onyx.sx/api/";
#endif
	}
}