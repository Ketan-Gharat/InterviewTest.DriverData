using System;
using System.Diagnostics;

namespace InterviewTest.DriverData
{
	[DebuggerDisplay("{_DebuggerDisplay,nq}")]
	public class Period
	{
        // BONUS: What's the difference between DateTime and DateTimeOffset?

        /* A DateTime value defines a particular date and time. It includes a Kind property that provides limited information about the time zone to which that date and time belongs.
         * 
         * The DateTimeOffset structure represents a date and time value, together with an offset that indicates how much that value differs from UTC
         * This value always unambiguously identifies a single point in time. DateTimeOffset is not tied to a particular time zone, but can originate from any of a variety of time zones. 
         * 
         * Since DateTimeOffset includes all of the functionality of the DateTime type along with time zone awareness.
         */

        public DateTimeOffset Start;
		public DateTimeOffset End;

        // BONUS: What's the difference between decimal and double?

        /* Double is a 64-bit floating-point number.
         * Double have a higher range than decimal but less precision.
         * Performance wise double performs faster.
         * 
         * Decimal is a 128-bit floating-point number.
         * Decimal have much higher precision and should be used in applications that require a high degree of accuracy.
         */

        public decimal AverageSpeed;

		private string _DebuggerDisplay => $"{Start:t} - {End:t}: {AverageSpeed}";
	}
}
