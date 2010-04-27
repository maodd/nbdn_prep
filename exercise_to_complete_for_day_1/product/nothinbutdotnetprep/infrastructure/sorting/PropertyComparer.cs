
using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class PropertyComparer<ItemToSort,PropertyToSortOn> : IComparer<ItemToSort>
    {
        IComparer<PropertyToSortOn> actual_comparer;
        Func<ItemToSort,PropertyToSortOn> accessor;

        public PropertyComparer(IComparer<PropertyToSortOn> actual_comparer, Func<ItemToSort, PropertyToSortOn> accessor)
        {
            this.actual_comparer = actual_comparer;
            this.accessor = accessor;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return actual_comparer.Compare(accessor(x), accessor(y));
        }
    }
}