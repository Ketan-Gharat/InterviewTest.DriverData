using System;
using InterviewTest.DriverData.Analysers;
using NUnit.Framework;

namespace InterviewTest.DriverData.UnitTests.Analysers
{
	[TestFixture]
	public class FriendlyAnalyserTests
	{
        // BONUS: What is AAA?
        /* Arrange Act Assert is the one of the structutre way to write the unit units
         * 
         * Arrange: During Arrange you are arranging things prior to calling the method/function to test. 
         * 
         * Act : Perform the actual work of the test. Here we call the actual method and pass any required values if essential to the method to invoke it
         * 
         * Assert: The assertion is the part that ensures that your expectations are met. Here we verify the results.
         * 
         */

        [Test]
		public void ShouldAnalyseWholePeriodAndReturn1ForDriverRating()
		{
			var data = new[]
			{
				new Period
				{
					Start = new DateTimeOffset(2001, 1, 1, 0, 0, 0, TimeSpan.Zero),
					End = new DateTimeOffset(2001, 1, 1, 12, 0, 0, TimeSpan.Zero),
					AverageSpeed = 20m
				},
				new Period
				{
					Start = new DateTimeOffset(2001, 1, 1, 12, 0, 0, TimeSpan.Zero),
					End = new DateTimeOffset(2001, 1, 2, 0, 0, 0, TimeSpan.Zero),
					AverageSpeed = 15m
				}
			};

			var expectedResult = new HistoryAnalysis
			{
				AnalysedDuration = TimeSpan.FromDays(1),
				DriverRating = 1m
			};

			var actualResult = new FriendlyAnalyser().Analyse(data);

			Assert.That(actualResult.AnalysedDuration, Is.EqualTo(expectedResult.AnalysedDuration));
			Assert.That(actualResult.DriverRating, Is.EqualTo(expectedResult.DriverRating));
		}
	}
}
