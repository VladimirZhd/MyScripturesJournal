using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyScripturesJournal.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Display(Name = "Book Name")]
        public string BookName { get; set; }

        public List<Scripture> Scriptures { get; set; }
    }
}
