using System;
using System.IO;
using System.Linq;
using System.Text;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Onyx.Cartographer.Models;

namespace Onyx.Cartographer.Extensions.Wrappers
{
    public class S3Storage
    {
        private const string Bucket = "onyxapp_storage";
        private readonly AmazonS3 _client;
        private readonly DatabaseContext _dbContext = new DatabaseContext();

        /// <summary>
        /// A Wrapper for the AWS.net SDK
        /// </summary>
        public S3Storage()
        {
            var accessKeyId = _dbContext.Key.SingleOrDefault(k => k.Name == "AccessKeyId").Data;
            var secretAccessKey = _dbContext.Key.SingleOrDefault(k => k.Name == "SecretAccessKey").Data;

            _client = AWSClientFactory.CreateAmazonS3Client(accessKeyId, secretAccessKey, RegionEndpoint.USEast1);
        }

        /// <summary>
        /// Enums for the type of storage Onyx has
        /// </summary>
        public enum StorageLocations
        {
            Stfs,
            Solution
        }

        /// <summary>
        /// Turns a StorageLocations enum into a key path
        /// </summary>
        /// <param name="location">The storage location enum</param>
        /// <returns>Corresponding key path</returns>
        private static string StorageLocationToString(StorageLocations location)
        {
            switch (location)
            {
                case StorageLocations.Solution:
                    return "solutions";
                case StorageLocations.Stfs:
                    return "stfs";

                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Reads a string from an S3 bucket
        /// </summary>
        /// <param name="location">The location of the data you want to read</param>
        /// <param name="guid">The guid of the content you're reading</param>
        /// <returns>A string interpretation of the data</returns>
        public string ReadString(StorageLocations location, string guid)
        {
            var keyName = string.Format("{0}/{1}.onx", StorageLocationToString(location), guid);
            var request = new GetObjectRequest().WithBucketName(Bucket).WithKey(keyName);


            return new StreamReader(_client.GetObject(request).ResponseStream, Encoding.ASCII).ReadToEnd();
        }

        /// <summary>
        /// Reads a byte array from an S3 bucket
        /// </summary>
        /// <param name="location">The location of the data you want to read</param>
        /// <param name="guid">The guid of the content you're reading</param>
        /// <returns>A byte array interpretation of the data</returns>
        public byte[] ReadByteArray(StorageLocations location, string guid)
        {
            var keyName = string.Format("{0}/{1}.onx", StorageLocationToString(location), guid);
            var request = new GetObjectRequest().WithBucketName(Bucket).WithKey(keyName);

            return VariousFunctions.StreamToByteArray(_client.GetObject(request).ResponseStream);
        }

        /// <summary>
        /// Writes byte array data into an S3 Bucket
        /// </summary>
        /// <param name="data">The byte array data to write to the bucket.</param>
        /// <param name="location">The location as to where you want to save the data</param>
        /// <param name="guid">The guid of the content you're uploading</param>
        public void WriteObject(byte[] data, StorageLocations location, string guid)
        {
            // Do upload
            var stream = new MemoryStream(data);
            var keyName = string.Format("{0}/{1}.onx", StorageLocationToString(location), guid);
            var request = new PutObjectRequest();
            request.WithBucketName(Bucket).WithKey(keyName).WithInputStream(stream);

            // Response
            S3Response response = _client.PutObject(request);
            response.Dispose();
            stream.Dispose();
        }

        /// <summary>
        /// Writes byte array data into an S3 Bucket
        /// </summary>
        /// <param name="data">The byte array data to write to the bucket.</param>
        /// <param name="location">The location as to where you want to save the data</param>
        /// <param name="guid">The guid of the content you're uploading</param>
        public void WriteObject(string data, StorageLocations location, string guid)
        {
            var keyName = string.Format("{0}/{1}.onx", StorageLocationToString(location), guid);

            var request = new PutObjectRequest();
            request.WithContentBody(data)
                .WithBucketName(Bucket)
                .WithKey(keyName);

            S3Response response = _client.PutObject(request);
            response.Dispose();
        }
    }
}
