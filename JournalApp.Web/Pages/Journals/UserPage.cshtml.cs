using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JournalApp.Core;
using JournalApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JournalApp.Web.Pages.Journals
{
    public class UserPageModel : PageModel
    {
        private readonly IDataRepository<User> userData;
        public User ThisUser { get; set; }

        public UserPageModel(IDataRepository<User> userData)
        {
            this.userData = userData;
        }
        public void OnGet(int userId)
        {
            ThisUser = userData.GetById(userId);
        }
    }
}