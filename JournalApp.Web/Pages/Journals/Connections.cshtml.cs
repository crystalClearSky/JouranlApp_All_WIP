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
    public class ConnectionsModel : PageModel
    {
        private readonly IDataRepository<User> userDb;
        public IEnumerable<Person> People { get; set; }
        public ConnectionsModel(IDataRepository<User> userDb)
        {
            this.userDb = userDb;
        }
        public void OnGet(int connectionId)
        {
            var users = userDb.GetById(connectionId);
            People = users.Connections;
        }
    }
}