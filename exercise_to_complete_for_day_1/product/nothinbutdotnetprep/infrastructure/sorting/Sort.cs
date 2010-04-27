using System;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Sort<ItemToSort>
    {
        public static ComparerBuilder<ItemToSort> by<PropertyToSortOn>(Func<ItemToSort, PropertyToSortOn> accessor,
            params PropertyToSortOn[] values) 
        {
            return new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyToSortOn>(
                                                       new FixedComparer<PropertyToSortOn>(values), accessor));
        }
        public static ComparerBuilder<ItemToSort> by<PropertyToSortOn>(Func<ItemToSort, PropertyToSortOn> accessor) where PropertyToSortOn : IComparable<PropertyToSortOn>
        {
            return new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyToSortOn>(
                new ComparableComparer<PropertyToSortOn>(),accessor));
        }

        public static ComparerBuilder<ItemToSort> by_descending<PropertyToSortOn>(Func<ItemToSort, PropertyToSortOn> accessor) where PropertyToSortOn : IComparable<PropertyToSortOn>
        {
        	return new ComparerBuilder<ItemToSort>(new ReverseComparer<ItemToSort>(
        	                                       	new PropertyComparer<ItemToSort, PropertyToSortOn>(
        	                                       		new ComparableComparer<PropertyToSortOn>(), accessor)));
        }
    }
}