using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using ctyun.oos.Common;


namespace MinIO_Test2.Ceph
{
    class AWS_connten_class
    {
        public AmazonS3Client Aws_connten()
        {
            string accessKey = "S7BQDCHX99G7H3YDX0EX";
            string secretKey = "w6rnLjMp529FRrtb3Ds6YE51sTjiwe6sALAdOYuS";

            AmazonS3Config config = new AmazonS3Config
            {
                //config.ServiceURL = "192.168.8.106";
                ServiceURL = "http://www.node1.com:7480"
            };
            AmazonS3Client ceph_Client = new AmazonS3Client(accessKey,secretKey,config);
            return ceph_Client;
        }
    }

    class Ceph_Bucket_class
    {
            
        public static void Show_All_Bucket()
        {
            try
            {
                AWS_connten_class ceph_connten = new AWS_connten_class();
                AmazonS3Client ceph_client = ceph_connten.Aws_connten();
                var getListBucketsTask2 = ceph_client.ListBucketsAsync();

                foreach (S3Bucket bucket in getListBucketsTask2.Result.Buckets)
                {
                    Console.WriteLine("BuckerName: {0}, Create Time: {1}", bucket.BucketName, bucket.CreationDate);
                }
            }
            catch (AmazonS3Exception Error)
            {
                Console.WriteLine("Error: {0}", Error.Message);
            }
        }
    }

    class Ceph_Upload
    {
        public void Upload_file()
        {
            try
            {
                AWS_connten_class ceph_connten = new AWS_connten_class();
                AmazonS3Client ceph_client = ceph_connten.Aws_connten();
                Run(ceph_client).Wait();
            }
            catch (Exception Error)
            {
                Console.WriteLine("Upload Error: {0}",Error.Message);
            }
        }
        private static async Task Run(AmazonS3Client ceph_client)
        {
            PutObjectRequest request = new PutObjectRequest { 
                BucketName = "test1",
                Key = "tmpWeb.config",
                ContentType = "application/text",
                FilePath = "D:\\tmpWeb.config"
            };

            try
            {

                await ceph_client.PutObjectAsync(request);
                Console.WriteLine("Successfully Upload: {0}", request.Key);
            }
            catch (AmazonS3Exception Ceph_Error)
            {
                Console.WriteLine("Ceph Upload Error: {0}",Ceph_Error.Message);
            }
        }
    }
}
