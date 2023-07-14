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
        [Route("Warehouse/WarehousePage/{id}")]
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
        [HttpPost("Warehouse/RemoveWarehouse/{id}")]
        public IActionResult RemoveWarehouse([FromRoute] string id, [FromServices] IWarehouseHelper warehouseHelper)
        {
            int idWarehouse;
            if (!int.TryParse(id, out idWarehouse))
            {
                return BadRequest("Введен некорректный id");
            }
            warehouseHelper.Remove(idWarehouse);
            return Ok();
        }
        [HttpPost("Warehouse/AddWarehouse")]
        public IActionResult AddWarehouse([FromBody] Warehouse warehouse, [FromServices] IWarehouseHelper warehouseHelper)
        {
            Warehouse newwarehouse = warehouseHelper.Add(warehouse);
            return Json(newwarehouse);
        }
    }
}
