using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using uploadsample.Controllers;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;

namespace uploadsample.tests
{
    public class TestFileUpload
    {
        public TestFileUpload()
        {
            _context = new Mock<HttpContextBase>();
            _request = new Mock<HttpRequestBase>();
        }

        private Mock<HttpContextBase> _context;
        private Mock<HttpRequestBase> _request;
        private ViewPage fakeView = new ViewPage();


        [Fact]
        public void TestUploadStandardFile()
        {
            //var controller = new HomeController();

            //var actionResult = controller.Index();

            //Assert.NotNull(actionResult);
            //actionResult.ExecuteResult(context);

            //Assert.Empty(context.Controller.ViewData);
            
        }
    }
}
