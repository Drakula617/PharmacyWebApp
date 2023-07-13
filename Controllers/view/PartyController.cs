using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers.view
{
    [NonController]
    [Route("view/[controller]")]
    public class PartyController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public PartyController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        [HttpPost("/PartyPAge/{id}")]
        public IActionResult PartyPage([FromRoute] string id)
        {
            int idWarehouse;
            if (!int.TryParse(id, out idWarehouse))
            {
                return BadRequest("Введен некорректный id");
            }
            Warehouse warehouse = _pharmacyDB.Warehouses.Find(idWarehouse);
            if (warehouse == null)
            {
                return NotFound("Склад не найден");
            }
            return View("PartyPage", warehouse);
        }



    }
}
