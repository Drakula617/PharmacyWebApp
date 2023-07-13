using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        readonly PharmacyDB _pharmacyDB;
        public WarehouseController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }

        [HttpPost("/RemoveWarehouse/{id}")]
        public IActionResult RemoveWarehouse([FromRoute] string id)
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
            IWarehouseHelper warehouseHelper = new WarehouseHelper(_pharmacyDB, warehouse);
            warehouseHelper.Remove();
            return Ok();
        }
        [HttpPost("/AddWarehouse")]
        public IActionResult AddWarehouse([FromBody] Warehouse warehouse) 
        {
            IWarehouseHelper warehouseHelper = new WarehouseHelper(_pharmacyDB, warehouse);
            warehouseHelper.Add(out warehouse);
            return new JsonResult(warehouse);
        }
    }
}
