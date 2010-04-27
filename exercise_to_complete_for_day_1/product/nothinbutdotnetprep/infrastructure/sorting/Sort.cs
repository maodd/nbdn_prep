using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
	public class Sort<ItemToSearch>
	{
		public static IComparer<ItemToSearch> by<PropertyType>(Func<ItemToSearch, PropertyType> accessor)
			where PropertyType : IComparable<PropertyType>
		{
			return new AscendingSortFactory<ItemToSearch, PropertyType>(accessor);
		}

		public static IComparer<ItemToSearch> by<PropertyType>(Func<ItemToSearch, PropertyType> accessor, params PropertyType[] order)
		{
			return new DefinedOrderSortFactory<ItemToSearch, PropertyType>(accessor, order);
		}

		public static IComparer<ItemToSearch> by_descending<PropertyType>(Func<ItemToSearch, PropertyType> accessor)
			where PropertyType : IComparable<PropertyType>
		{
			return new DescendingSortFactory<ItemToSearch, PropertyType>(accessor);
		}
	}
}
