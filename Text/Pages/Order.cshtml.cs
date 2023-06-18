using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Text.Pages
{
    public class OrderModel : PageModel
    {
        private readonly ILogger<OrderModel> _logger;
        private readonly Database1Context _context;

        [BindProperty]
        public string ClientName { get; set; }

        public List<Orders> Orders { get; set; }

        // Constructor to inject the logger and the database context
        public OrderModel(ILogger<OrderModel> logger, Database1Context dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public void OnGet()
        {
            Orders = _context.Orders.ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Access the submitted form data
            string clientName = Request.Form["ClientName"];
            string quantity = Request.Form["Quantity"];
            bool cookie1Checked = Request.Form["Cookie1"] == "cookie1";
            bool cookie2Checked = Request.Form["Cookie2"] == "cookie2";
            bool cookie3Checked = Request.Form["Cookie3"] == "cookie3";

            // Calculate total price and prepare order details
            var totalPrice = 0;
            var orderSummary = "";

            if (cookie1Checked)
            {
                var butterCookiePrice = 5;
                var butterCookieQty = int.Parse(quantity);
                orderSummary += "Butter cookie (" + butterCookieQty + " units) - RM " + butterCookiePrice + " per unit\n";
                totalPrice += butterCookiePrice * butterCookieQty;

                // Insert the order detail into the database
                var butterCookieOrder = new Orders
                {
                    ClientName = clientName,
                    CookieName = "Butter Cookie",
                    UnitPrice = butterCookiePrice,
                    Quantity = butterCookieQty,
                    OrderDate = DateTime.Now
                };

                _context.Orders.Add(butterCookieOrder);
            }

            if (cookie2Checked)
            {
                var kuihBangkitPrice = 6;
                var kuihBangkitQty = int.Parse(quantity);
                orderSummary += "Kuih Bangkit (" + kuihBangkitQty + " units) - RM " + kuihBangkitPrice + " per unit\n";
                totalPrice += kuihBangkitPrice * kuihBangkitQty;

                // Insert the order detail into the database
                var kuihBangkitOrder = new Orders
                {
                    ClientName = clientName,
                    CookieName = "Kuih Bangkit",
                    UnitPrice = kuihBangkitPrice,
                    Quantity = kuihBangkitQty,
                    OrderDate = DateTime.Now
                };

                _context.Orders.Add(kuihBangkitOrder);
            }

            if (cookie3Checked)
            {
                var pineapplePrice = 7;
                var pineappleQty = int.Parse(quantity);
                orderSummary += "Pineapple (" + pineappleQty + " units) - RM " + pineapplePrice + " per unit\n";
                totalPrice += pineapplePrice * pineappleQty;

                // Insert the order detail into the database
                var pineappleOrder = new Orders
                {
                    ClientName = clientName,
                    CookieName = "Pineapple",
                    UnitPrice = pineapplePrice,
                    Quantity = pineappleQty,
                    OrderDate = DateTime.Now
                };

                _context.Orders.Add(pineappleOrder);
            }

            await _context.SaveChangesAsync();

            // Store the order summary in TempData to display it on the page
            TempData["OrderSummary"] = orderSummary + "\nTotal Price: RM " + totalPrice;

            return RedirectToPage();
        }
    }
}
