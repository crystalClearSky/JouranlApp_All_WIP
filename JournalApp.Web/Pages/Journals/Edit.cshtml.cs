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
    public class EditModel : PageModel
    {
        private readonly IDataRepository<Journal> journalDb;
        private readonly HtmlHelper htmlHelper;
        public Journal Journal { get; set; }
        public  IEnumerable<SelectListItem> Category { get; set; }

        public EditModel(IDataRepository<Journal> journalDb, HtmlHelper htmlHelper) //Overload called on runtime
        {
            this.journalDb = journalDb;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? userId)
        {
            Category = htmlHelper.GetEnumSelectList<Category>();
            //var user = userDb.GetById(userId);
            if (userId > 0)
            {
                //Journal = user.Posts.FirstOrDefault(j => j.Creator.FullName == user.Person.FullName);
                Journal = new Journal();
            }
            Journal = journalDb.GetById(userId);
            

            return Page();
        }
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}