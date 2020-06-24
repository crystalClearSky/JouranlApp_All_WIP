using JournalApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JournalApp.Data
{
    public class JournalData : ITag<Journal>
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
    }
}


