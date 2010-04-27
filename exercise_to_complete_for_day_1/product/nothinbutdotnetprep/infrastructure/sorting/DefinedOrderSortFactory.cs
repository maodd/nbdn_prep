using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
	public class DefinedOrderSortFactory<ItemToSearch, PropertyType> : IComparer<ItemToSearch>
	{
		Func<ItemToSearch, PropertyType> accessor;
		List<PropertyType> order;

		public DefinedOrderSortFactory(Func<ItemToSearch, PropertyType> accessor, PropertyType[] order)
		{
			this.accessor = accessor;
			this.order = new List<PropertyType>(order);
		}

		public int Compare(ItemToSearch x, ItemToSearch y)
		{
			PropertyType a = accessor(x);
			PropertyType b = accessor(y);

			int positiona = order.IndexOf(a);
			int positionb = order.IndexOf(b);

			return positiona.CompareTo(positionb);
		}
	}
}
