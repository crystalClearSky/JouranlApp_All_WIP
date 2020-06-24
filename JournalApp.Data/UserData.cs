using JournalApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JournalApp.Data
{
    public class UserData : IDataRepository<User>
    {
        List<User> users;
        public UserData()
        {
            users = new List<User>()
            {
                new User() { Id = 1, FirstName = "Sally", LastName = "Smith", DateOfBirth = new DateTime(1981,11,24), Gender = Gender.Female},
                new User() { Id = 2, FirstName = "Jane", LastName = "Johnson", DateOfBirth = new DateTime(1964, 9, 14), Gender = Gender.Female },
                new User() { Id = 3, FirstName = "Peter", LastName = "Soloman", DateOfBirth = new DateTime(1975,4,19), Gender = Gender.Male},
                new User() { Id = 4, FirstName = "John", LastName = "Anderson", DateOfBirth = new DateTime(1979,12,1), Gender = Gender.Male},
            };
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

    }   
}
