using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using uploadsample.Controllers;

namespace uploadsample.tests.controllers
{
    public class TestHomeController
    {
        public TestHomeController() : base()
        {
            _controller = new HomeController();
        }

        private HomeController _controller;

        [Fact]
        public void Index_Shows_View_With_No_ViewData()
        {
            var result = _controller.Index();
            Assert.NotNull(result);
            Assert.Empty(_controller.ViewData);
        }
    }
}
