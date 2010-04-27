using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparableComparer<PropertyToSortOn> : IComparer<PropertyToSortOn> where PropertyToSortOn : IComparable<PropertyToSortOn>
    {
        public int Compare(PropertyToSortOn x, PropertyToSortOn y)
        {
            return x.CompareTo(y);
        }
    }
}