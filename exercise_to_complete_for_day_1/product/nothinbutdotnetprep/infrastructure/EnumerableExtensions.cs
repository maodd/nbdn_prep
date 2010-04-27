using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure
{

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        public static IEnumerable<T> all_matching<T>(this IEnumerable<T> items,
                                                     Criteria<T> criteria)
        {
            return all_matching(items, criteria.is_satisfied_by);
        }

        static IEnumerable<T> all_matching<T>(this IEnumerable<T> items,
                                                     Predicate<T> criteria)
        {
            foreach (var item in items)
            {
                if (criteria(item)) yield return item;
            }
        }

        public static IEnumerable<T> sorted_using<T>(this IEnumerable<T> items,
                                                     IComparer<T> comparer)
        {
            var sorted = new List<T> (items);
            sorted.Sort(comparer);
            return sorted;
        }
    }
}