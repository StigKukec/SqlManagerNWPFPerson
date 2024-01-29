using SqlViewer.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlViewer.Models
{
    internal class Procedure
    {
        private readonly Lazy<IEnumerable<Parameter>> parameters;
        public Procedure()
        {
            parameters = new Lazy<IEnumerable<Parameter>>(() => RepositoryFactory.Repository.GetParameters(this));
        }
        public IList<Parameter> Parameters
        {
            get => new List<Parameter>(parameters.Value);
        }
        public string? Definition { get; set; }
        public string? Name { get; set; }
        public Database? Database { get; set; }
        public override string ToString() => $"{Name}";
    }
}
