using System;
using System.Collections.Generic;
using System.Linq;

namespace Redis.Infra.CrossCutting.Validation
{
    public static class EnumerableConcern
    {
        public static void AssertIsNotEmpty<T>(IEnumerable<T> items, string message)
        {
            if (items == null || !items.Any())
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertMinimumLength<T>(IEnumerable<T> items, int min, string message)
        {
            AssertIsNotEmpty(items, message);
            if (items.Count() < min)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertMaximumLength<T>(IEnumerable<T> items, int max, string message)
        {
            AssertIsNotEmpty(items, message);
            if (items.Count() > max)
            {
                throw new InvalidOperationException(message);
            }
        }

        public static void AssertInRange<T>(IEnumerable<T> items, int min, int max, string message)
        {
            AssertIsNotEmpty(items, message);
            AssertMinimumLength(items, min, message);
            AssertMaximumLength(items, max, message);
        }
    }
}
