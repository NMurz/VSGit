using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFood.Data.Repositories.GenericResository
{
    public class Context<T> : IContext<T> where T:class
    {
        public System.Data.Entity.DbContext DbContext   { get; private set; }

        public System.Data.Entity.IDbSet<T> DbSet { get; private set; }

        public Context()
        {
            DbContext = new DbContext(ConfigurationManager.ConnectionStrings["easyfoodEntities"].ConnectionString);
            DbSet = DbContext.Set<T>();
        } 
        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
