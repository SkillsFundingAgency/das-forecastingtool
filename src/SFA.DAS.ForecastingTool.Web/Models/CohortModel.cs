﻿using System;

namespace SFA.DAS.ForecastingTool.Web.Models
{
    public class CohortModel
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public DateTime StartDate { get; set; }
    }
}