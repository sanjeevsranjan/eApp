using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
     public class FranchiseUrlResolver : IValueResolver<Franchise, FranchiseToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public FranchiseUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Franchise source, FranchiseToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.LogoUrl))
            {
                return _config["ApiUrl"] + source.LogoUrl;
            }

            return null;
        }
    }
}