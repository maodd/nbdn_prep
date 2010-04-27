using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToSearch>
    {
        public static Func<ItemToSearch,PropertyType> has_a<PropertyType>(Func<ItemToSearch,PropertyType> accessor)
        {
            return accessor;
        }

    }
}