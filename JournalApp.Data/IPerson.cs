using JournalApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JournalApp.Data
{
    public interface IPerson<TData>
    {
        TData GetUnitByName(string unit);
        IEnumerable<Journal> GetUserPosts(int id);
    }
}
