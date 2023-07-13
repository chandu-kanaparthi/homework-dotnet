using Newtonsoft.Json;
using System.Collections.Generic;

namespace SwEngHomework.Commissions
{
    public class CommissionCalculator : ICommissionCalculator
    {
        private class InputData
        {
            public List<Advisor> Advisors { get; set; }
            public List<Account> Accounts { get; set; }
        }

        private class Advisor
        {
            public string Name { get; set; }
            public string Level { get; set; }
        }

        private class Account
        {
            public string Advisor { get; set; }
            public double PresentValue { get; set; }
        }

        public IDictionary<string, double> CalculateCommissionsByAdvisor(string jsonInput)
        {
            var data = JsonConvert.DeserializeObject<InputData>(jsonInput);

            var commissionRateByLevel = new Dictionary<string, double>
            {
                { "Senior", 1.0 },
                { "Experienced", 0.5 },
                { "Junior", 0.25 }
            };

            var basisPointsByValue = new (double limit, double bps)[]
            {
                (50000, 0.05),
                (100000, 0.06),
                (double.MaxValue, 0.07)
            };

            var commissionsByAdvisor = new Dictionary<string, double>();

            foreach (var advisor in data.Advisors)
            {
                commissionsByAdvisor[advisor.Name] = 0;
            }

            foreach (var account in data.Accounts)
            {
                var advisorName = account.Advisor;
                if (!commissionsByAdvisor.ContainsKey(advisorName)) continue;

                double basisPoints = 0;

                foreach (var (limit, bps) in basisPointsByValue)
                {
                    if (account.PresentValue < limit)
                    {
                        basisPoints = bps;
                        break;
                    }
                }

                var accountFee = account.PresentValue * basisPoints / 100;
                var advisor = data.Advisors.Find(a => a.Name == advisorName);

                commissionsByAdvisor[advisorName] += accountFee * commissionRateByLevel[advisor.Level];
            }

            foreach (var advisor in commissionsByAdvisor.Keys.ToList())
            {
                commissionsByAdvisor[advisor] = Math.Round(commissionsByAdvisor[advisor], 2);
            }

            return commissionsByAdvisor;
        }
    }
}
