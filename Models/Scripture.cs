using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyScripturesJournal.Models
{
    public class Scripture
    {

        public int ScriptureId { get; set; }
        public int BookId { get; set; }
        public string Chapter { get; set; }
        public string Verse { get; set; }
        public string Notes { get; set; }

        [Display(Name = "Created on")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        public Book Book { get; set; }
    }
}
