using Core.Entities;

namespace Core.Specifications
{
    public class FranchiseWithFiltersForCountSpecification: BaseSpecification<Franchise>
    {
         public FranchiseWithFiltersForCountSpecification(FranchiseSpecParams franchiseParams) 
            : base(x => 
                (string.IsNullOrEmpty(franchiseParams.Search) || x.Name.ToLower().Contains(franchiseParams.Search)) &&
                (!franchiseParams.CountryId.HasValue || x.CountryId == franchiseParams.CountryId) &&
                (!franchiseParams.StateId.HasValue || x.StateId == franchiseParams.StateId) &&
                (!franchiseParams.PricingModelId.HasValue || x.PricingModelId == franchiseParams.PricingModelId)
            )
        {
        }
        
    }
}