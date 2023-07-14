using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class PharmacyController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public PharmacyController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        [Route("")]
        [Route("Pharmacy/PharmacyPage")]
        public IActionResult PharmacyPage([FromServices] IPharmacyHelper pharmacyHelper)
        {
            return View("PharmacyPage", pharmacyHelper.GetAll(0));
        }

        //[HttpGet("/ProductsForPharmacyPage/{id}")]
        //public IActionResult ProductsForPharmacyPage([FromRoute] string id)
        //{
        //    int idPharmacy;
        //    if (!int.TryParse(id, out idPharmacy))
        //    {
        //        return BadRequest("Введен некорректный id");
        //    }
        //    Pharmacy pharmacy = _pharmacyDB.Pharmacies.Find(idPharmacy);
        //    if (pharmacy == null)
        //    {
        //        return NotFound("Аптека не найдена, поэтому не могу вывести её товары");
        //    }
        //    return View("ProductsForPharmacyPage", _pharmacyDB.Pharmacies.Find(idPharmacy));
        //}
        [HttpPost("Pharmacy/RemovePharmacy/{id}")]
        public IActionResult RemovePharmacy([FromRoute] string id, [FromServices] IPharmacyHelper pharmacyHelper)
        {
            int idPharmacy;
            if (!int.TryParse(id, out idPharmacy))
            {
                return BadRequest("Введен некорректный id");
            }

            pharmacyHelper.Remove(idPharmacy);
            return Ok();
        }
        [HttpPost("Pharmacy/AddPharmacy")]
        public IActionResult AddPharmacy([FromBody] Pharmacy pharmacy, [FromServices] IPharmacyHelper pharmacyHelper)
        {
            Pharmacy newpharmacy = pharmacyHelper.Add(pharmacy);
            return Json(newpharmacy);
        }

    }
}
