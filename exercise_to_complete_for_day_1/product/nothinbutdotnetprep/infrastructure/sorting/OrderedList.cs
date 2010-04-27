using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
	public class OrderedList<ItemToSort> : IEnumerable<ItemToSort>
	{
		IEnumerable<ItemToSort> items;
		ComparerBuilder<ItemToSort> comparer;

		public OrderedList(IEnumerable<ItemToSort> items, ComparerBuilder<ItemToSort> comparer)
		{
			this.items = items;
			this.comparer = comparer;
		}

		public IEnumerator<ItemToSort> GetEnumerator()
		{
			List<ItemToSort> sorted = new List<ItemToSort>(items);
			sorted.Sort(comparer);
			return sorted.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
