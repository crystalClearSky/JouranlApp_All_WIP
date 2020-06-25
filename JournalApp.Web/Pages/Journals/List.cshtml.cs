using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalApp.Core;
using JournalApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace JournalApp.Web.Pages.Journals
{
    public class ListModel : PageModel
    {
        private readonly IDataRepository<Journal> journalData;
        private readonly HtmlHelper htmlHelper;

        public IEnumerable<Journal> Journals { get; set; }
        public IEnumerable<SelectListItem> SearchCatergory { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IDataRepository<Journal> journalData, HtmlHelper htmlHelper)
        {
            this.journalData = journalData;
            this.htmlHelper = htmlHelper;
        }
        public void OnGet(Category catergory)
        {
            Journals = journalData.GetByName(SearchTerm);

            SearchCatergory = htmlHelper.GetEnumSelectList<Category>();
            if (catergory != Category.None)
            {
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                    Journals = journalData.GetByCatergory(catergory, SearchTerm);
                }
                
            }
            
        }
    }
}