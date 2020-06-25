using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalApp.Core;
using JournalApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JournalApp.Web.Pages.Journals
{
    public class ListModel : PageModel
    {
        private readonly IDataRepository<Journal> journalData;
        public IEnumerable<Journal> Journals { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IDataRepository<Journal> journalData)
        {
            this.journalData = journalData;
        }
        public void OnGet()
        {
            Journals = journalData.GetByName(SearchTerm);
        }
    }
}