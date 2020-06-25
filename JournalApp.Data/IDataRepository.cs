using JournalApp.Core;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace JournalApp.Data
{
    public interface IDataRepository<TData>
    {
        IEnumerable<TData> GetAll(); // Get all of any data
        TData GetById(int id);
        TData GetByType(TData data);
        IEnumerable<TData> GetByName(string data);
    }
}
