using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using MvcContrib.TestHelper;
using uploadsample.Controllers;
using Moq;

namespace uploadsample.tests.controllers
{
    public class TestFileController : IntegrationTest
    {
        public TestFileController(): base()
        {
            InitWithUploader();
        }
        private FileController _controller;
        private Mock<PictureUploads> _uploader;

        private void InitWithUploader()
        {
            _uploader = new Mock<PictureUploads>();
            _controller = new FileController(_uploader.Object);
        }

        [Fact]
        public void CleanUpUserContent_redirects_to_home(){
            var result = _controller.CleanUpUserContent();
            result.AssertHttpRedirect().ToUrl("/");
        }

        [Fact]
        public void CleanUpUserContent_Calls_Cleanout_On_Uploader()
        {
            _uploader.Setup(pu => pu.CleanOutContent()).Verifiable();
            InitWithUploader();

            var result = _controller.CleanUpUserContent();

            _uploader.VerifyAll();
        }

        [Fact]
        public void List_renders_list()
        {
            var result = _controller.List();
            result.AssertViewRendered().ForView(SameAsAction);
        }

        [Fact]
        public void List_calls_uploader_for_thumbnails()
        {
            _uploader.Setup<List<string>>(pu => pu.GetThumbnailPaths()).Verifiable();

            InitWithUploader();

            var result = _controller.List();

            _uploader.VerifyAll();
        }
    }
}
