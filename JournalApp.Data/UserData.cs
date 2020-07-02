using JournalApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalApp.Data
{
    public class UserData : IDataRepository<User>, IUser<User>
    {
        IDataRepository<Person> getPersonDb = new PersonData();
        IDataRepository<Journal> getJournalDb = new JournalData();
        List<User> users;
        public UserData()
        {
            var journal2 = getJournalDb.GetById(2);
            var person1 = getPersonDb.GetById(1);
            var person2 = getPersonDb.GetById(2);
            users = new List<User>()
            {
                new User() 
                { 
                    UserId = 1,
                    UserName = "salGirl_01",
                    Profile = "A highly qualified writer, a mom and a great cook.",
                    Posts = new List<Journal> {  journal2 },
                    Person = person1,
                    Connections = { person2}
                }
            };
        }

        public IEnumerable<User> GetAll()
        {
            return users.OrderBy(r => r.UserName);
        }

        public IEnumerable<User> GetByCatergory(Category catergory, string searchTerm)
        {
            throw new NotImplementedException();
        }

        public User GetById(int? id)
        {
            return users.FirstOrDefault(r => r.UserId == id);
        }

        public IEnumerable<User> GetByName(string data)
        {
            throw new NotImplementedException();
        }

        public User GetByPerson(Person person)
        {
            return users.FirstOrDefault(u => u.Person == person);
        }

        public User GetByType(User data)
        {
            throw new NotImplementedException();
        }
        
    }
}
