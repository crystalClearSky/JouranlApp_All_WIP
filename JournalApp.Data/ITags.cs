using JournalApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace JournalApp.Data
{
    public interface ITags<TData>
    {
        IEnumerable<TData> GetByTag(object tag);
    }
}
