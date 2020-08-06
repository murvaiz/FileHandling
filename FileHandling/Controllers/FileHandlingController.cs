using FileHandling.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FileHandling.Controllers
{
    public class FileHandlingController : ApiController
    {
        private readonly IFileConfig _fileConfig;

        public FileHandlingController(IFileConfig fileConfig)
        {
            _fileConfig = fileConfig;
        }

        [HttpPost]
        [Route("api/dokumentumok")]
        public async Task<IHttpActionResult> UploadFile()
        {
            var root = _fileConfig.FilePath;
            DirectoryCheck(root);

            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var name = file.Headers.ContentDisposition.FileName;
                    name = name.Trim('"');

                    var localFileName = file.LocalFileName;
                    var filePath = Path.Combine(root, name);

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    File.Move(localFileName, filePath);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/dokumentumok")]
        public async Task<IHttpActionResult> GetDirectoryFiles() 
        {
            var root = _fileConfig.FilePath;
            DirectoryCheck(root);

            List<string> files = new List<string>();

            DirectoryInfo directoryInfo = new DirectoryInfo(root);
            FileInfo[] fileInfo = directoryInfo.GetFiles();

            foreach (FileInfo file in fileInfo)
            {
                files.Add(file.Name);
            }

            return Ok(files); 
        }

        [HttpGet]
        [Route("api/dokumentumok/{fileName}")]
        public async Task<IHttpActionResult> GetFile(string fileName)
        {
            var root = _fileConfig.FilePath;
            DirectoryCheck(root);

            var filePath = Path.Combine(root, fileName);

            if (!File.Exists(filePath))
            {
                return BadRequest(_fileConfig.FileNotFound);
            }

            byte[] byteFile = System.IO.File.ReadAllBytes(filePath);
            return Ok<string>(Convert.ToBase64String(byteFile));
        }

        private void DirectoryCheck(String root)
        {
            bool exists = System.IO.Directory.Exists(root);

            if (!exists)
            {
                System.IO.Directory.CreateDirectory(root);
            }
        }
    }
}
