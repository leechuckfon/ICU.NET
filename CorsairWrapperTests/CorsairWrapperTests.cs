using CorsairWrapper.Corsair;
using NUnit.Framework;
using System.Linq;

namespace CorsairWrapperTests
{
    /***
     * Corsair SDK Tests
     * 
     * TESTS WILL ONLY WORK WITH AT LEAST ONE CORSAIR PERIPHERAL CONNECTED
     * 
     * If at least one device is connected and they still fail, then it's a code issue.
     * ***/
    public class CorsairWrapperTests
    {
        [SetUp]
        public void Setup()
        {
            CorsairSDK.CorsairPerformProtocolHandshake();
        }

        [Test]
        public void CorsairPerformProtocolHandshakeTest()
        {
            var details = CorsairSDK.CorsairPerformProtocolHandshake();
            Assert.NotNull(details);
        }

        [Test]
        public void CorsairGetDeviceCount()
        {
            var count = CorsairSDK.CorsairGetDeviceCount();
            Assert.NotZero(count);
        }

        [Test]
        public void CorsairGetDeviceInfo()
        {
            var deviceInfo = CorsairSDK.CorsairGetDeviceInfo(0);

            Assert.NotNull(deviceInfo);
        }

        [Test]
        public void CorsairGetLedPositionsByDeviceIndex()
        {
            var deviceInfo = CorsairSDK.CorsairGetLedPositionsByDeviceIndex(0);

            Assert.NotNull(deviceInfo);
            Assert.NotNull(deviceInfo.pLedPosition);
            Assert.NotZero(deviceInfo.pLedPosition.Count());
        }

        [Test]
        public void CorsairGetLedsColorsByDeviceIndex()
        {
            //var deviceInfo = CorsairSDK.CorsairGetLedsColorsByDeviceIndex(0);

            //Assert.NotNull(deviceInfo);
            //Assert.NotNull(deviceInfo.pLedPosition);
            //Assert.NotZero(deviceInfo.pLedPosition.Count());
        }
    }
}