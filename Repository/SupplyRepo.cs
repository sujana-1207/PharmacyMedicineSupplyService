using PharmacyMedicineSupplyService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace PharmacyMedicineSupplyService.Repository
{
    public class SupplyRepo : ISupply
    {
        List<string> pharmacies = new List<string>() {"Appolo Pharmacy","Gupta Pharmacies","G.K Pharmacies" };
        List<PharmacyMedicineSupply> pharmacySupply = new List<PharmacyMedicineSupply>();

        public List<string> GetPharmacies()
        {
            return pharmacies;
        }
    }
    
}
