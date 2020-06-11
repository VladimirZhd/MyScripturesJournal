using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyScripturesJournal.Data;
using MyScripturesJournal.Models;

namespace MyScripturesJournal.Pages.Scriptures
{
    public class CreateModel : PageModel
    {
        private readonly MyScripturesJournal.Data.MyScripturesJournalContext _context;

        public CreateModel(MyScripturesJournal.Data.MyScripturesJournalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            
            ViewData["BookName"] = new SelectList(_context.Set<Book>(), "BookName", "BookName");
            return Page();
        }

        [BindProperty]
        public Scripture Scripture { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Scripture.Add(Scripture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
