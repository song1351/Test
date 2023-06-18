using Microsoft.AspNetCore.Mvc.RazorPages;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;



namespace Text.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Database1Context _context;

        public IndexModel(Database1Context context)
        {
            _context = context;
        }

        public List<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }

        public void OnGet()
        {
            PurchaseOrderDetail = _context.PurchaseOrderDetail.ToList();
        }

        public IActionResult OnPostInsert(decimal? unitPrice, short? orderQty)
        {
            var purchaseOrderDetail = new PurchaseOrderDetail
            {
                UnitPrice = unitPrice,
                OrderQty = orderQty
            };

            _context.PurchaseOrderDetail.Add(purchaseOrderDetail); // Add the created object to the context
            _context.SaveChanges(); // Save changes to the database

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            var purchaseOrderDetail = _context.PurchaseOrderDetail.Find(id);
            if (purchaseOrderDetail != null)
            {
                _context.PurchaseOrderDetail.Remove(purchaseOrderDetail);
                _context.SaveChanges(); 
            }

            return RedirectToPage();
        }
    }
}
