using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
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
        private readonly IDataRepository<Journal> journalDb;

        public User ThisUser { get; set; }
        public Journal Journal { get; set; }

        public UserPageModel(IDataRepository<User> userData, IDataRepository<Journal> journalDb)
        {
            this.userData = userData;
            this.journalDb = journalDb;
        }
        public void OnGet(int userId)
        {
            
            var user = userData.GetById(userId);
            if (user != null)
            {
                ThisUser = user;
            }
            else
            {
                ThisUser = new User()
                {
                    FirstName = "",
                    LastName = "",
                    Connections = new List<Person>(),
                    Person_Id = 0,
                    Gender = Gender.Unknown,
                    UserName = "",
                    Posts = new List<Journal>()
                };
            }
            
            var journal = journalDb.GetById(userId);
            if (journal != null)
            {
                Journal = journal;
            }
            else
            {
                Journal = new Journal()
                {
                    AuthorId = 0,
                    Comment_Id = 0,
                    Created = DateTime.Now,
                    Journey = new ContentText(""),
                    
                };
            }
        }
    }
}