using System;
using System.Collections;

namespace Weathered.API.Helpers
{
    public static class Extensions
    {
        public static IEnumerable EachDay(this DateTime start, DateTime end)
        {
            var currentDay = start.Date;
            while (currentDay <= end)
            {
                yield return currentDay;
                currentDay = currentDay.AddDays(1);
            }
        }
    }
}