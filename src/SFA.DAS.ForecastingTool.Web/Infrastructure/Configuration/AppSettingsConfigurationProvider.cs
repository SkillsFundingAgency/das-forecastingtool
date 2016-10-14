﻿using System.Configuration;

namespace SFA.DAS.ForecastingTool.Web.Infrastructure.Configuration
{
    public class AppSettingsConfigurationProvider : IConfigurationProvider
    {
        public string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public decimal LevyPercentage
        {
            get
            {
                var value = GetSetting("Levy:Percentage");
                decimal pct;
                if (!decimal.TryParse(value, out pct))
                {
                    return 1;
                }
                return pct;
            }
        }
        public int LevyAllowance
        {
            get
            {
                var value = GetSetting("Levy:Allowance");
                int allowance;
                if (!int.TryParse(value, out allowance))
                {
                    return 0;
                }
                return allowance;
            }
        }
        public decimal LevyTopupPercentage
        {
            get
            {
                var value = GetSetting("Levy:TopupPercentage");
                decimal pct;
                if (!decimal.TryParse(value, out pct))
                {
                    return 1;
                }
                return pct;
            }
        }

        public decimal CopaymentPercentage
        {
            get
            {
                var value = GetSetting("Copay:Percentage");
                decimal pct;
                if (!decimal.TryParse(value, out pct))
                {
                    return 1;
                }
                return pct;
            }
        }


        public decimal FinalTrainingPaymentPercentage
        {
            get
            {
                var value = GetSetting("Training:FinalPaymentPercentage");
                decimal pct;
                if (!decimal.TryParse(value, out pct))
                {
                    return 1;
                }
                return pct;
            }
        }

        public int SunsettingPeriod
        {
            get
            {
                var value = GetSetting("Levy:SunsettingPeriod");

                int period;
                if (!int.TryParse(value, out period))
                {
                    return 18;
                }

                return period;
            }
        }

        public int ForecastDuration {
            get
            {
                var value = GetSetting("Levy:ForecastDuration");

                int duration;
                if (!int.TryParse(value, out duration))
                {
                    return 36;
                }

                return duration;
            }
        }
    }
}