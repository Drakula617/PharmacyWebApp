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
        public IActionResult RemovePharmacy([FromRoute] string id) 
        {
            int idPharmacy;
            if(!int.TryParse(id, out idPharmacy)) 
            {
                return BadRequest("Введен некорректный id");
            }
            Pharmacy pharmacy = _pharmacyDB.Pharmacies.Find(idPharmacy);
            if (pharmacy == null)
            {
                return NotFound("Аптека не найдена и не может быть удалена");
            }
            IPharmacyHelper pharmacyHelper = new PharmacyHelper(_pharmacyDB, _pharmacyDB.Pharmacies.Find(idPharmacy));
            pharmacyHelper.Remove();
            return Ok();
        }
        [HttpPost("/AddPharmacy")]
        public IActionResult AddPharmacy([FromBody] Pharmacy pharmacy)
        {
            //pharmacy = new PharmacyHelper(_pharmacyDB);
            IPharmacyHelper IpharmacyHelper = new PharmacyHelper(_pharmacyDB, pharmacy);
            IpharmacyHelper.Add(out Pharmacy newpharmacy);
            return new JsonResult(newpharmacy);
        }

    }
}
