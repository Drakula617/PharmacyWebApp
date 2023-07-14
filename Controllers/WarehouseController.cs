using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers
{
    //[NonController]
    //[Route("[controller]")]
    public class WarehouseController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public WarehouseController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        //[HttpPost("/WarehousePage/{id}")]
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
        //[HttpPost("/RemoveWarehouse/{id}")]
        public IActionResult RemoveWarehouse([FromRoute] string id, [FromServices] IPartyHelper partyHelper)
        {
            int idWarehouse;
            if (!int.TryParse(id, out idWarehouse))
            {
                return BadRequest("Введен некорректный id");
            }
            IWarehouseHelper warehouseHelper = new WarehouseHelper(_pharmacyDB, partyHelper);
            warehouseHelper.Remove(idWarehouse);
            return Ok();
        }
        //[HttpPost("/AddWarehouse")]
        public IActionResult AddWarehouse([FromBody] Warehouse warehouse, [FromServices] IPartyHelper partyHelper)
        {
            IWarehouseHelper warehouseHelper = new WarehouseHelper(_pharmacyDB, partyHelper);
            Warehouse newwarehouse = warehouseHelper.Add(warehouse);
            return Json(newwarehouse);
        }
    }
}
