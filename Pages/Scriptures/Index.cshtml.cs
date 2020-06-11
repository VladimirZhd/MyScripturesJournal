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
    public class IndexModel : PageModel
    {
        private readonly MyScripturesJournal.Data.MyScripturesJournalContext _context;

        public IndexModel(MyScripturesJournal.Data.MyScripturesJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookName { get; set; }
        public string BookSort { get; set; }
        public string DateSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {

            IQueryable<string> bookQuery = from m in _context.Scripture orderby m.Book.BookId select m.Book.BookName;
            var scriptures = from m in _context.Scripture select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BookName))
            {
                scriptures = scriptures.Where(x => x.Book.BookName == BookName);
            }

            BookSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Scripture> ScripturesSort = from s in _context.Scripture select s;

            switch (sortOrder)
            {
                case "name_desc":
                    ScripturesSort = ScripturesSort.OrderByDescending(s => s.Book.BookName);
                    break;
                case "Date":
                    ScripturesSort = ScripturesSort.OrderBy(s => s.CreatedDate);
                    break;
                case "date_desc":
                    ScripturesSort = ScripturesSort.OrderByDescending(s => s.CreatedDate);
                    break;
                default:
                    ScripturesSort = ScripturesSort.OrderBy(s => s.Book.BookName);
                    break;
            }
            if (!string.IsNullOrEmpty(sortOrder))
            {
                scriptures = ScripturesSort;
            }
            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await scriptures
                .Include(s => s.Book).ToListAsync();
        }
    }
}
