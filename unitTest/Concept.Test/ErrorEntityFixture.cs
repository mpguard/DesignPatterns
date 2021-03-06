﻿using MedikzWorks.PracticalPattern.Concept.Operator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Concept.Tests
{
    [TestClass]
    public class ErrorEntityFixture
    {
        [TestMethod]
        public void Test()
        {
            var entity = new ErrorEntity();
            entity += "用户名不能为空";
            entity += "职务不能为空";
            entity += "关注领域不能为空";
            entity += 1;
            entity += 2;

            Assert.AreEqual<int>(3, entity.Messages.Count);
            Assert.AreEqual<int>(2, entity.Codes.Count);
            Trace.WriteLine(string.Join("\n", entity.Messages));
        }
    }
}
