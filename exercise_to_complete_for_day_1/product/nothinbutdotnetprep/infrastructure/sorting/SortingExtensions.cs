using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
	public static class SortingExtensions
	{
		public static IEnumerable<T> sorted_using<T>(this IEnumerable<T> items, IComparer<T> comparer)
		{
			List<T> list = new List<T>(items);
			list.Sort(comparer);
			return list;
		}

		public static IComparer<ItemToSearch> then_by<ItemToSearch, PropertyType>(this IComparer<ItemToSearch> items, Func<ItemToSearch, PropertyType> accessor)
			where PropertyType : IComparable<PropertyType>
		{
			return new AscendingSortFactory<ItemToSearch, PropertyType>(accessor);
		}
	}
}
