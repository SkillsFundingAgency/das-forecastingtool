﻿using SFA.DAS.ForecastingTool.Core.Models.FinancialForecasting;

namespace SFA.DAS.ForecastingTool.Core.Models
{
    public class ResultsViewModel : ForecastQuestionsModel
    {
        public MonthlyCashflow[] Results { get; set; }
        public decimal LevyAmount { get; set; }
        public decimal LevyFundingReceived { get; set; }
        public string TopPercentageForDisplay { get; set; }
        public bool CanAddPeriod { get; set; }
        public string NextPeriodUrl { get; set; }
        public decimal TrainingCostForDuration { get; set; }
        public decimal LevyFundingReceivedForDuration { get; set; }
        public decimal FundingShortfallForDuration { get; set; }
        public decimal MonthlyLevyPaid { get; set; }
        public decimal LevyPercentage { get; set; }
        public int Allowance { get; set; }
        public int SunsetPeriod { get; set; }
    }
}