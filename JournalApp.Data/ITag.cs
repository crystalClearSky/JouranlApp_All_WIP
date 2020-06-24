using JournalApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace JournalApp.Data
{
    public interface ITag<TTag>
    {
        IEnumerable<TTag> GetByTag(Tag tag);
        void AddTag(string tagEntry, Journal journal = null);
    }
}
