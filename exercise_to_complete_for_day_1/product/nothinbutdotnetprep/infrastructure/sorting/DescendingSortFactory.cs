using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
	public class DescendingSortFactory<ItemToSearch, PropertyType> : IComparer<ItemToSearch> where PropertyType : IComparable<PropertyType>
	{
		Func<ItemToSearch, PropertyType> accessor;

		public DescendingSortFactory(Func<ItemToSearch, PropertyType> accessor)
		{
			this.accessor = accessor;
		}

		public int Compare(ItemToSearch x, ItemToSearch y)
		{
			return accessor(y).CompareTo(accessor(x));
		}
	}
}
