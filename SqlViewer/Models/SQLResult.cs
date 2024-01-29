using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlViewer.Models
{
    internal class SQLResult
    {
        public SQLResult(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
        public Color MessageColor { get; set; }
        public DataTable Result { get; set; }
        public override string ToString() => $"{Message}";
    }
}
