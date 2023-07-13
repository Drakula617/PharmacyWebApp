using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers.view
{
    [NonController]
    [Route("view/[controller]")]
    public class WarehouseController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public WarehouseController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        [HttpPost("/WarehousePage/{id}")]
        public IActionResult WarehousePage([FromRoute] string id)
        {
            int idPharmacy;
            if (!int.TryParse(id, out idPharmacy))
            {
                return BadRequest("Введен некорректный id");
            }
            Pharmacy pharmacy = _pharmacyDB.Pharmacies.Find(idPharmacy);
            if (pharmacy == null)
            {
                return NotFound("Аптека не найдена");
            }
            return View("WarehousePage", pharmacy);
        }

    }
}
