using Microsoft.AspNetCore.Mvc;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models;
using PharmacyWebApp.Models.HelperClasses;
using PharmacyWebApp.Models.Tables;

namespace PharmacyWebApp.Controllers.ViewCotrollers
{
    [NonController]
    [Route("view/[controller]")]
    public class ProductController : Controller
    {
        readonly PharmacyDB _pharmacyDB;
        public ProductController(PharmacyDB pharmacyDB)
        {
            _pharmacyDB = pharmacyDB;
        }
        [HttpPost("/ProductPage")]
        public IActionResult ProductPage()
        {
            return View("ProductPage", _pharmacyDB.Products.ToList());
        }



    }
}
