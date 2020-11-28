using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace csharp.Tests
{
    class LeetCode_72_EditDistance
    {
        #region Inner classes
        private class TestCase
        {
            public string word1;
            public string word2;
            public int expect;
        };
        #endregion

        [Test]
        public void TestWhenAtLeastOneStringIsEmpty()
        {
            var obj = new EditDistance();
            var testCases = new TestCase[]
            {
                new TestCase
                {
                    word1 = string.Empty,
                    word2 = "test",
                    expect = 4,
                },
                new TestCase
                {
                    word1 = string.Empty,
                    word2 = string.Empty,
                    expect = 0,
                },
            };

            _CheckResults(obj, testCases);
        }

        [Test]
        public void TestGeneralCases()
        {
            var obj = new EditDistance();
            var testCases = new TestCase[]
            {
                new TestCase
                {
                    word1 = "aaaa",
                    word2 = "aaas",
                    expect = 1,
                },
                new TestCase
                {
                    word1 = "saaa",
                    word2 = "aaa",
                    expect = 1,
                },
                new TestCase
                {
                    word1 = "aasa",
                    word2 = "aaa",
                    expect = 1,
                },
                new TestCase
                {
                    word1 = "asba",
                    word2 = "aba",
                    expect = 1,
                },
                new TestCase
                {
                    word1 = "asba",
                    word2 = "aba",
                    expect = 1,
                },
                new TestCase
                {
                    word1 = "asbac",
                    word2 = "aba",
                    expect = 2,
                },
                new TestCase
                {
                    word1 = "dinitrophenylhydrazine",
                    word2 = "benzalphenylhydrazone",
                    expect = 7,
                },
            };

            _CheckResults(obj, testCases);
        }

        private void _CheckResults(EditDistance obj, TestCase[] testCases)
        {
            foreach (var testCase in testCases)
            {
                var result = obj.MinDistance(testCase.word1, testCase.word2);
                Assert.AreEqual(testCase.expect, result);
            }
        }
    }
}
