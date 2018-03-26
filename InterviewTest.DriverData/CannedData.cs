using System;
using System.Collections.Generic;

namespace InterviewTest.DriverData
{
    public static class CannedDrivingData
    {
        private static readonly DateTimeOffset _day = new DateTimeOffset(2016, 10, 13, 0, 0, 0, 0, TimeSpan.Zero);

        // BONUS: What's so great about IReadOnlyCollections?
        public static readonly IReadOnlyCollection<Period> History = new[]
        {
            new Period
            {
                Start = _day + new TimeSpan(0, 0, 0),
                End = _day + new TimeSpan(8, 54, 0),
                AverageSpeed = 0m
            },
            new Period
            {
                Start = _day + new TimeSpan(8, 54, 0),
                End = _day + new TimeSpan(9, 28, 0),
                AverageSpeed = 28m
            },
            new Period
            {
                Start = _day + new TimeSpan(9, 28, 0),
                End = _day + new TimeSpan(9, 35, 0),
                AverageSpeed = 33m
            },
            new Period
            {
                Start = _day + new TimeSpan(9, 50, 0),
                End = _day + new TimeSpan(12, 35, 0),
                AverageSpeed = 25m
            },
            new Period
            {
                Start = _day + new TimeSpan(12, 35, 0),
                End = _day + new TimeSpan(13, 30, 0),
                AverageSpeed = 0m
            },
            new Period
            {
                Start = _day + new TimeSpan(13, 30, 0),
                End = _day + new TimeSpan(19, 12, 0),
                AverageSpeed = 29m
            },
            new Period
            {
                Start = _day + new TimeSpan(19, 12, 0),
                End = _day + new TimeSpan(24, 0, 0),
                AverageSpeed = 0m
            }
        };


        public static readonly IReadOnlyCollection<Period> DeliveryHistoryTimeSlotNotInRange = new[]
        {
            new Period
            {
                Start = _day + new TimeSpan(0, 0, 0),
                End = _day + new TimeSpan(1 ,54, 0),
                AverageSpeed = 20m
            },
            new Period
            {
                Start = _day + new TimeSpan(2, 54, 0),
                End = _day + new TimeSpan(4, 28, 0),
                AverageSpeed = 28m
            },
            new Period
            {
                Start = _day + new TimeSpan(5, 28, 0),
                End = _day + new TimeSpan(6, 35, 0),
                AverageSpeed = 13m
            },
            new Period
            {
                Start = _day + new TimeSpan(6, 50, 0),
                End = _day + new TimeSpan(7, 35, 0),
                AverageSpeed = 15m
            },
            new Period
            {
                Start = _day + new TimeSpan(20, 35, 0),
                End = _day + new TimeSpan(21, 30, 0),
                AverageSpeed = 18m
            }

        };

        public static readonly IReadOnlyCollection<Period> DeliveryHistortAverageSpeedGreaterThanMaxLimit = new[]
       {
            new Period
            {
                Start = _day + new TimeSpan(9, 0, 0),
                End = _day + new TimeSpan(1 ,54, 0),
                AverageSpeed = 30.5m
            },
            new Period
            {
                Start = _day + new TimeSpan(10, 54, 0),
                End = _day + new TimeSpan(3, 28, 0),
                AverageSpeed = 41m
            },
            new Period
            {
                Start = _day + new TimeSpan(10, 28, 0),
                End = _day + new TimeSpan(4, 35, 0),
                AverageSpeed = 40m
            },
            new Period
            {
                Start = _day + new TimeSpan(1, 50, 0),
                End = _day + new TimeSpan(3, 35, 0),
                AverageSpeed = 50m
            },
            new Period
            {
                Start = _day + new TimeSpan(20, 35, 0),
                End = _day + new TimeSpan(21, 30, 0),
                AverageSpeed = 50.89m
            }

        };

        public static readonly IReadOnlyCollection<Period> DeliveryHistoryWithContinousWithMaxSpeedLimit = new[]
        {
            new Period
            {
                Start = _day + new TimeSpan(9, 0, 0),
                End = _day + new TimeSpan(17 ,00, 0),
                AverageSpeed = 30m
            }
        };
        public static readonly IReadOnlyCollection<Period> DeliveryHistoryContinousWithinTimeSlotWithinMaxSpeedLimit = new[]
         {
            new Period
            {
                Start = _day + new TimeSpan(9, 0, 0),
                End = _day + new TimeSpan(11 ,30, 0),
                AverageSpeed = 21.55m
            },
            new Period
            {
                Start = _day + new TimeSpan(11, 30, 0),
                End = _day + new TimeSpan(14, 0, 0),
                AverageSpeed = 24
            },
            new Period
            {
                Start = _day + new TimeSpan(14, 0, 0),
                End = _day + new TimeSpan(15, 35, 0),
                AverageSpeed = 26m
            },
            new Period
            {
                Start = _day + new TimeSpan(15, 35, 0),
                End = _day + new TimeSpan(17, 0, 0),
                AverageSpeed = 28m
            }
        };


        public static readonly IReadOnlyCollection<Period> DeliveryHistoryWithBreaksWithinTimeSlotWithinMaxSpeedLimit = new[]
        {
            new Period
            {
                Start = _day + new TimeSpan(9, 0, 0),
                End = _day + new TimeSpan(11 ,30, 0),
                AverageSpeed = 21.55m
            },
            new Period
            {
                Start = _day + new TimeSpan(12, 0, 0),
                End = _day + new TimeSpan(14, 0, 0),
                AverageSpeed = 24
            },
            new Period
            {
                Start = _day + new TimeSpan(14, 30, 0),
                End = _day + new TimeSpan(15, 30, 0),
                AverageSpeed = 26m
            },
            new Period
            {
                Start = _day + new TimeSpan(16, 00, 0),
                End = _day + new TimeSpan(17, 0, 0),
                AverageSpeed = 28m
            }
        };


    }
}
