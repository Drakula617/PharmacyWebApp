using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers.api
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
        [HttpPost("/AddWarehouse")]
        public IActionResult AddWarehouse([FromBody] Warehouse warehouse, [FromServices] IPartyHelper partyHelper) 
        {
            IWarehouseHelper warehouseHelper = new WarehouseHelper(_pharmacyDB, partyHelper);
            Warehouse newwarehouse = warehouseHelper.Add(warehouse);
            return new JsonResult(newwarehouse);
        }
    }
}
