using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFood.Data.Repositories.GenericResository
{
    public interface IContext<T> : IDisposable where T:class
    {
        DbContext DbContext { get; }
        IDbSet<T> DbSet { get; } 
    }
}
