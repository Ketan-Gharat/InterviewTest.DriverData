﻿using InterviewTest.DriverData.Analysers;
using NUnit.Framework;
using System;

namespace InterviewTest.DriverData.UnitTests.Analysers
{
    [TestFixture]
    [Ignore("Not Implemented")]
    public class FormulaOneAnalyserTests
    {
        [Test]
        public void ShouldYieldCorrectValues()
        {
            var expectedResult = new HistoryAnalysis
            {
                AnalysedDuration = new TimeSpan(10, 3, 0),
                DriverRating = 0.1231m
            };

            var actualResult = new FormulaOneAnalyser().Analyse(CannedDrivingData.History);

            Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
            Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating).Within(0.001m));
        }
    }
}