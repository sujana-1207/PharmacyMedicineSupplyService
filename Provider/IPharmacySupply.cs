using PharmacyMedicineSupplyService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyService.Provider
{
    public interface IPharmacySupply
    {
        public Task<List<PharmacyMedicineSupply>> GetSupply(List<MedicineDemand> medicines);
        public Task<int> GetStock(string medicine);
    }
}
