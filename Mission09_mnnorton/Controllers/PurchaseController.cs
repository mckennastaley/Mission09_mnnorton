using Microsoft.AspNetCore.Mvc;
using Mission09_mnnorton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_mnnorton.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }
    }
}
