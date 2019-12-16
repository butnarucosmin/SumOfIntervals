using System;
using System.Collections.Generic;
using System.Linq;
using Interval = System.ValueTuple<int, int>;

namespace SumOfIntervals
{
    public class Intervals
    {
        public static int SumIntervals((int, int)[] intervals)
        {
            var finalList = new List<Interval>();
            var orderedIntervals = intervals.OrderBy(x => x.Item1).ToList();

            for (int i = 0; i < orderedIntervals.Count(); i++)
            {
                var newInterval = new Interval(orderedIntervals[i].Item1, orderedIntervals[i].Item2);
                while (i < orderedIntervals.Count() - 1 && newInterval.Item2 > orderedIntervals[i + 1].Item1)
                {
                    newInterval.Item2 = Math.Max(newInterval.Item2, orderedIntervals[i + 1].Item2);
                    i++;
                }
                finalList.Add(newInterval);
            }

            if (finalList.Count() == 0)
                return 0;
            else
            {
                var sum = 0;

                foreach(var v in finalList)
                    sum += v.Item2 - v.Item1;

                return sum;
            }
        }
    }
}
