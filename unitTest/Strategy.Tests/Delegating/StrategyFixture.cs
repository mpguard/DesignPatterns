﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Strategy.Tests.Delegating
{
    [TestClass]
    public class StrategyFixture
    {
        int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        class DataSelector
        {
            public Func<IEnumerable<int>, int> FindStrategy { get; set; }

            public int Find(IEnumerable<int> data)
            {
                if (data == null) throw new ArgumentNullException("data");
                return FindStrategy(data);
            }
        }

        [TestMethod]
        public void Test()
        {
            // 1 
            Assert.AreEqual<int>(data.Where(x => x % 2 == 0).Max(), 8);
            Assert.AreEqual<int>(data.Where(x => x % 2 == 0).Min(), 2);

            // 2
            var oddNumbers = data.Where(x => x % 2 == 1);
            var c = 1;
            oddNumbers.ToList().ForEach(x =>
                {
                    Assert.AreEqual<int>(c, x);
                    c += 2;
                });

            var selector = new DataSelector()
            {
                FindStrategy = x => x.Max()
            };
            Assert.AreEqual<int>(9,selector.Find(data));
        }
    }
}
