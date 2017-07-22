using NemSharp.Models;
using NemSharp.Request.Responses;
using NUnit.Framework;

namespace NemSharp.Tests
{
    [TestFixture]
    public class NISTest : TestBase
    {
        const string NIS_OK = "ok";
        const string NIS_STATUS = "status";

        [Test]
        public void TestHeartbeat()
        {
            NemRequestResult res = Client.NIS.HeartBeat();

            Assert.IsNotNull(res);
            Assert.IsNotNull(res.Message);
            Assert.IsNotNull(res.Code);
            Assert.IsNotNull(res.Type);

            StringAssert.Contains(res.Message, NIS_OK);
        }

        [Test]
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
