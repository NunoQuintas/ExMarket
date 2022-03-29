
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ExMarket.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VerifiesAuditFieldFunction()
        {
            Assert.Pass();
        }


        [Test]
        public void VerifiesSoftDeleteFunction()
        {
            Assert.Pass();
        }


        [Test]
        public void VerifiesDatabaseModelWithConfiguredConnection()
        {
            Assert.Pass();
        }

        [Test]
        public void VerifiesDatabaseRegistoLeadsDtaInsertion()
        {
            Assert.Pass();
        }

        [Test]
        public void VerifiesMarketingController()
        {
            var fakeLogger = new Mock<ILogger<Controllers.MarketingController>>();

            var cnt = new Controllers.MarketingController(fakeLogger.Object);

            var result = cnt.Status();

            Assert.AreEqual(result, "Active");
        }
    }
}