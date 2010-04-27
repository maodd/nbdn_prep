namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface CriteriaFactory<ItemToSearch, PropertyType>
    {
        Criteria<ItemToSearch> equal_to(PropertyType value);
        Criteria<ItemToSearch> equal_to_any(params PropertyType[] values);
    }

    public class NegatingCriteriaFactory<ItemToSearch, PropertyType> : CriteriaFactory<ItemToSearch, PropertyType>
    {
        CriteriaFactory<ItemToSearch, PropertyType> original_factory;

        public NegatingCriteriaFactory(CriteriaFactory<ItemToSearch, PropertyType> original_factory)
        {
            this.original_factory = original_factory;
        }

        public Criteria<ItemToSearch> equal_to(PropertyType value)
        {
            return original_factory.equal_to(value).negate();
        }

        public Criteria<ItemToSearch> equal_to_any(params PropertyType[] values)
        {
            return original_factory.equal_to_any(values).negate();
        }
    }
}