using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScripturesJournal.Data;
using MyScripturesJournal.Models;

namespace MyScripturesJournal.Pages.Scriptures
{
    public class EditModel : PageModel
    {
        private readonly MyScripturesJournal.Data.MyScripturesJournalContext _context;

        public EditModel(MyScripturesJournal.Data.MyScripturesJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Scripture Scripture { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Scripture = await _context.Scripture
                .Include(s => s.Book).FirstOrDefaultAsync(m => m.ScriptureId == id);

            if (Scripture == null)
            {
                return NotFound();
            }
           ViewData["BookName"] = new SelectList(_context.Set<Book>(), "BookName", "BookName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Scripture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScriptureExists(Scripture.ScriptureId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ScriptureExists(int id)
        {
            return _context.Scripture.Any(e => e.ScriptureId == id);
        }
    }
}
