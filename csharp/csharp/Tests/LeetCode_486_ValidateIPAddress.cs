using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace csharp.Tests
{
    class LeetCode_486_ValidateIPAddress
    {
        #region Inner classes
        private class TestCase
        {
            public string IpAddress;
            public string ExpectResult;
        }
        #endregion

        [Test]
        public void TestValidIpV4Address()
        {
            var obj = new ValidateIPAddress();

            var testCases = new TestCase[]
            {
                new TestCase
                {
                    IpAddress = "172.16.254.1",
                    ExpectResult = "IPv4",
                },
                new TestCase
                {
                    IpAddress = "192.168.1.0",
                    ExpectResult = "IPv4",
                },
            };

            _CheckResults(obj, testCases);
        }

        [Test]
        public void TestInvalidIpV4Address()
        {
            var obj = new ValidateIPAddress();

            var testCases = new TestCase[]
            {
                new TestCase
                {
                    IpAddress = "192.168.1.01",
                    ExpectResult = "Neither",
                },
                new TestCase
                {
                    IpAddress = "192.168.1.00",
                    ExpectResult = "Neither",
                },
                new TestCase
                {
                    IpAddress = "192.168@1.0",
                    ExpectResult = "Neither",
                },
                new TestCase
                {
                    IpAddress = "1e1.4.5.6",
                    ExpectResult = "Neither",
                },
                new TestCase
                {
                    IpAddress = "300.4.5.6",
                    ExpectResult = "Neither",
                },
                new TestCase
                {
                    IpAddress = "192.168.1",
                    ExpectResult = "Neither",
                },
            };

            _CheckResults(obj, testCases);
        }

        [Test]
        public void TestValidIpV6Address()
        {
            var obj = new ValidateIPAddress();

            var testCases = new TestCase[]
            {
                new TestCase
                {
                    IpAddress = "2001:0db8:85a3:0000:0000:8a2e:0370:7334",
                    ExpectResult = "IPv6",
                },
                new TestCase
                {
                    IpAddress = "2001:0db8:85a3:0:0:8a2e:0370:7334",
                    ExpectResult = "IPv6",
                },
            };

            _CheckResults(obj, testCases);
        }

        [Test]
        public void TestInvalidIpV6Address()
        {
            var obj = new ValidateIPAddress();

            var testCases = new TestCase[]
            {
                new TestCase
                {
                    IpAddress = "2001:0db8:85a3::8a2e:0370:7334",
                    ExpectResult = "Neither",
                },
                new TestCase
                {
                    IpAddress = "02001:0db8:85a3:0000:0000:8a2e:0370:7334",
                    ExpectResult = "Neither",
                },
                new TestCase
                {
                    IpAddress = "20EE:FGb8:85a3:0:0:8A2E:0370:7334",
                    ExpectResult = "Neither",
                },
            };

            _CheckResults(obj, testCases);
        }

        private void _CheckResults(ValidateIPAddress obj, TestCase[] testCases)
        {
            foreach (var testCase in testCases)
            {
                Assert.AreEqual(testCase.ExpectResult, obj.ValidIPAddress(testCase.IpAddress));
            }
        }
    }
}
