using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IFranchiseRepository
    {
        Task<Franchise> GetFranchiseByIdAsync(int id);
        Task<IReadOnlyList<Franchise>> GetFranchisesAsync();
        Task<IReadOnlyList<Country>> GetCountriesAsync();
        Task<IReadOnlyList<State>> GetStatesAsync();
        Task<IReadOnlyList<PricingModel>> GetPricingModelsAsync();
         
    }
}