using JournalApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlTags;

namespace JournalApp.Data
{
    public class CommentData : IDataRepository<Content>
    {
        List<Content> comments;
        public CommentData()
        {
            
            comments = new List<Content>()
            {
                new Content() { CommentId = 1, Journey = new ContentText("Facebook users love to share their opinion. The large image and four options make it fast and easy for them to understand the poll and do so.")},
                new Content() { CommentId = 2, Journey = new ContentText(" I’d definitely test a more exciting picture for this poll post, with models instead of just the shoes on a table. How about the traditional ‘lady’s-night-out shoe shot’?")},
            };
        }

        public IEnumerable<Content> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Content> GetByCatergory(Category catergory, string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Content GetById(int? id)
        {
            return comments.FirstOrDefault(c => c.CommentId == id);
        }

        public IEnumerable<Content> GetByName(string data)
        {
            throw new NotImplementedException();
        }

        public Content GetByType(Content data)
        {
            throw new NotImplementedException();
        }
    }
}
