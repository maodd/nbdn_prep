using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
	public class OrderedEnumerable<ItemToSort> : IEnumerable<ItemToSort>
	{
		IEnumerable<ItemToSort> items;
		ComparerBuilder<ItemToSort> comparer;

		public OrderedEnumerable(IEnumerable<ItemToSort> items, ComparerBuilder<ItemToSort> comparer)
		{
			this.items = items;
			this.comparer = comparer;
		}

	    public OrderedEnumerable<ItemToSort> then_by<Property>(Func<ItemToSort, Property> accessor) where Property : IComparable<Property>
	    {
	        comparer.then_by(accessor);
	        return this;
	    }

		public IEnumerator<ItemToSort> GetEnumerator()
		{
			var sorted = new List<ItemToSort>(items);
			sorted.Sort(comparer);
			return sorted.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
