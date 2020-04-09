using System;

namespace API.Dtos
{
    public class FranchiseToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public int PinCode { get; set; }

        public string State { get; set; }
        public string Country { get; set; }
        public DateTime StartDate { get; set; }

        public Int64 Contact { get; set; }

        public string Email { get; set; }

        public string LogoUrl { get; set; }

        public string GSTNumber { get; set; }

        public string PANNumber { get; set; }

        public int NumberOfChefs { get; set; }

        public int NumberOfCloudKitchens { get; set; }

        public bool Status { get; set; }
        public string BankName { get; set; }

        public string Branch { get; set; }

        public string AccountNumber { get; set; }

        public string IFSCCode { get; set; }

        public string Certificates { get; set; }

        public string FSSAINumber { get; set; }

        public string PricingModel { get; set; }
        
    }
}