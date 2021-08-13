using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace DB.Core
{
    public class FileService
    {
        private MongoClient mongoClient = null;

        private IMongoDatabase mongoDatabase = null;

        public FileService(string connectionString)
        {
            mongoClient = new (connectionString);
            mongoDatabase = mongoClient.GetDatabase("fileServer");
        }

        public void UploadFile(string filePath, string fileName)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            UploadStream(fileStream, fileName);
        }

        public ObjectId UploadStream(Stream stream, string fileName)
        {
            GridFSBucket bucket = new GridFSBucket(mongoDatabase, new GridFSBucketOptions
            {
                BucketName = "files"
            });

            return bucket.UploadFromStream(fileName, stream);
        }

        public void DownloadFile(string filename, string outputFileName)
        {
            GridFSBucket bucket = new GridFSBucket(mongoDatabase, new GridFSBucketOptions
            {
                BucketName = "files"
            });

            using (Stream stream = bucket.OpenDownloadStreamByName(filename))
            {
                using (FileStream outputFileStream = new FileStream(outputFileName, FileMode.Create))
                {
                    stream.CopyTo(outputFileStream);
                }
            }
        }
    }
}
