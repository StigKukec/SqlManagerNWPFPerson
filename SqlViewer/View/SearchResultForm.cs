using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlViewer.View
{
    public partial class SearchResultForm : Form
    {
        public SearchResultForm(DataTable table)
        {
            InitializeComponent();
            Text = table.TableName;
            dgResults.DataSource = table;
        }
    }
}
