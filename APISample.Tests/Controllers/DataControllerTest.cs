using APISample;
using APISample.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace APISample.Tests.Controllers
{
    [TestClass]
    public class DataControllerTest
    {
        [TestMethod]
        public void Get()
        {
            var controller = new DataController();
            var result = controller.Get() as OkNegotiatedContentResult<User[]>;

            Assert.IsNotNull(result);
           
            Assert.IsNotNull(result.Content);
        }
        [TestMethod]
        public void GetForAuthenticate()
        {
            var controller = new DataController();
            var result = controller.GetForAuthenticate() as OkNegotiatedContentResult<string>;

            Assert.IsNotNull(result);
        }
    }
}
