using JournalApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalApp.Data
{
    public class CommentData : IDataRepository<Comment>
    {
        List<Comment> comments;
        public CommentData()
        {
            comments = new List<Comment>()
            {
                new Comment() { CommentId = 1, CommentString = "Facebook users love to share their opinion. The large image and four options make it fast and easy for them to understand the poll and do so."},
                new Comment() { CommentId = 2, CommentString = " I’d definitely test a more exciting picture for this poll post, with models instead of just the shoes on a table. How about the traditional ‘lady’s-night-out shoe shot’?"},
            };
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            return comments.FirstOrDefault(c => c.CommentId == id);
        }

        public IEnumerable<Comment> GetByName(string data)
        {
            throw new NotImplementedException();
        }

        public Comment GetByType(Comment data)
        {
            throw new NotImplementedException();
        }
    }
}
