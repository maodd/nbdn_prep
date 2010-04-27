using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public static class CriteriaExtensions
    {
        public static Criteria<T> or<T>(this Criteria<T> left_side, Criteria<T> right_side)
        {
            return new OrCriteria<T>(left_side, right_side);
        }

        public static Criteria<T> negate<T>(this Criteria<T> to_negate)
        {
            return new NegatingCriteria<T>(to_negate);
        }

        public static CriteriaFactory<ItemToSearch,PropertyType> negate<ItemToSearch,PropertyType>(this BasicCriteriaFactory<ItemToSearch,PropertyType> factory)
        {
            return new NegatingCriteriaFactory<ItemToSearch, PropertyType>(factory);
        }
        public static Criteria<T> and<T>(this Criteria<T> left_side, Criteria<T> right_side)
        {
            return new AndCriteria<T>(left_side, right_side);
        }


    }
}