using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class ProductController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public ProductController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        [Route("Product/ProductPage")]
        public IActionResult ProductPage([FromServices] IProductHelper productHelper)
        {
            return View("ProductPage", productHelper.GetAll(0));
        }
        [HttpPost("Product/GetProducts")]
        public IActionResult GetProducts([FromServices] IProductHelper productHelper)
        {
            return Json(productHelper.GetAll(0));
        }
        [HttpPost("Product/AddProduct")]
        public IActionResult AddProduct([FromBody] Product product, [FromServices] IProductHelper productHelper)
        {
            Product newproduct = productHelper.Add(product);
            return Json(newproduct);
        }
        [HttpPost("Product/RemoveProduct/{id}")]
        public IActionResult RemoveProduct([FromRoute] string id, [FromServices] IProductHelper productHelper)
        {
            int idProduct;
            if (!int.TryParse(id, out idProduct))
            {
                return BadRequest("Введен некорректный id");
            }
            productHelper.Remove(idProduct);
            return Ok();
        }

    }
}
