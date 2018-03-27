using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.DriverData.Analysers
{
    // BONUS: Why internal?
    /* Classes declared with internal can be access by any member within application i.e. (within assembly)
     * 
     * Declaring Class (DeliveryDriverAnalyser) as internal here limits the access within the current project assembly
     */

    internal class DeliveryDriverAnalyser : IAnalyser
	{
        private AnalyserConfiguration _analyserConfiguration { get; set; }
        public DeliveryDriverAnalyser(AnalyserConfiguration analyserConfiguration)
        {
            _analyserConfiguration = analyserConfiguration;
        }
        public HistoryAnalysis Analyse(IReadOnlyCollection<Period> history)
        {
            HistoryAnalysis historyAnalysis = new HistoryAnalysis();
            if (history != null && history.Any())
            {
                //Ignore anything outside of 9 - 5
                var validPeriods = history.Where(period => period.End.TimeOfDay > _analyserConfiguration.StartTime && period.Start.TimeOfDay < _analyserConfiguration.EndTime).OrderBy(x => x.Start);
                List<PeriodAnalysis> periodAnalyses = new List<PeriodAnalysis>();

                if (validPeriods != null && validPeriods.Any())
                {
                    //Correct Valid periods
                    if (validPeriods.FirstOrDefault().Start.TimeOfDay < _analyserConfiguration.StartTime)
                    {
                        validPeriods.FirstOrDefault().Start = validPeriods.FirstOrDefault().Start.Add(_analyserConfiguration.StartTime - validPeriods.FirstOrDefault().Start.TimeOfDay);
                    }
                    if (validPeriods.LastOrDefault().End.TimeOfDay > _analyserConfiguration.EndTime)
                    {
                        validPeriods.LastOrDefault().End = validPeriods.LastOrDefault().End.Subtract(validPeriods.LastOrDefault().End.TimeOfDay - _analyserConfiguration.EndTime);
                    }
                    foreach (var period in validPeriods)
                    {
                        var periodAnalysis = new PeriodAnalysis();
                        periodAnalysis.StartTime = period.Start.TimeOfDay;
                        periodAnalysis.EndTime = period.End.TimeOfDay;
                        periodAnalysis.Duration = (decimal)(period.End - period.Start).TotalSeconds;
                        periodAnalysis.Rating = period.AverageSpeed > _analyserConfiguration.MaxSpeed ? 0 : period.AverageSpeed / _analyserConfiguration.MaxSpeed;
                        periodAnalyses.Add(periodAnalysis);
                    }
                }

                var analysedUndocumemdtedPeriods = AnalyseUndocumentedPeriods(validPeriods).ToList();
                periodAnalyses = periodAnalyses.Concat(analysedUndocumemdtedPeriods).ToList();
                periodAnalyses = periodAnalyses.OrderBy(item => item.StartTime).ToList();

                ComputeDriverRating(historyAnalysis, periodAnalyses);

                var analysedTimeSpan = periodAnalyses.Where(periodAnalysis => !periodAnalysis.IsUndocumented).Sum(periodAnalysis => periodAnalysis.Duration);
                historyAnalysis.AnalysedDuration = new TimeSpan(0, 0, (int)analysedTimeSpan);
            }
            return historyAnalysis;
        }

        private IEnumerable<PeriodAnalysis> AnalyseUndocumentedPeriods(IEnumerable<Period> validPeriods)
        {
            var undocumentedPeriodAnalyses = new List<PeriodAnalysis>();

            var validPeriodCount = validPeriods.Count();
            for (int i = 0; i < validPeriodCount; i++)
            {
                // Check if first period start time is greater then the allowed start time , if yes then get this time difference as undocumented period
                if (i == 0 && validPeriods.ElementAt(i).Start.TimeOfDay > _analyserConfiguration.StartTime)
                {
                    decimal duration = (decimal)(validPeriods.ElementAt(i).Start.TimeOfDay - _analyserConfiguration.StartTime).TotalSeconds;
                    undocumentedPeriodAnalyses.Add(new PeriodAnalysis { StartTime = _analyserConfiguration.StartTime, EndTime = validPeriods.ElementAt(i).Start.TimeOfDay, Duration = duration, Rating = 0, IsUndocumented = true });
                }
                // Check if last period end time is less than allowed end time, if yes then then get this time difference as undocumented period
                else if (i == validPeriodCount - 1 && validPeriods.ElementAt(i).End.TimeOfDay < _analyserConfiguration.EndTime)
                {
                    decimal duration = (decimal)(_analyserConfiguration.EndTime - validPeriods.ElementAt(i).End.TimeOfDay).TotalSeconds;
                    undocumentedPeriodAnalyses.Add(new PeriodAnalysis() { StartTime = validPeriods.ElementAt(i).End.TimeOfDay, EndTime = _analyserConfiguration.EndTime, Duration = duration, Rating = 0, IsUndocumented = true });
                }
                // Check if current  period start time is less than that of end time of previous period,if yes then get this time difference as undocumented period
                else if (i > 0 && validPeriods.ElementAt(i).Start.TimeOfDay > _analyserConfiguration.StartTime && validPeriods.ElementAt(i).Start.TimeOfDay > validPeriods.ElementAt(i - 1).End.TimeOfDay)
                {
                    decimal duration = (decimal)(validPeriods.ElementAt(i).Start.TimeOfDay - validPeriods.ElementAt(i - 1).End.TimeOfDay).TotalSeconds;
                    undocumentedPeriodAnalyses.Add(new PeriodAnalysis { StartTime = validPeriods.ElementAt(i - 1).End.TimeOfDay, EndTime = validPeriods.ElementAt(i).Start.TimeOfDay, Duration = duration, Rating = 0, IsUndocumented = true });
                }
            }
            return undocumentedPeriodAnalyses;
        }

        private void ComputeDriverRating(HistoryAnalysis historyAnalysis, List<PeriodAnalysis> periodAnalyses)
        {
            var weightedSum = periodAnalyses.Select(periodAnalysis => periodAnalysis.Duration * periodAnalysis.Rating).Sum();
            historyAnalysis.DriverRating = weightedSum > 0 ? weightedSum / periodAnalyses.Sum(periodAnalysis => periodAnalysis.Duration) : 0;
        }
    }
}