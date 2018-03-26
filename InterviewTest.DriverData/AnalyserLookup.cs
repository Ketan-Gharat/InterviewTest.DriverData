using System;
using InterviewTest.DriverData.Analysers;

namespace InterviewTest.DriverData
{
	public static class AnalyserLookup
	{
		public static IAnalyser GetAnalyser(string type)
		{
			switch (type)
			{
				case "friendly":
					return new FriendlyAnalyser();
                case "delivery":
                    return new DeliveryDriverAnalyser(new AnalyserConfiguration { StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(5, 0, 0), MaxSpeed = 30m });
                default:
					throw new ArgumentOutOfRangeException(nameof(type), type, "Unrecognised analyser type");
			}
		}
	}
}
