using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PharmacyController : ControllerBase
    {
        readonly PharmacyDB _pharmacyDB;
        public PharmacyController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }

        [HttpPost("/RemovePharmacy/{id}")]
        public IActionResult RemovePharmacy([FromRoute] string id, [FromServices] IWarehouseHelper warehouseHelper) 
        {
            int idPharmacy;
            if(!int.TryParse(id, out idPharmacy)) 
            {
                return BadRequest("Введен некорректный id");
            }

            IPharmacyHelper pharmacyHelper = new PharmacyHelper(_pharmacyDB, warehouseHelper);
            pharmacyHelper.Remove(idPharmacy);
            return Ok();
        }
        [HttpPost("/AddPharmacy")]
        public IActionResult AddPharmacy([FromBody] Pharmacy pharmacy, [FromServices] IWarehouseHelper warehouseHelper)
        {
            IPharmacyHelper IpharmacyHelper = new PharmacyHelper(_pharmacyDB, warehouseHelper);
            Pharmacy newpharmacy = IpharmacyHelper.Add(pharmacy);
            return new JsonResult(newpharmacy);
        }

    }
}
