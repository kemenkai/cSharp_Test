using System;
using Minio;
using System.IO;
using Minio.DataModel;
using Minio.Exceptions;
using System.Xml.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace MinIO_Test2.MinIO
{
    class Minio_connten_class
    {
        public MinioClient Minio_connten()
        {
            var endpoint = "192.168.8.106:9000";
            var accessKey = "AKIAIOSFODNN7EXAMPLE";
            var secretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";

            MinioClient minio_client = new MinioClient(endpoint, accessKey, secretKey);
            return minio_client;
        }
    }

    class Minio_Bucket
    {
        public void Show_All_Bucket()
        {
            try
            {
                Minio_connten_class minio_connten = new Minio_connten_class();
                MinioClient minio_client = minio_connten.Minio_connten();

                var getListBucketsTask = minio_client.ListBucketsAsync();

                foreach (Bucket bucket in getListBucketsTask.Result.Buckets)
                {
                    Console.WriteLine("BuckerName: {0}, Create Time: {1} \r\n", bucket.Name, bucket.CreationDateDateTime);
                }
            }
            catch (Exception Error)
            {
                Console.WriteLine(Error.Message);
            }
        }
    }



    class Minio_Download
    {
        public void Download_File(string bucketName, string objectName, string filePath)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                Minio_connten_class minio_connten = new Minio_connten_class();
                MinioClient minio_client = minio_connten.Minio_connten();
                Run(minio_client, bucketName, objectName, filePath).Wait();
                watch.Stop();
                long Time_ConSuming = watch.ElapsedMilliseconds;
                Console.WriteLine("文件包： {0}, 耗时: {1} ms \r\n", filePath, Time_ConSuming);
            }
            catch (Exception Error)
            {
                Console.WriteLine("Download Error: {0}", Error.Message);
            }
        }

        private static async Task Run(MinioClient minio_client, string bucketName, string objectName, string filePath)
        {
            string self_bucketName = bucketName;
            string self_objectName = objectName;
            string self_filePath = filePath;

            try
            {
                await minio_client.StatObjectAsync(self_bucketName, self_objectName);
                await minio_client.GetObjectAsync(self_bucketName, self_objectName, self_filePath);
            }
            catch (MinioException Minio_Error)
            {
                Console.WriteLine("MinIO Download Error: {0}", Minio_Error.Message);
            }
        }

    }
    class Minio_Delete_class
    { 
        public async Task Delete_File(string bucketName, string objectName)
        {
            try
            {
                Minio_connten_class minio_connten = new Minio_connten_class();
                MinioClient minio_client = minio_connten.Minio_connten();
                await minio_client.RemoveObjectAsync(bucketName, objectName);
            }
            catch (Exception Delete_Erroe)
            {
                Console.WriteLine("Delete Erroe: {0}", Delete_Erroe.Message);
            }
        }
    }
    class Minio_Upload
    {
        public void Upload_File(string bucketName, string objectName, string filePath)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                Minio_connten_class minio_connten = new Minio_connten_class();
                MinioClient minio_client = minio_connten.Minio_connten();
                Run(minio_client, bucketName, objectName, filePath).Wait();
                watch.Stop();
                var Time_ConSuming = watch.ElapsedMilliseconds;
                Console.WriteLine("文件包： {0}, 耗时: {1} ms \r\n", filePath, Time_ConSuming);

            }
            catch (Exception Error)
            {
                Console.WriteLine("Upload Error: {0}", Error);
            }
        }

        private static async Task Run(MinioClient minio_client, string bucketName, string objectName, string filePath)
        {
            string self_bucketName = bucketName;
            string location = "us-east-1";
            string self_objectName = objectName;
            string contentType = "application/text";
            string self_filePath = filePath;

            try
            {
                bool found = await minio_client.BucketExistsAsync(bucketName);
                if (!found)
                {
                    await minio_client.MakeBucketAsync(bucketName, location);
                }

                await minio_client.PutObjectAsync(self_bucketName, self_objectName, self_filePath, contentType);
                Console.WriteLine("Successfully Upload: {0}", objectName);
            }
            catch (MinioException Minio_Error)

            {
                Console.WriteLine("Upload Error: {0}", Minio_Error.Message);
            }

        }
    }
}
