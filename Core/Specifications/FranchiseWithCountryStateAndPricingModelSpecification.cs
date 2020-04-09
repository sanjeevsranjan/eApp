using Core.Entities;

namespace Core.Specifications
{
    public class FranchiseWithCountryStateAndPricingModelSpecification: BaseSpecification<Franchise>
    {
         public FranchiseWithCountryStateAndPricingModelSpecification(FranchiseSpecParams franchiseParams) 
        : base(x => 
                (string.IsNullOrEmpty(franchiseParams.Search) || x.Name.ToLower().Contains(franchiseParams.Search)) &&
                (!franchiseParams.CountryId.HasValue || x.CountryId == franchiseParams.CountryId) &&
                (!franchiseParams.StateId.HasValue || x.StateId == franchiseParams.StateId) &&
                (!franchiseParams.PricingModelId.HasValue || x.PricingModelId == franchiseParams.PricingModelId)
            )
        {
            AddInclude(x => x.Country);
            AddInclude(x => x.State);
            AddInclude(x => x.PricingModel);
            AddOrderBy(x=>x.Name);
             if (!string.IsNullOrEmpty(franchiseParams.Sort))
            {
                switch (franchiseParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(p => p.Name);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }
        public FranchiseWithCountryStateAndPricingModelSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Country);
            AddInclude(x => x.State);
            AddInclude(x => x.PricingModel);
        }
        
    }
}