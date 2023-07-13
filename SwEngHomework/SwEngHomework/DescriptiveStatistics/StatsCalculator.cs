namespace SwEngHomework.DescriptiveStatistics
{
    public class StatsCalculator : IStatsCalculator
    {
        public Stats Calculate(string semicolonDelimitedContributions)
        {
            var contributions = semicolonDelimitedContributions.Split(';');
            List<double> contributionValues = new List<double>();

            foreach (var contribution in contributions)
            {
                if (double.TryParse(contribution.Replace("$", "").Replace(",", ""), out double value))
                {
                    contributionValues.Add(value);
                }
            }

            if (contributionValues.Count == 0)
            {
                return new Stats
                {
                    Average = 0,
                    Median = 0,
                    Range = 0
                };
            }

            contributionValues.Sort();

            double average = contributionValues.Average();
            double median = contributionValues.Count % 2 == 0 
                ? (contributionValues[contributionValues.Count / 2] + contributionValues[contributionValues.Count / 2 - 1]) / 2 
                : contributionValues[contributionValues.Count / 2];

            double range = contributionValues.Max() - contributionValues.Min();

            return new Stats
            {
                Average = Math.Round(average, 2),
                Median = Math.Round(median, 2),
                Range = Math.Round(range, 2)
            };
        }
    }
}
