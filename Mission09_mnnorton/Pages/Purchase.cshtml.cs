using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_mnnorton.Infrastructure;
using Mission09_mnnorton.Models;

namespace Mission09_mnnorton.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public PurchaseModel(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }

        public void OnGet()
        {
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int BookId)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == BookId);

            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

            basket.AddItem(b, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage();
        }
    }
}
