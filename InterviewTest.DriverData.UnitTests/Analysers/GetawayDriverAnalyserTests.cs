using InterviewTest.DriverData.Analysers;
using NUnit.Framework;
using System;

namespace InterviewTest.DriverData.UnitTests.Analysers
{
    [TestFixture]
    [Ignore("Not Consider")]
    public class GetawayDriverAnalyserTests
    {
        [Test]
        public void ShouldYieldCorrectValues()
        {
            var expectedResult = new HistoryAnalysis
            {
                AnalysedDuration = TimeSpan.FromHours(1),
                DriverRating = 0.1813m
            };

            var actualResult = new GetawayDriverAnalyser().Analyse(CannedDrivingData.History);

            Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
            Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating).Within(0.001m));
        }
    }
}