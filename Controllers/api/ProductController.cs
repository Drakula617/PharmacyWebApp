using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers
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
        public IActionResult AddProduct([FromBody] Product product)
        {
            IProductHelper productHelper = new ProductHelper(_pharmacyDB, product);
            productHelper.Add(out product);
            return new JsonResult(product);
        }
        [HttpPost("/RemoveProduct/{id}")]
        public IActionResult RemoveProduct([FromRoute] string id)
        {
            int idProduct;
            if (!int.TryParse(id, out idProduct))
            {
                return BadRequest("Введен некорректный id");
            }
            Product product = _pharmacyDB.Products.Find(idProduct);
            if (product == null)
            {
                return NotFound("Товар не найден");
            }
            IProductHelper productHelper =  new ProductHelper(_pharmacyDB, product);
            productHelper.Remove();
            return Ok();
        }
        
    }
}
