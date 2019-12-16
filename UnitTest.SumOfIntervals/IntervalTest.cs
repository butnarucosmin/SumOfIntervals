using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SumOfIntervals;
using Interval = System.ValueTuple<int, int>;

namespace UnitTest.SumOfIntervals
{
    [TestClass]
    public class IntervalTest
    {
        [TestMethod]
        public void ShouldHandleEmptyIntervals()
        {
            NUnit.Framework.Assert.AreEqual(0, Intervals.SumIntervals(new Interval[] { }));
            NUnit.Framework.Assert.AreEqual(0, Intervals.SumIntervals(new Interval[] { (4, 4), (6, 6), (8, 8) }));
        }

        [TestMethod]
        public void ShouldAddDisjoinedIntervals()
        {
            NUnit.Framework.Assert.AreEqual(9, Intervals.SumIntervals(new Interval[] { (1, 2), (6, 10), (11, 15) }));
            NUnit.Framework.Assert.AreEqual(11, Intervals.SumIntervals(new Interval[] { (4, 8), (9, 10), (15, 21) }));
            NUnit.Framework.Assert.AreEqual(7, Intervals.SumIntervals(new Interval[] { (-1, 4), (-5, -3) }));
            NUnit.Framework.Assert.AreEqual(78, Intervals.SumIntervals(new Interval[] { (-245, -218), (-194, -179), (-155, -119) }));
        }

        [TestMethod]
        public void ShouldAddAdjacentIntervals()
        {
            NUnit.Framework.Assert.AreEqual(54, Intervals.SumIntervals(new Interval[] { (1, 2), (2, 6), (6, 55) }));
            NUnit.Framework.Assert.AreEqual(23, Intervals.SumIntervals(new Interval[] { (-2, -1), (-1, 0), (0, 21) }));
        }

        [TestMethod]
        public void ShouldAddOverlappingIntervals()
        {
            NUnit.Framework.Assert.AreEqual(7, Intervals.SumIntervals(new Interval[] { (1, 4), (7, 10), (3, 5) }));
            NUnit.Framework.Assert.AreEqual(6, Intervals.SumIntervals(new Interval[] { (5, 8), (3, 6), (1, 2) }));
            NUnit.Framework.Assert.AreEqual(19, Intervals.SumIntervals(new Interval[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) }));
        }

        [TestMethod]
        public void ShouldHandleMixedIntervals()
        {
            NUnit.Framework.Assert.AreEqual(13, Intervals.SumIntervals(new Interval[] { (2, 5), (-1, 2), (-40, -35), (6, 8) }));
            NUnit.Framework.Assert.AreEqual(1234, Intervals.SumIntervals(new Interval[] { (-7, 8), (-2, 10), (5, 15), (2000, 3150), (-5400, -5338) }));
            NUnit.Framework.Assert.AreEqual(158, Intervals.SumIntervals(new Interval[] { (-101, 24), (-35, 27), (27, 53), (-105, 20), (-36, 26) }));
        }
    }
}
