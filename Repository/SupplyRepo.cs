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
        List<string> pharmacyNames = new List<string>() {"Appolo Pharmacy","Gupta Pharmacies","G.K Pharmacies" };
        List<PharmacyDTO> pharmacies = new List<PharmacyDTO>();
        public List<PharmacyDTO> GetPharmacies()
        {
           foreach(var i in pharmacyNames)
            {
                pharmacies.Add(new PharmacyDTO { pharmacyName = i });
            }
            return pharmacies;
        }
    }
    
}
