using System;

namespace Core.Entities
{
    public class Franchise:BaseEntity
    {   
        public string Name { get; set; }

        public string Location { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public int PinCode { get; set; }

        public State State { get; set; }
        public int StateId { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public DateTime StartDate { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string LogoUrl { get; set; }

        public string GSTNumber { get; set; }

        public string PANNumber { get; set; }

        public int NumberOfChefs { get; set; }

        public int NumberOfCloudKitchens { get; set; }

        public bool IsActive { get; set; }

        public string BankName { get; set; }

        public string Branch { get; set; }

        public string AccountNumber { get; set; }

        public string IFSCCode { get; set; }

        public string Certificates { get; set; }

        public string FSSAINumber { get; set; }

        public PricingModel PricingModel { get; set; }
        public int PricingModelId { get; set; }
    }
        
    
}