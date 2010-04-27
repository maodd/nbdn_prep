using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
	public class AscendingSortFactory<ItemToSearch, PropertyType> : IComparer<ItemToSearch> where PropertyType : IComparable<PropertyType>
	{
		Func<ItemToSearch, PropertyType> accessor;

		public AscendingSortFactory(Func<ItemToSearch, PropertyType> accessor)
		{
			this.accessor = accessor;
		}

		public int Compare(ItemToSearch x, ItemToSearch y)
		{
			return accessor(x).CompareTo(accessor(y));
		}
	}
}
