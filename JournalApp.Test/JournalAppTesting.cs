using JournalApp.Core;
using JournalApp.Data;
using NUnit.Framework;
using System;

namespace JournalApp.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetDateType_Test()
        {
            IDataRepository<User> uu = new UserData();
            IDataRepository<Comment> ui = new CommentData();
            var person = uu.GetById(1);
            var comment = ui.GetById(1);
            Console.WriteLine($"{person.FirstName}\n{comment.CommentString}");
        }
        [Test]
        public void GetByTag_Text_Test()
        {
            
            // Get Tag by tag text
            ITag<Journal> uu = new JournalData();
            IDataRepository<Comment> ui = new CommentData();
            Tag tag = new Tag();
            tag.TagText = "progress";
            var journals = uu.GetByTag(tag);
            foreach (var journal in journals)
            {
                Console.WriteLine($"{journal.Title}");
            }
            
        }
        [Test]
        public void GetByTag_User_Test()
        {
            // Get tag by user
            IDataRepository<User> getUser = new UserData();
            var user = getUser.GetById(2);
            Tag tag = new Tag() { UserTag = user };
            ITag<Journal> getbytag = new JournalData();
            var journals = getbytag.GetByTag(tag);
            foreach (var journal in journals)
            {
                Console.WriteLine($"{journal.Title}");
            }

        }
    }
}