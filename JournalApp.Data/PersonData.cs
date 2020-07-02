using JournalApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JournalApp.Data
{
    public class PersonData : IDataRepository<Person>, IPerson<Person>
    {
        List<Person> users;
        public PersonData()
        {
            users = new List<Person>()
            {
                new Person() { Id = 1, FirstName = "Sally", LastName = "Smith", DateOfBirth = new DateTime(1981,11,24), Gender = Gender.Female},
                new Person() { Id = 2, FirstName = "Jane", LastName = "Johnson", DateOfBirth = new DateTime(1964, 9, 14), Gender = Gender.Female },
                new Person() { Id = 3, FirstName = "Peter", LastName = "Soloman", DateOfBirth = new DateTime(1975,4,19), Gender = Gender.Male},
                new Person() { Id = 4, FirstName = "John", LastName = "Anderson", DateOfBirth = new DateTime(1979,12,1), Gender = Gender.Male},
            };
        }

        public IEnumerable<Person> GetAll()
        {
            return users.OrderBy(r => r.FirstName);
        }

        public IEnumerable<Person> GetByCatergory(Category catergory, string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Person GetById(int? id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Person> GetByName(string data)
        {
            return users.Where(u => u.FirstName.StartsWith(data));
        }

        public Person GetByType(Person data)
        {
            return users.FirstOrDefault(r => r.FirstName == data.FirstName);
        }

        public Person GetUnitByName(string unit)
        {
            return users.FirstOrDefault(u => u.FirstName.ToLower().StartsWith(unit));
        }
    }   
}
