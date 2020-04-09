using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
   public class FranchiseRepository : IFranchiseRepository
    {
        private readonly eAppContext _context;
        public FranchiseRepository(eAppContext context)
        {
            _context = context;
        }
        public async Task<Franchise> GetFranchiseByIdAsync(int id)
        {
           return await _context.Franchises
                .Include(p => p.Country)
                .Include(p => p.State)
                .Include(p => p.PricingModel)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Franchise>> GetFranchisesAsync()
        {
           return await _context.Franchises
                .Include(p => p.Country)
                .Include(p => p.State)
                .Include(p => p.PricingModel)
                .ToListAsync();
        }
        public async Task<IReadOnlyList<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }
        public async Task<IReadOnlyList<State>> GetStatesAsync()
        {
            return await _context.States.ToListAsync();
        }
         public async Task<IReadOnlyList<PricingModel>> GetPricingModelsAsync()
        {
            return await _context.PricingModels.ToListAsync();
        }

    }
}