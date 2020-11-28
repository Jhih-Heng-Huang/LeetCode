using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace csharp.Tests
{
    public class LeetCode240SearchA2DMatrixIITest
    {
        [Test]
        public void Add()
        {
            var map = new int[,]
            {
                {1,2,3 },
                {2,4,5 },
                {3,5,6 },
            };
            var target = 3;

            var obj = new LeetCode240SearchA2DMatrixII();
            var result = obj.SearchMatrix(map, target);
            var expect = true;

            Assert.AreEqual(result, expect);
        }
    }
}
