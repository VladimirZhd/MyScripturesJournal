using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScripturesJournal.Data;
using MyScripturesJournal.Models;

namespace MyScripturesJournal.Pages.Scriptures
{
    public class DetailsModel : PageModel
    {
        private readonly MyScripturesJournal.Data.MyScripturesJournalContext _context;

        public DetailsModel(MyScripturesJournal.Data.MyScripturesJournalContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
