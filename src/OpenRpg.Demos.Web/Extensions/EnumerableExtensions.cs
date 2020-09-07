using System;
using System.Collections.Generic;
using System.Linq;
using OpenRpg.Core.Utils;

namespace OpenRpg.Demos.Web.Extensions
{
    public static class EnumerableExtensions
    {
        public static T TakeRandomFromEx<T>(this IRandomizer randomizer, IEnumerable<T> source)
        {
            int num = source.Count<T>();
            if (num == 0)
                throw new Exception("Unable to pick random number from empty list");

            var count1 = randomizer.Random(0, num);
            return source.Skip<T>(count1).First<T>();
        }
    }
}