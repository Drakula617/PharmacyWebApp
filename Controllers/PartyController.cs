﻿using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class PartyController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public PartyController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        [Route("Party/PartyPage/{id}")]
        public IActionResult PartyPage([FromRoute] string id)
        {
            int idWarehouse;
            if (!int.TryParse(id, out idWarehouse))
            {
                return BadRequest("Введен некорректный id");
            }
            Warehouse warehouse = _pharmacyDB.Warehouses.Find(idWarehouse);
            var parties = warehouse.Parties;
            if (warehouse == null)
            {
                return NotFound("Склад не найден");
            }
            return View("PartyPage", warehouse);
        }
        [HttpPost("Party/AddParty")]
        public IActionResult AddParty([FromBody] Party party, [FromServices] IPartyHelper partyHelper)
        {
            Party newparty = partyHelper.Add(party);
            return Json(newparty);
        }

        [HttpPost("Party/RemoveParty/{id}")]
        public IActionResult RemoveParty([FromRoute] string id, [FromServices] IPartyHelper partyHelper)
        {
            int idParty;
            if (!int.TryParse(id, out idParty))
            {
                return BadRequest("Введен некорректный id");
            }
            partyHelper.Remove(idParty);
            return Ok();
        }

    }
}
