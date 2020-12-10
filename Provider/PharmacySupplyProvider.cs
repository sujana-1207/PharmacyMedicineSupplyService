using Newtonsoft.Json;
using PharmacyMedicineSupplyService.Models;
using PharmacyMedicineSupplyService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyService.Provider
{
    public class PharmacySupplyProvider: IPharmacySupply
    {
        ISupply supplyRepo;
        List<string> pharmacies;
        List<PharmacyMedicineSupply> pharmacySupply=new List<PharmacyMedicineSupply>();
        public PharmacySupplyProvider(ISupply repo)
        {
            supplyRepo = repo;
        }
        public async Task<List<PharmacyMedicineSupply>> GetSupply(List<MedicineDemand> medicines)
        {
            pharmacies = supplyRepo.GetPharmacies();
            foreach (var m in medicines)
            {
                int stockCount = await GetStock(m.Medicine);
                if (stockCount != -1)
                {
                    if (stockCount < m.DemandCount)
                        m.DemandCount = stockCount;
                    int indSupply = (m.DemandCount) / pharmacies.Count;
                    foreach (var i in pharmacies)
                    {
                        pharmacySupply.Add(new PharmacyMedicineSupply { MedicineName = m.Medicine, PharmacyName = i, SupplyCount = indSupply });
                    }
                    if (m.DemandCount > indSupply * pharmacies.Count)
                    {
                        pharmacySupply[pharmacySupply.Count - 1].SupplyCount += (m.DemandCount - indSupply * pharmacies.Count);
                    }
                }
                else
                {
                    return null;
                }
                return pharmacySupply;
            }
            
        }
        public async Task<int> GetStock(string medicineName)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44394");
            var response = await client.GetAsync("/MedicineStockInformation");
            if (!response.IsSuccessStatusCode)
            {
                return -1;
            }
            string stringStock = await response.Content.ReadAsStringAsync();
            var medicines = JsonConvert.DeserializeObject<List<MedicineStock>>(stringStock);
            var i = medicines.Where(x => x.Name == medicineName).FirstOrDefault();
            return i.Number_Of_Tablets_In_Stock;
        }
    }
}
