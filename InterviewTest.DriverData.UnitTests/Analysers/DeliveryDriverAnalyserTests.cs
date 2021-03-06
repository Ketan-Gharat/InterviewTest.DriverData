﻿using InterviewTest.DriverData.Analysers;
using NUnit.Framework;
using System;

namespace InterviewTest.DriverData.UnitTests.Analysers
{
    /* Followed AAA Structure for writing unit tests.
     * Followed Should_ExpectedBehavior_When_StateUnderTest Naming Convention for Unit tests naming
     */

    [TestFixture]
    public class DeliveryDriverAnalyserTests
    {
        #region Private Variables
        private DeliveryDriverAnalyser deliveryDriverAnalyser;

        //9-5 Speed 30m
        private readonly AnalyserConfiguration analyserConfiguration = new AnalyserConfiguration
        {
            StartTime = new TimeSpan(9, 0, 0),
            EndTime = new TimeSpan(17, 0, 0),
            MaxSpeed = 30m
        };
        #endregion Private Variables

        #region Initialization
        [SetUp]
        public void Initialize()
        {
            deliveryDriverAnalyser = new DeliveryDriverAnalyser(analyserConfiguration);
        }
        #endregion Initialization

        #region Tests

        [Test]
        public void Should_YieldCorrectRatingAndDuration_When_PeriodDataSuppiledHasTimeSpanAndAverageSpeedInRange()
        {
            var expectedResult = new HistoryAnalysis
            {
                AnalysedDuration = new TimeSpan(7, 45, 0),
                DriverRating = 0.7638m
            };

            var actualResult = deliveryDriverAnalyser.Analyse(CannedDrivingData.History);

            Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
            Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating).Within(0.001m));
        }

        [Test]
        public void Should_YieldZeroRatingAndDuration_When_NoPeriodDataisSuppiled()
        {
            var expectedResult = new HistoryAnalysis
            {
                AnalysedDuration = new TimeSpan(0, 0, 0),
                DriverRating = 0m
            };

            var actualResult = deliveryDriverAnalyser.Analyse(null);

            Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
            Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating).Within(0.001m));
        }

        [Test]
        public void Should_YieldZeroRatingAndDuration_When_PeriodDataSuppiledHasTimeSlotNotInRangeSpecified()
        {
            var expectedResult = new HistoryAnalysis
            {
                AnalysedDuration = new TimeSpan(0, 0, 0),
                DriverRating = 0m
            };

            var actualResult = deliveryDriverAnalyser.Analyse(CannedDrivingData.DeliveryHistoryTimeSlotNotInRange);

            Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
            Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating).Within(0.001m));
        }

        [Test]
        public void Should_YieldZeroRatingAndDuration_When_PeriodDataSuppiledHasAverageSpeedGreaterThanMaxLimit()
        {
            var expectedResult = new HistoryAnalysis
            {
                AnalysedDuration = new TimeSpan(0, 0, 0),
                DriverRating = 0m
            };

            var actualResult = deliveryDriverAnalyser.Analyse(CannedDrivingData.DeliveryHistortAverageSpeedGreaterThanMaxLimit);

            Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
            Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating).Within(0.001m));
        }

        [Test]
        public void Should_YieldRatingOfOne_When_DurationWithinTimeSlotAndWithMaxSpeedLimit()
        {
            var expectedResult = new HistoryAnalysis
            {
                AnalysedDuration = new TimeSpan(8, 0, 0),
                DriverRating = 1m
            };

            var actualResult = deliveryDriverAnalyser.Analyse(CannedDrivingData.DeliveryHistoryWithContinousWithMaxSpeedLimit);

            Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
            Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating).Within(0.001m));
        }

        [Test]
        public void Should_YieldCorrectRatingAndDuration_When_PeriodDataSuppiledWithinTimeSlotAndIsContinousAndWithinMaxSpeedLimit()
        {
            var expectedResult = new HistoryAnalysis
            {
                AnalysedDuration = new TimeSpan(8, 0, 0),
                DriverRating = 0.811m
            };

            var actualResult = deliveryDriverAnalyser.Analyse(CannedDrivingData.DeliveryHistoryContinousWithinTimeSlotWithinMaxSpeedLimit);

            Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
            Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating).Within(0.001m));
        }

        [Test]
        public void Should_YieldCorrectRatingAndDuration_When_PeriodDataSuppiledIsWithinTimeSlotWithBreaksAndWithinMaxSpeedLimit()
        {
            var expectedResult = new HistoryAnalysis
            {
                AnalysedDuration = new TimeSpan(6, 30, 0),
                DriverRating = 0.649m
            };

            var actualResult = deliveryDriverAnalyser.Analyse(CannedDrivingData.DeliveryHistoryWithBreaksWithinTimeSlotWithinMaxSpeedLimit);

            Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
            Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating).Within(0.001m));
        }

        #endregion Tests

        #region TearDown
        [TearDown]
        public void TestsCompletion()
        {
            deliveryDriverAnalyser = null;
        }
        #endregion TearDown
    }
}
