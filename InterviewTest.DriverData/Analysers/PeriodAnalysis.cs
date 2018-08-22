using System;

namespace InterviewTest.DriverData.Analysers
{
    public class PeriodAnalysis
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public decimal Duration { get; set; }

        public decimal Rating { get; set; }

        public bool IsUndocumented { get; set; }
    }
}