using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers
{
    public class FranchisesController:BaseApiController
    {
         private readonly IFranchiseRepository _repo;
        private readonly IMapper _mapper;
         private readonly IGenericRepository<Franchise> _franchisesRepo;
        private readonly IGenericRepository<Country> _franchiseCountryRepo;
        private readonly IGenericRepository<State> _franchiseStateRepo;
        private readonly IGenericRepository<PricingModel> _franchisePricingModelsRepo;
        

        public FranchisesController(IGenericRepository<Franchise> franchisesRepo, IGenericRepository<Country> franchiseCountryRepo,
         IGenericRepository<State> franchisesStateRepo, IGenericRepository<PricingModel> franchisePricingModelsRepo, IMapper mapper)
        {  
            _franchiseStateRepo = franchisesStateRepo;
            _franchiseCountryRepo = franchiseCountryRepo;
            _franchisePricingModelsRepo = franchisePricingModelsRepo;
            _franchisesRepo = franchisesRepo;
            _mapper=mapper;

        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<FranchiseToReturnDto>>> GetProducts([FromQuery]FranchiseSpecParams franchiseParams)
        {
          var spec = new FranchiseWithCountryStateAndPricingModelSpecification(franchiseParams);

            var countSpec = new FranchiseWithFiltersForCountSpecification(franchiseParams);

            var totalItems = await _franchisesRepo.CountAsync(countSpec);

            var franchises = await _franchisesRepo.ListAsync(spec);

            var data = _mapper
                .Map<IReadOnlyList<Franchise>, IReadOnlyList<FranchiseToReturnDto>>(franchises);

            return Ok(new Pagination<FranchiseToReturnDto>(franchiseParams.PageIndex, franchiseParams.PageSize, totalItems, data));

        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FranchiseToReturnDto>> GetProduct(int id)
        {
            var spec = new FranchiseWithCountryStateAndPricingModelSpecification(id);
            var franchise= await _franchisesRepo.GetEntityWithSpec(spec);
            if(franchise==null)
            {
                return NotFound(new ApiResponse(404));
            }
           return _mapper.Map<Franchise, FranchiseToReturnDto>(franchise);
            
        }

        [HttpGet("countries")]
        public async Task<ActionResult<IReadOnlyList<Country>>> GetFranchiseCountries()
        {
            return Ok(await _franchiseCountryRepo.ListAllAsync());
        }
        
        [HttpGet("states")]
        public async Task<ActionResult<IReadOnlyList<State>>> GetFranchiseStates()
        {
            return Ok(await _franchiseStateRepo.ListAllAsync());
        }

         [HttpGet("pricingmodels")]
        public async Task<ActionResult<IReadOnlyList<PricingModel>>> GetFranchisePricingModels()
        {
            return Ok(await _franchisePricingModelsRepo.ListAllAsync());
        }
        
    }
}