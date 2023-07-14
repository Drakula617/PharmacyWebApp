using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers
{
    //[NonController]
    //[Route("[controller]")]
    public class PartyController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public PartyController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        //[HttpPost("/PartyPAge/{id}")]
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
        //[HttpPost("/AddParty")]
        public IActionResult AddParty([FromBody] Party party)
        {
            IPartyHelper partyHelper = new PartyHelper(_pharmacyDB);
            Party newparty = partyHelper.Add(party);
            return Json(newparty);
        }
        //[HttpPost("/RemoveParty/{id}")]
        public IActionResult RemoveParty([FromRoute] string id)
        {
            int idParty;
            if (!int.TryParse(id, out idParty))
            {
                return BadRequest("Введен некорректный id");
            }
            IPartyHelper partyHelper = new PartyHelper(_pharmacyDB);
            partyHelper.Remove(idParty);
            return Ok();
        }

    }
}
