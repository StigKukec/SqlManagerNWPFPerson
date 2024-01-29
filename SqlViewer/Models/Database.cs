using SqlViewer.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlViewer.Models
{
    internal class Database
    {
        private readonly Lazy<IEnumerable<DBEntity>> tables;
        private readonly Lazy<IEnumerable<DBEntity>> views;
        private readonly Lazy<IEnumerable<Procedure>> procedures;
        public Database()
        {
            tables = new Lazy<IEnumerable<DBEntity>>(
               ()=> RepositoryFactory.Repository.GetDBEntities(this,DBEntityType.Table));
            
            views = new Lazy<IEnumerable<DBEntity>>(
                () => RepositoryFactory.Repository.GetDBEntities(this,DBEntityType.View));
            
            procedures = new Lazy<IEnumerable<Procedure>>(
                () => RepositoryFactory.Repository.GetProcedures(this));

        }
        public IList<DBEntity> Tables
        {
            get => new List<DBEntity>(tables.Value);
        }
        public IList<DBEntity> Views
        {
            get => new List<DBEntity>(views.Value);
        }
        public IList<Procedure> Procedures
        {
            get => new List<Procedure>(procedures.Value);
        }
        public string? Name { get; set; }
        public override string ToString() => Name!;
    }
}
