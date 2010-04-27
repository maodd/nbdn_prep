using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        IComparer<ItemToSort> final_comparer;

        public ComparerBuilder(IComparer<ItemToSort> initial_comparer)
        {
            this.final_comparer = initial_comparer;
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyToSortOn>(Func<ItemToSort, PropertyToSortOn> accessor)
            where PropertyToSortOn : IComparable<PropertyToSortOn>
        {
            final_comparer = new ChainedComparer<ItemToSort>(final_comparer,
                                                             new PropertyComparer<ItemToSort, PropertyToSortOn>(
                                                                 new ComparableComparer<PropertyToSortOn>(), accessor));

            return this;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return final_comparer.Compare(x, y);
        }
    }
}