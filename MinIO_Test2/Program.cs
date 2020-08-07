using System;
using MinIO_Test2.MinIO;
using MinIO_Test2.Ceph;
using Amazon;
using Amazon.S3;
using Minio.DataModel;
using System.IO;

namespace MinIO_Test2
{
    class Program
    {
        static void Main()
        {
            string bucketName= null;
            string objectName = null;
            
            //Minio_Bucket minio_bucket = new Minio_Bucket();
            //minio_bucket.Show_All_Bucket();

            Console.WriteLine("--------------------------------------------------------------");

            Minio_Upload minio_up = new Minio_Upload();
            bucketName = "test1";
            objectName = "一份脱敏记录.xml";
            string xmlPath1 = "D:\\一份脱敏记录.xml";
            minio_up.Upload_File(bucketName, objectName, xmlPath1);

            bucketName = "test1";
            objectName = "最大入院记录.xml";
            string xmlPath2 = "D:\\最大入院记录.xml";
            minio_up.Upload_File(bucketName, objectName, xmlPath2);

            bucketName = "test1";
            objectName = "88.9MB.zip";
            string zipPath3 = "d:\\88.9MB.zip";
            minio_up.Upload_File(bucketName, objectName, zipPath3);


            Console.WriteLine("--------------------------------------------------------------");

            Minio_Download minio_down = new Minio_Download();
            bucketName = "test1";
            objectName = "一份脱敏记录.xml";
            string xmlPath4 = "D:\\tmp\\一份脱敏记录.xml";
            minio_down.Download_File(bucketName, objectName, xmlPath4);

            bucketName = "test1";
            objectName = "最大入院记录.xml";
            string xmlPath5 = "D:\\tmp\\最大入院记录.xml";
            minio_down.Download_File(bucketName, objectName, xmlPath5);

            bucketName = "test1";
            objectName = "88.9MB.zip";
            string zipPath6 = "D:\\tmp\\88.9MB.zip";
            minio_down.Download_File(bucketName, objectName, zipPath6);


            File.Delete("D:\\tmp\\一份脱敏记录.xml");
            File.Delete("D:\\tmp\\最大入院记录.xml");
            File.Delete("D:\\tmp\\88.9MB.zip");


            Minio_Delete_class minio_delete = new Minio_Delete_class();
        }
    }
}