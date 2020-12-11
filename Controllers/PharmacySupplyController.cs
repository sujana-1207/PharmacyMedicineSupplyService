using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyMedicineSupplyService.Models;
using PharmacyMedicineSupplyService.Provider;
using PharmacyMedicineSupplyService.Repository;

namespace PharmacyMedicineSupplyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacySupplyController : ControllerBase
    {
        IPharmacySupply _provider;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PharmacySupplyController));
        public PharmacySupplyController(IPharmacySupply provider)
        {
            _provider = provider;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromBody]List<MedicineDemand> m)
        {
            try
            {
                var res = await _provider.GetSupply(m);
                if(res!=null)
                {
                    _log4net.Info("Pharmacy supply details successfully retrieved and sent.");
                    return new OkObjectResult(res);
                }
                _log4net.Info("No details retrieved");
                return Content("No such details found please try again.");
            }
            catch(Exception e)
            {
                _log4net.Error("Excpetion:" + e.Message + " has occurred while trying to retrieve supply info.");
                return Content("The following exception has occurred while processing your request."+e.Message+" Please try again");
            }

            
        }
    }
}