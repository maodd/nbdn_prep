﻿using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class BasicCriteriaFactory<ItemToSearch, PropertyType> : CriteriaFactory<ItemToSearch, PropertyType>
    {
        Func<ItemToSearch, PropertyType> accessor;

        public BasicCriteriaFactory(Func<ItemToSearch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public CriteriaFactory<ItemToSearch, PropertyType> not
        {
            get { return this.negate(); }
        }

        public Criteria<ItemToSearch> equal_to(PropertyType value)
        {
            return new PropertyCriteria<ItemToSearch, PropertyType>(
                accessor, new EqualToCriteria<PropertyType>(value));
        }

        public Criteria<ItemToSearch> equal_to_any(params PropertyType[] values)
        {
            return new PropertyCriteria<ItemToSearch, PropertyType>(accessor,
                                                                    new EqualToAnyCriteria<PropertyType>(values));
        }
    }
}