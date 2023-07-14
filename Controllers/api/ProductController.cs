using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        readonly PharmacyDB _pharmacyDB;
        public ProductController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }

        [HttpPost("/GetProducts")]
        public IActionResult GetProducts()
        {
            return new JsonResult(_pharmacyDB.Products.ToList());
        }
        [HttpPost("/AddProduct")]
        public IActionResult AddProduct([FromBody] Product product, [FromServices] IPartyHelper partyHelper)
        {
            IProductHelper productHelper = new ProductHelper(_pharmacyDB, partyHelper);
            Product newproduct = productHelper.Add(product);
            return new JsonResult(newproduct);
        }
        [HttpPost("/RemoveProduct/{id}")]
        public IActionResult RemoveProduct([FromRoute] string id, [FromServices] IPartyHelper partyHelper)
        {
            int idProduct;
            if (!int.TryParse(id, out idProduct))
            {
                return BadRequest("Введен некорректный id");
            }
            IProductHelper productHelper =  new ProductHelper(_pharmacyDB, partyHelper);
            productHelper.Remove(idProduct);
            return Ok();
        }
        
    }
}
