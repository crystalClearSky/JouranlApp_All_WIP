using JournalApp.Core;
using JournalApp.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
        [Test]
        public void GetAllJournals_Test()
        {
            IDataRepository<Journal> retrieveJournals = new JournalData();
            
            var journals = retrieveJournals.GetAll();
            foreach (var journal in journals)
            {
                Console.WriteLine(journal.Title);
            }
        }
        [Test]
        public void AddTagToJournal_Test()
        {
            Tag tag = new Tag();
            IDataRepository<Journal> retrieveData = new JournalData();
            ITag<Journal> itag = new JournalData();
            var journal = retrieveData.GetById(1);
            tag.TagText = "#Play"; 
            journal.Tags.Add(tag); // Adds a tag without # or @ checks
            itag.AddTag("#Test",journal);
            foreach (var item in journal.Tags)
            {
                Console.WriteLine(item.TagText);
            }
        }
        [Test]
        public void AddUserToJournal_Test()
        {
            IDataRepository<Journal> retrieveJournal = new JournalData();
            ITag<Journal> itag = new JournalData();
            var journal = retrieveJournal.GetById(1);
            itag.AddTag("@john", journal);

            foreach (var user in journal.Tags)
            {
                if (user.UserTag.FirstName != null)
                {
                    Console.WriteLine(user.UserTag.FirstName);
                }
                
            }
            Console.WriteLine("*****");
            foreach (var tag in journal.Tags)
            {
                Console.WriteLine(tag.TagText);
            }
        }
        [Test]
        public void GetByCategory_Test()
        {
            IDataRepository<Journal> db = new JournalData();
            var category = Category.Content;
            var result = db.GetByCatergory(category, "promise");
            foreach (var item in result)
            {
                Console.WriteLine(item.CommentString);
            }
        }
        [Test]
        public void GetByCategory_Test_User()
        {
            IDataRepository<Journal> db = new JournalData();
            var category = Category.User;
            var result = db.GetByCatergory(category, "sally");
            foreach (var item in result)
            {
            }
        }
    }
}