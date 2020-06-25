using JournalApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JournalApp.Data
{
    public class JournalData : ITag<Journal>, IDataRepository<Journal>
    {
        List<Journal> journals;
        public JournalData()
        {
            IDataRepository<User> getUser = new UserData();
            var user = getUser.GetById(1);
            var user1 = getUser.GetById(2);
            journals = new List<Journal>()
            {
                new Journal()
                {
                   Id = 1,
                   Title = "The Best thing in life",
                   CommentString = "Emerson is miserable with his life." +
                   "He’s constantly bullied, and his boyfriend, Matt, sides with his tormentors.",
                   Created = new DateTime(2019,9,19),
                   Tags = new List<Tag>()
                   {
                       new Tag(){ Id = 1, TagText = "firstbook", UserTag = user },
                       new Tag(){ Id = 2, TagText = "progress" },
                   }
                },
                new Journal()
                {
                   Id = 2,
                   Title = "My Person Zbrush work",
                   CommentString = "As promised, full turnaround video of my Arcanist model. Wings aren’t coloured" +
                   " correctly but that’s what you get when you don’t uv map",
                   Created = new DateTime(2019,5,11),
                   Tags = new List<Tag>()
                   {
                       new Tag(){ Id = 1, TagText = "art" },
                       new Tag(){ Id = 2, TagText = "3D", UserTag = user1 },
                   }
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
            if (tag.UserTag != null)
            {
                result = journals.Where(x => x.Tags.Any(x => x.UserTag.FirstName == tag.UserTag.FirstName));
            }
            if (!string.IsNullOrWhiteSpace(tag.TagText))
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
                    IDataRepository<User> getUser = new UserData();
                    var users = getUser.GetAll();
                    var user = users.FirstOrDefault(u => u.FirstName.ToLower() == tagEntry);
                    if (string.IsNullOrWhiteSpace(user.FirstName))
                    {
                        Console.WriteLine("User not found!");
                        return;
                    }
                    if(!string.IsNullOrWhiteSpace(user.FirstName))
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

        public IEnumerable<Journal> GetByCatergory(Category catergory = Category.None, string searchTerm = "")
        {
            IEnumerable<Journal> result = new List<Journal>();
            switch (catergory)
            {
                case Category.None:
                    break;
                case Category.Title:
                    result = journals.Where(j => j.Title.ToLower().Contains(searchTerm));
                    break;
                case Category.Content:
                    result = journals.Where(j => j.CommentString.ToLower().Contains(searchTerm));
                    break;
                case Category.Tag:
                    result = journals.Where(j => j.Tags.Any(t => t.TagText.ToLower().StartsWith(searchTerm)));
                    break;
                case Category.User:
                    result = journals.Where(j => j.Tags.Any(t => t.UserTag.FirstName.ToLower().StartsWith(searchTerm)));
                    break; // Not wroking riquires fix
                default:
                    break;
            }
            return result;
        }
    }
}


