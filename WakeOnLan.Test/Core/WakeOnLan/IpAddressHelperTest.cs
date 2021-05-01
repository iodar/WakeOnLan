using System;
using System.Net;
using NUnit.Framework;
using WakeOnLan.WakeOnLan.Core.WakeOnLan;

namespace WakeOnLan.WakeOnLan.Test.Core.WakeOnLan
{
    public class IpAddressHelperTest
    {
        [TestCase("255.255.255")]
        [TestCase("255.255.25")]
        [TestCase("255.255.1")]
        [TestCase("255.255.1.")]
        [TestCase("255255.1.1")]
        [TestCase("255.255.255.i")]
        [TestCase("1.10.243.1234")]
        [TestCase("asas")]
        [TestCase("12.121212")]
        [TestCase("1324456543")]
        [TestCase(@"!""!"" &%§&""$")]
        [Test(Description = "When IpFromString is called with invalid ip address should throw an exception")]
        public void WhenCalledWithInvalidIpAddressFormatShouldThrowException(string invalidIpAddress)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                IpAddressHelper.Ipv4FromString(invalidIpAddress);
            });
        }

        [TestCase("255.255.255.255")]
        [TestCase("255.255.255.10")]
        [TestCase("255.10.255.10")]
        [TestCase("255.1.255.10")]
        [TestCase("10.10.2.1")]
        [TestCase("1.2.3.4")]
        [TestCase("102.1.243.1")]
        [TestCase("1.1.243.1")]
        [Test(Description = "When IpFromString is called with a valid ip address it should convert the input to long")]
        public void WhenCalledWithValidIpAddressShouldReturnLongThatIsNotNull(string validIpAddress)
        {
            Assert.DoesNotThrow(() =>
            {
                long address = IpAddressHelper.Ipv4FromString(validIpAddress);
                Assert.IsNotNull(address);
            });
        }

        [TestCase("255.255.255.255", 4294967295)]
        [TestCase("255.255.255.0", 16777215)]
        [TestCase("10.10.2.1", 16910858)]
        [TestCase("143.24.20.36", 605296783)]
        [TestCase("1.2.3.4", 67305985)]
        public void WhenCalledWithValidIpAddressShouldReturnValidInt64Representation(string validIpAddress, long expectedResultAddress)
        {
            long ipAddress = IpAddressHelper.Ipv4FromString(validIpAddress);
            Assert.AreEqual(expectedResultAddress, ipAddress);
        }

        [TestCase("255.255.255.255", 4294967295)]
        public void WhenCalledWithValidIpAddressShouldReturnNetIpAddress(string ipAddress, long netIpAddressLongValue)
        {
            IPAddress actualAddress = IpAddressHelper.Ipv4AddressFromString(ipAddress);
            Assert.AreEqual(new IPAddress(netIpAddressLongValue), actualAddress);
        }
    }
}