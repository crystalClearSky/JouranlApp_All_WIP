using JournalApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JournalApp.Data
{
    public class JournalData : ITag<Journal>, IDataRepository<Journal>, ITags<Journal>
    {
        List<Journal> journals;
        public JournalData()
        {
            IDataRepository<Person> getUser = new UserData();
            var user = getUser.GetById(1);
            var user1 = getUser.GetById(2);
            var user2 = getUser.GetById(3);
            journals = new List<Journal>()
            {
                new Journal()
                {
                   Id = 1,
                   Title = "The Best thing in life",
                   CommentString = "Enjoying a lovely day with my besty @sally near the 'megatroncafe' in 'london'",
                   Created = new DateTime(2019,9,19),
                   Tagz = new List<object>() { "gamer", "zbrush", user, "drawing", user1, }
                   
                   //Tags = new List<Tag>()
                   //{
                   //    new Tag(){ Id = 1, TagText = "firstbook", UserTag = user },
                   //    new Tag(){ Id = 2, TagText = "progress" },
                   //    //new Tag(){ Id = 3, UserTag = user2 },
                   //}
                },
                new Journal()
                {
                   Id = 2,
                   Title = "My Person Zbrush work",
                   CommentString = "As promised, full turnaround video of my Arcanist model. Wings aren’t coloured" +
                   " correctly but that’s what you get when you don’t uv map",
                   Created = new DateTime(2019,5,11),
                   Tagz = new List<object>() { "music", "water", user2, "adventure" }
                }
            };
        }

        public IEnumerable<Journal> GetAll()
        {
            return journals.OrderBy(j => j.Created);
        }

        public Journal GetById(int id)
        {
            return journals.FirstOrDefault(j => j.Id == id);
        }

        public IEnumerable<Journal> GetByTag(Tag tag)
        {
            IEnumerable<Journal> result = new List<Journal>();
            if (!string.IsNullOrEmpty(tag.UserTag.FirstName))
            {
                result = journals.Where(x => x.Tags.Any(x => x.UserTag.FirstName == tag.UserTag.FirstName));
            }
            if (!string.IsNullOrEmpty(tag.TagText))
            {
                result = journals.Where(j => j.Tags.Any(j => j.TagText.StartsWith(tag.TagText)));
            }
            return result;
        }
        public void AddTag(string tagEntry = "", Journal journal = null)
        {
            if (!string.IsNullOrWhiteSpace(tagEntry))
            {
                if (tagEntry.StartsWith('#'))
                {
                    tagEntry = tagEntry.Trim('#');
                    journal.Tags.Add(new Tag { TagText = tagEntry });
                }
                if (tagEntry.StartsWith('@'))
                {
                    tagEntry = tagEntry.Trim('@');
                    IDataRepository<Person> getUser = new UserData();
                    var users = getUser.GetAll();
                    var user = users.FirstOrDefault(u => u.FirstName.ToLower() == tagEntry);
                    if (string.IsNullOrWhiteSpace(user.FirstName))
                    {
                        Console.WriteLine("User not found!");
                        return;
                    }
                    if (!string.IsNullOrWhiteSpace(user.FirstName))
                    {
                        journal.Tags.Add(new Tag() { UserTag = user });
                    }
                }
            }
            // returns user if @ or tag if #
        }

        public Journal GetByType(Journal data)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Journal> GetByName(string data = null)
        {
            //return journals?.Where
            //    (r => string.IsNullOrWhiteSpace(data) || r.Title.ToLower().Contains(data)).OrderBy(r => r.Title);

            return journals?.Where
                (r => string.IsNullOrWhiteSpace(data) || r.Title.ToLower().Contains(data)).OrderBy(r => r.Title);
        }

        public IEnumerable<Journal> GetByCatergory(Category catergory = Category.Title, string searchTerm = "")
        {
            Person person = new Person();
            IEnumerable<Journal> result = new List<Journal>();
            switch (catergory)
            {
                //case Category.All:
                //    result = journals.OrderBy(j => j.Title);
                //    break;
                case Category.Title:
                    result = journals.Where(j => j.Title.ToLower().Contains(searchTerm));
                    break;
                case Category.Content:
                    result = journals.Where(j => j.CommentString.ToLower().Contains(searchTerm));
                    break;
                case Category.Tag:
                    result = journals.Where(r => r.Tagz.Contains(searchTerm));
                    break;// Not working for some tags
                case Category.User:
                    var results = journals.Where(r => r.Tagz.OfType<Person>().Any());
                    List<Person> persons = new List<Person>();
                    foreach (var item in results)
                    {
                        for (int i = 0; i < item.Tagz.Count; i++)
                        {
                            if (item.Tagz[i] is Person)
                            {
                                //Console.WriteLine("Found");
                                person = (Person)item.Tagz[i];
                                if (person.FirstName.ToLower().StartsWith(searchTerm))
                                {
                                    //Console.WriteLine("Particular user found!");
                                    result = result.Append(item);
                                }
                                //persons.Add((Person)item.Tagz[i]);
                                //if true then result.add ( this item )
                            }

                        }
                    }

                    break;
                //case Category.User:
                //    result = journals.Where(j => j.Tags.Any(t => t.UserTag.FirstName.ToLower().StartsWith(searchTerm)));
                //    break; // Requires User return type.
                default:
                    break;
            }
            return result;
        }

        public IEnumerable<Journal> GetByTag(object tag)
        {
            var results = new List<Journal>();
            //int count = 1;
            Person tags = new Person();
            Person compare = new Person();
            //bool leave = false;
            if (tag is Person)
            {
                Console.WriteLine("Hi");
                tags = (Person)tag;
            }

            if (tag is Person)
            {
                var tagList = journals.Where(r => r.Tagz.OfType<Person>().Any());
                Person person = new Person();
                foreach (var item in tagList)
                {
                    for (int i = 0; i < item.Tagz.Count; i++)
                    {
                        if (item.Tagz[i] is Person)
                        {
                            //Console.WriteLine("Found");
                            person = (Person)item.Tagz[i];
                            if (person.FirstName == tags.FirstName)
                            {
                                results.Add(item);
                            }
                            //persons.Add((Person)item.Tagz[i]);
                            //if true then result.add ( this item )
                        }

                    }
                }
            }

                //var e = journals.Select(r => r.Tagz.ToList());
                //foreach (var items in e)
                //{
                //    foreach (var item in items)
                //    {
                //        if (item is Person)
                //        {
                //            compare = (Person)item;
                //            if (compare.FirstName == tags.FirstName)
                //            {
                //                Console.WriteLine("Found");
                //                leave = true;
                //                break;
                //            }
                //            if (leave) break;
                //        }
                //        if (leave) break;
                //    }
                //    if (leave)
                //    {
                //        var toAdd = GetById(count);
                //        if (!results.Contains(toAdd))
                //        {
                //            results.Add(toAdd);
                //        }

                //    }
                //    else
                //    {
                //        count++;
                //    }
                //}
            
            else
            {
                results = journals.FindAll(r => r.Tagz.Contains(tag));
            }
            //Console.WriteLine(count);
            
            return results;
        }
    }
}


