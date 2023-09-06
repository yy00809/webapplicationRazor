﻿using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
	public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
                Category = _db.Categories.Find(id);
        }

        public IActionResult OnPost()
        {
            Category? categoryFromDb = _db.Categories.Find(Category.Id);
            if (categoryFromDb == null)
                return NotFound();
            _db.Categories.Remove(categoryFromDb);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully.";
            return RedirectToPage("Index");
        }
    }
}
