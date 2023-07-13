using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartyController : ControllerBase
    {
        readonly PharmacyDB _pharmacyDB;
        public PartyController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }

        [HttpPost("/AddParty")]
        public IActionResult AddParty([FromBody] Party party)
        {
            IPartyHelper partyHelper = new PartyHelper(_pharmacyDB, party);
            partyHelper.Add(out party);
            return new JsonResult(party);
        }
        [HttpPost("/RemoveParty/{id}")]
        public IActionResult RemoveParty([FromRoute] string id)
        {
            int idParty;
            if (!int.TryParse(id, out idParty))
            {
                return BadRequest("Введен некорректный id");
            }
            Party party = _pharmacyDB.Parties.Find(idParty);
            if (party == null)
            {
                return NotFound("Партия не найдена, поэтому не могу её удалить");
            }
            IPartyHelper partyHelper = new PartyHelper(_pharmacyDB, party);
            partyHelper.Remove();
            return Ok();
        }

    }
}
