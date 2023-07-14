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
            IPartyHelper partyHelper = new PartyHelper(_pharmacyDB);
            Party newparty = partyHelper.Add(party);
            return new JsonResult(newparty);
        }
        [HttpPost("/RemoveParty/{id}")]
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
