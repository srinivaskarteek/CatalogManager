using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.IO.Compression;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FunctionAppcsw
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task Run([BlobTrigger("cswzipfileuploadblob/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, string name, TraceWriter log)
        {
            try
            {
                log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

                //Receives zip as stream | Package object as input from Azure Function
                //Check if the uploaded package in zip format
                if (name.EndsWith(".zip"))
                {
                    log.Info($"the uploaded file {name} is a zip file.");

                    //Extract ZIP and get package.json file
                    // Retrieve storage account from connection string.
                    CloudStorageAccount storageAccount =
                    CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=cswstorageacc;AccountKey=To+5UdyqS321tn75hn0IsJd279lBW0BvmXsGl+Tueo/jjzJtzGjjRTHB2yAK7YG41aiAkOZin15Nxd+QtH2BYQ==;EndpointSuffix=core.windows.net");

                    // Create the blob client.
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    // Retrieve reference to a zip file container.
                    CloudBlobContainer container = blobClient.GetContainerReference("cswzipfileuploadblob");

                    // Retrieve reference to the blob - zip file which we wanted to extract 
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(name);

                    //Retrieve reference to a container where you wanted to extract the zip file. 
                    var extractcontainer = blockBlob.ServiceClient.GetContainerReference("pending");


                    // Save blob(zip file) contents to a Memory Stream.
                    using (var zipBlobFileStream = new MemoryStream())
                    {


                        await blockBlob.DownloadToStreamAsync(zipBlobFileStream);

                        await zipBlobFileStream.FlushAsync();
                        zipBlobFileStream.Position = 0;


                        //use ZipArchive from System.IO.Compression to extract all the files from zip file
                        //Task.Delay(5000);
                        using (var zip = new ZipArchive(zipBlobFileStream))
                        {

                            //Each entry here represents an individual file or a folder
                            foreach (var entry in zip.Entries)
                            {

                                if (entry.Name.EndsWith("json"))
                                {
                                    var blob = extractcontainer.GetBlockBlobReference(name);
                                 //   if (entry.Name.Contains(name)
                                    {
                                        await blob.UploadFromStreamAsync(zipBlobFileStream);
                                    }
                                    //Package packageitems = JsonConvert.DeserializeObject<Package>(File.ReadAllText(entry.FullName));

                                    //////Package name in GUI must match with “name": "Package 1" attribute of JSON.
                                    //if (packageitems.FileName == entry.Name)
                                    //{
                                    //    //creating an empty file (blobkBlob) for the actual file with the same name of file
                                    //    var blob = extractcontainer.GetBlockBlobReference(entry.FullName);
                                    //    using (var stream = entry.Open())
                                    //    {

                                    //        //check for file or folder and update the above blob reference with actual content from stream
                                    //        if (entry.Length > 0)
                                    //            await blob.UploadFromStreamAsync(stream);
                                    //    }
                                    //}
                                }
                            }
                        }
                    }
                }
                else
                {
                    log.Info($"the uploaded file {name} is not a zip file.");
                }
            }
            catch (System.Exception ex)
            {
                log.Error(ex.Message);
                log.Info("from place catch block");
            }
        }
    }
}
