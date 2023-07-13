using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers.ViewCotrollers
{
    [NonController]
    [Route("view/[controller]")]
    public class PharmacyController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public PharmacyController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        [HttpGet("PharmacyPage")]
        public IActionResult PharmacyPage()
        {
            return View("PharmacyPage", _pharmacyDB.Pharmacies.ToList());
        }


        [HttpGet("/ProductsForPharmacyPage/{id}")]
        public IActionResult ProductsForPharmacyPage([FromRoute] string id)
        {
            int idPharmacy;
            if (!int.TryParse(id, out idPharmacy))
            {
                return BadRequest("Введен некорректный id");
            }
            Pharmacy pharmacy = _pharmacyDB.Pharmacies.Find(idPharmacy);
            if (pharmacy == null)
            {
                return NotFound("Аптека не найдена, поэтому не могу вывести её товары");
            }
            return View("ProductsForPharmacyPage", _pharmacyDB.Pharmacies.Find(idPharmacy));
        }

    }
}
