using Microsoft.VisualStudio.TestTools.UnitTesting;
using NemSharp.Request.Objects;

namespace NemSharp.Tests
{
    [TestClass]
    public class NISTest : TestBase
    {
        const string NIS_OK = "ok";
        const string NIS_STATUS = "status";

        [TestMethod]
        public void TestHeartbeat()
        {
            NemRequestResult res = Client.NIS.HeartBeat();

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Message);
            Assert.IsNotNull(res.Code);
            Assert.IsNotNull(res.Type);

            StringAssert.Contains(res.Message, NIS_OK);
        }

        [TestMethod]
        public void TestStatus()
        {
            NemRequestResult res = Client.NIS.Status();

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Message);
            Assert.IsNotNull(res.Code);
            Assert.IsNotNull(res.Type);

            StringAssert.Contains(res.Message, NIS_STATUS);
        }
    }
}
