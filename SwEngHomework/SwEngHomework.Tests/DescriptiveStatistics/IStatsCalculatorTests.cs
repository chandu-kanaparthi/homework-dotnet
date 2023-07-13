using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwEngHomework.DescriptiveStatistics;

namespace SwEngHomework.Tests.DescriptiveStatistics
{
    [TestClass]
    public class IStatsCalculatorTests
    {
        private IStatsCalculator Calculator;

        [TestInitialize]
        public void TestInitialize()
        {
            Calculator = new StatsCalculator();
        }

        [TestMethod]
        public void CalculatesStats_WithEvenAmounts()
        {
            string input = "$2,550.50; 1000;   $6345.45; 7,565.65;12,568.68;$6356.56;2550.5; 500.45";

            Stats stats = Calculator.Calculate(input);

            Assert.AreEqual(4929.72, stats.Average);
            Assert.AreEqual(4447.98, stats.Median);
            Assert.AreEqual(12068.23, stats.Range);
        }

        [TestMethod]
        public void CalculatesStats_WithOddAmounts_AndOneBadInput()
        {
            string input = "10.00;25.5; 63.45;$ 63.56;$75.65; 125.68; $25.5; kitty cat";

            Stats stats = Calculator.Calculate(input);

            Assert.AreEqual(55.62, stats.Average);
            Assert.AreEqual(63.45, stats.Median);
            Assert.AreEqual(115.68, stats.Range);
        }

        [TestMethod]
        public void CalculatesStats_WithAllBadInput()
        {
            string input = "this is certainly not valid";

            Stats stats = Calculator.Calculate(input);

            Assert.AreEqual(0, stats.Average);
            Assert.AreEqual(0, stats.Median);
            Assert.AreEqual(0, stats.Range);
        }
    }
}
