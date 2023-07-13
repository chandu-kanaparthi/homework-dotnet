using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwEngHomework.Commissions;
using System.IO;
using System.Collections.Generic;

namespace SwEngHomework.Tests.Commissions
{
    [TestClass]
    public class ICommissionCalculatorTests
    {
        private ICommissionCalculator Calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            Calculator = new CommissionCalculator();
        }

        [TestMethod]
        public void CalculatesCommissionsCorrectly()
        {
            string input = File.ReadAllText(@"Commissions\input.json");

            IDictionary<string, double> report = Calculator.CalculateCommissionsByAdvisor(input);

            Assert.AreEqual(63.50, report["Joe"]);
            Assert.AreEqual(388.97, report["Karen"]);
            Assert.AreEqual(38.25, report["Susan"]);
            Assert.AreEqual(31.15, report["Karl"]);
            Assert.AreEqual(1.21, report["Jenny"]);
            Assert.AreEqual(0, report["Mike"]);
        }
    }
}
