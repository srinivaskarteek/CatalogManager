using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SE.Catalog.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;


namespace SE.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadblobController : ControllerBase
    {
        private string Cswconnectionstring { get; set; }
        public UploadblobController(IConfiguration config)
        {
            //get connection string from appsettings for the storage account
            string cswconnectionstring = config.GetConnectionString("cswstorageacc");
            Cswconnectionstring = cswconnectionstring;
        }

        // POST: api/Uploadblob
        /// <summary>
        /// While using postman,
        /// body -> form-data -> choose file to upload 
        /// headers should be empty
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadAzureblob()
        {
            try
            {
                CloudStorageAccount storageAccount = null;
                CloudBlobContainer cloudBlobContainer = null;

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                foreach (IFormFile myFile in Request.Form.Files)
                {
                    string myFileName = myFile.FileName;
                    byte[] myFileContent;

                    using (var memoryStream = new MemoryStream())
                    {
                        await myFile.CopyToAsync(memoryStream);
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        myFileContent = new byte[memoryStream.Length];
                    }


                    if (CloudStorageAccount.TryParse(Cswconnectionstring, out storageAccount))
                    {
                        try
                        {
                            // Create the CloudBlobClient that represents the Blob storage endpoint for the storage account.
                            CloudBlobClient cloudBlobClient = storageAccount.CreateCloudBlobClient();

                            cloudBlobContainer = cloudBlobClient.GetContainerReference("pending");

                            Stream fileStream = myFile.OpenReadStream();
                            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(myFileName);
                            await cloudBlockBlob.UploadFromByteArrayAsync(myFileContent, 0, myFileContent.Length);
                            fileStream.Dispose();
                        }
                        catch (StorageException ex)
                        {
                            Console.WriteLine("Error returned from the service: {0}", ex.Message);
                            return StatusCode(500);
                        }
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return StatusCode(500);
            }
        }
    }
}