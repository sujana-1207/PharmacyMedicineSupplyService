using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyMedicineSupplyService.Models
{
    public class MedicineStock
    {

        public string Name { get; set; }
        public List<string> Chemical_Composition { get; set; }
        public string Target_Ailment { get; set; }
        public DateTime Date_Of_Expiry { get; set; }
        public int Number_Of_Tablets_In_Stock { get; set; }
    }
}
