using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScripturesJournal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyScripturesJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScripturesJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScripturesJournalContext>>()))
            {
                if (context.Scripture.Any())
                {
                    return;
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Chapter = "4",
                        Verse = "3",
                        Notes = "Wow",
                        CreatedDate = DateTime.Parse("2020-05-13"),
                        BookId = 5
                    },

                    new Scripture
                    {
                        Chapter = "4",
                        Verse = "3",
                        Notes = "Great verse",
                        CreatedDate = DateTime.Parse("2020-04-13"),
                        BookId = 3
                    },

                    new Scripture
                    {
                        Chapter = "4",
                        Verse = "3",
                        Notes = "Isn't that inspiring",
                        CreatedDate = DateTime.Parse("2020-03-1"),
                        BookId = 67
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
