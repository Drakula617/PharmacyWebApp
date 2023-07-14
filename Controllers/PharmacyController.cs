using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers
{

    //[Route("[controller]")]
    public class PharmacyController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public PharmacyController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        //[HttpGet("PharmacyPage")]
        public IActionResult PharmacyPage()
        {
            var pharm = _pharmacyDB.Pharmacies.ToList();
            return View("PharmacyPage", _pharmacyDB.Pharmacies.ToList());
        }

        //[HttpGet("/ProductsForPharmacyPage/{id}")]
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
        //[HttpPost("/RemovePharmacy/{id}")]
        public IActionResult RemovePharmacy([FromRoute] string id, [FromServices] IWarehouseHelper warehouseHelper)
        {
            int idPharmacy;
            if (!int.TryParse(id, out idPharmacy))
            {
                return BadRequest("Введен некорректный id");
            }

            IPharmacyHelper pharmacyHelper = new PharmacyHelper(_pharmacyDB, warehouseHelper);
            pharmacyHelper.Remove(idPharmacy);
            return Ok();
        }
        //[HttpPost("/AddPharmacy")]
        public IActionResult AddPharmacy([FromBody] Pharmacy pharmacy, [FromServices] IWarehouseHelper warehouseHelper)
        {
            IPharmacyHelper IpharmacyHelper = new PharmacyHelper(_pharmacyDB, warehouseHelper);
            Pharmacy newpharmacy = IpharmacyHelper.Add(pharmacy);
            return Json(newpharmacy);
        }

    }
}
