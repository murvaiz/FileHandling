using FileHandling.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using System.Web.Http.Routing;

namespace FileHandling.Controllers.Tests
{
    [TestClass()]
    public class FileHandlingControllerTests
    {
        FileHandlingController _controller;

        [TestMethod()]
        [Description("check the files in test directory")]
        public async System.Threading.Tasks.Task GetDirectoryFilesTestAsync_Ok()
        {
            Mock<IFileConfig> mockConfig = new Mock<IFileConfig>();
            mockConfig.SetupGet(a => a.FilePath).Returns(@".\TargetData");
            mockConfig.SetupGet(a => a.FileNotFound).Returns("A kért file nem található!");

            _controller = new FileHandlingController(mockConfig.Object);

            var actionResult = await _controller.GetDirectoryFiles();
            var contentResult = actionResult as OkNegotiatedContentResult<List<string>>;
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(1, contentResult.Content.Count);
        }

        [TestMethod()]
        [Description("Check the case when the downloadable file is not in the folder")]
        public async System.Threading.Tasks.Task GetFileTestAsync_NotFound()
        {
            string notFound = "A kért file nem található!";
            Mock<IFileConfig> mockConfig = new Mock<IFileConfig>();
            mockConfig.SetupGet(a => a.FilePath).Returns(@".\TargetData");
            mockConfig.SetupGet(a => a.FileNotFound).Returns(notFound);
            var file = "Test.txt";

            _controller = new FileHandlingController(mockConfig.Object);

            var actionResult = await _controller.GetFile(file);
            var contentResult = actionResult as BadRequestErrorMessageResult; 
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(notFound, contentResult.Message);
        }

        [TestMethod()]
        [Description("check the case when the downloadable file is present")]
        public async System.Threading.Tasks.Task GetFileTestAsync_Ok()
        {
            string notFound = "A kért file nem található!";
            string expected = "teszt1 file";
            Mock<IFileConfig> mockConfig = new Mock<IFileConfig>();
            mockConfig.SetupGet(a => a.FilePath).Returns(@".\TargetData");
            mockConfig.SetupGet(a => a.FileNotFound).Returns(notFound);
            var file = "Test1.txt";

            _controller = new FileHandlingController(mockConfig.Object);

            var actionResult = await _controller.GetFile(file);
            var contentResult = actionResult as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);

            var base64EncodedBytes = System.Convert.FromBase64String(contentResult.Content);
            var result =  System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [Description("check the case when the file for upload could be not found")]
        public async System.Threading.Tasks.Task UploadTestAsync_NotOk()
        {
            string notFound = "A kért file nem található!";
            string expected = "Object reference not set to an instance of an object.";
            Mock<IFileConfig> mockConfig = new Mock<IFileConfig>();
            mockConfig.SetupGet(a => a.FilePath).Returns(@".\TargetData");
            mockConfig.SetupGet(a => a.FileNotFound).Returns(notFound);

            FileHandlingController fc = new FileHandlingController(mockConfig.Object);
            var actionResult = await fc.UploadFile();
            var contentResult = actionResult as BadRequestErrorMessageResult;
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(expected, contentResult.Message);
        }

        [TestMethod()]
        [Description("test the upload of a file")]
        public async System.Threading.Tasks.Task UploadTestAsync_Ok()
        {
            string notFound = "A kért file nem található!";
            string expected = "Object reference not set to an instance of an object.";
            string newFileName = "test.txt";
            string expectedText = "valami szoveg";
            Mock<IFileConfig> mockConfig = new Mock<IFileConfig>();
            mockConfig.SetupGet(a => a.FilePath).Returns(@".\TargetData");
            mockConfig.SetupGet(a => a.FileNotFound).Returns(notFound);

            var controllerContext = Create(newFileName, expectedText);
            FileHandlingController fc = new FileHandlingController(mockConfig.Object);
            fc.ControllerContext = controllerContext;
            var actionResult = await fc.UploadFile();
            var contentResult = actionResult as OkResult;
            Assert.IsNotNull(contentResult);

            var actionResultGet = await fc.GetFile(newFileName);
            var contentResultGet = actionResultGet as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(contentResult);

            var base64EncodedBytes = System.Convert.FromBase64String(contentResultGet.Content);
            var result = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            Assert.AreEqual(expectedText, result);

            //File.Delete(@".\TargetData\test.txt");
        }

        //fake the request content for the controller test
        private static HttpControllerContext Create(string fileName, string fileBody)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "");
            var content = new MultipartFormDataContent();
            const int lengthStream = 1900;
            var contentString = fileBody;
            var contentBytes = new ByteArrayContent(Encoding.ASCII.GetBytes(contentString));

            contentBytes.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };
            contentBytes.Headers.Add("Content-Type", "text/plain");
            contentBytes.Headers.Add("Content-Length", lengthStream.ToString());
            content.Add(contentBytes);
            request.Content = content;

            return new HttpControllerContext(new HttpConfiguration(), new HttpRouteData(new HttpRoute("")), request);
        }

        [TestCleanup()]
        [Description("reset the test environment, to be ready for the next test")]
        public void Cleanup_AfterEachTest()
        {
            if (File.Exists(@".\TargetData\test.txt"))
            {
                File.Delete(@".\TargetData\test.txt");
            }
        }
    }
}