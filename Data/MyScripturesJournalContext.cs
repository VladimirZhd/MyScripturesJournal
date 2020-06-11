using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyScripturesJournal.Models;

namespace MyScripturesJournal.Data
{
    public class MyScripturesJournalContext : DbContext
    {
        public MyScripturesJournalContext (DbContextOptions<MyScripturesJournalContext> options)
            : base(options)
        {
        }

        public DbSet<MyScripturesJournal.Models.Scripture> Scripture { get; set; }
    }
}
