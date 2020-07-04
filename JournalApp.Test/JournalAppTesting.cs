using HtmlTags.Reflection;
using JournalApp.Core;
using JournalApp.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

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
            IDataRepository<Person> uu = new PersonData();
            IDataRepository<Content> ui = new CommentData();
            var person = uu.GetById(1);
            var comment = ui.GetById(1);
            Console.WriteLine($"{person.FirstName}\n{comment.Journey}");
        }
        [Test]
        public void GetByTag_Text_Test()
        {

            // Get Tag by tag text
            ITag<Journal> uu = new JournalData();
            IDataRepository<Content> ui = new CommentData();
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
            IDataRepository<Person> getUser = new PersonData();
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
            itag.AddTag("#Test", journal);
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
                Console.WriteLine(item.Journey);
            }
        }
        [Test]
        public void GetByCategory_Test_User()
        {
            IDataRepository<Journal> db = new JournalData();
            var category = Category.User;
            var result = db.GetByCatergory(category, "Peter");
            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
            }
        }
        [Test]
        public void GetByCategory_Test_Tag()
        {
            IDataRepository<Journal> db = new JournalData();
            var category = Category.User;
            var result = db.GetByCatergory(category, "Sally");
            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
            }
        }
        [Test]
        public void GetByTAGZ_Test()
        {
            ITags<Journal> tagDB = new JournalData();
            IDataRepository<Person> peron = new PersonData();
            var person = peron.GetById(3);
            var result = tagDB.GetByTag(person);
            foreach (var item in result)
            {
                Console.WriteLine(item.Title);
            }
        }
        [Test]
        public void Tag_test()
        {
            IDataRepository<Person> retrieveUser = new PersonData();
            Content tag = new Content();
            var user = retrieveUser.GetById(3);
            tag.Tagz = new List<object> { "hi", user, "all" };
            var reTag = tag.Tagz.Where(r => tag.Tagz.Contains("Sally"));
            Person person = new Person();
            foreach (var item in tag.Tagz)
            {
                if (item is Person)
                {
                    Console.WriteLine("HI");
                    person = (Person)item;
                }
                Console.WriteLine(item.GetType());
            }
            Console.WriteLine(person.FirstName);
        }
        [Test]
        public void Tag_Test_2()
        {
            IDataRepository<Journal> retrieveJournalDb = new JournalData();
            var journal = retrieveJournalDb.GetById(1); // Change Journals to Posts
            var tags = journal.Tagz;
            foreach (var item in tags)
            {
                if (item is Person)
                {
                    Console.WriteLine(item.ToString()); ;
                }
            }
        }
        [Test]
        public void JustTags_Test()
        {
            IDataRepository<Journal> retrieveJournalDb = new JournalData();
            var journals = retrieveJournalDb.GetAll();
            var tags = journals.Select(r => r.Tagz);

        }
        [Test]
        public void Replace_Comment_Text_Test()
        {
            IDataRepository<Journal> dataRepository = new JournalData();
            IPerson<Person> userdb = new PersonData();
            var user = new Person();
            var journal = dataRepository.GetById(1);
            //if (journal.CommentString.Contains("@"))
            //{
            //    Console.WriteLine("True");
            //    string name = "HARRY";
            //    int index = journal.CommentString.IndexOf("@");
            //    journal.CommentString = journal.CommentString.Remove(index, name.Length);
            //    journal.CommentString = journal.CommentString.Insert(index, name);
            //    Console.WriteLine(journal.CommentString);
            //}

            string[] words = journal.Journey.ContentString.Split(' ');
            for (int i = 0; i < words.Count(); i++)
            {
                if (words[i].Contains("@"))
                {
                    words[i] = words[i].Trim('@');
                    string pattern = "\\b" + $"{words[i]}" + "\\b";
                    user = userdb.GetUnitByName(words[i]);
                    string replace = $"{user}";
                    journal.Journey.ContentString = Regex.Replace(journal.Journey.ContentString.Replace("@", ""), pattern, replace, RegexOptions.IgnoreCase);
                }
            }
            Object t = new object();
            t = "gfgf" + user + "xcv";
            Console.WriteLine(journal.Journey);
        }
        [Test]
        public void CommentObject_Test()
        {
            IPerson<Person> userdb = new PersonData();
            Person person = new Person();
            person = userdb.GetUnitByName("sally");
            StringBuilder str = new StringBuilder();
            str.Append("Hello Mrs ");
            str.Append(person);
            str.Append(" .We hope that you are well");
            Console.WriteLine(str);
        }
        [Test]
        public void ContentString_Test()
        {
            IDataRepository<Person> userDB = new PersonData();
            var person = userDB.GetById(1);
            Journal journal = new Journal();
            journal.Journey = new ContentText("Hi all this is @sally",new List<Person> { person });
        }
        [Test]
        public void GetCreatorOfJournal()
        {
            IDataRepository<Journal> journalDb = new JournalData();
            var journal = journalDb.GetById(1);
            var user = journal.Creator;

            Console.WriteLine(user.FullName);

        }
        [Test]
        public void GetUserPosts_Test()
        {
            IPerson<Person> pDB = new PersonData();
            var userJournals = pDB.GetUserPosts(1);
            foreach (var item in userJournals)
            {
                Console.WriteLine(item.Title);
                //if (item is Person)
                //{
                //    var i = (Person)item;
                //    Console.WriteLine(i.FirstName);
                //}
                //if (item is Journal)
                //{
                //    var i = (Journal)item;
                //    Console.WriteLine(i.Title);
                //}
            }
        }
    }
}