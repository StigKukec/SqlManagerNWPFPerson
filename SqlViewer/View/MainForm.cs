using SqlViewer.Dal;
using SqlViewer.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SqlViewer.View
{
    public partial class MainForm : Form
    {
        private List<Database>? databases;
        private enum TagType
        {
            Databases, Tables, Views, Procedures
        }
        public MainForm()
        {
            InitializeComponent();
            Login();
            LoadDatabases();
            InitTree();
            ClearForm();
        }

        private void LoadDatabases()
        {
            databases = new List<Database>(RepositoryFactory.Repository.GetDatabases());
            databases.ToList().ForEach(x => cbDatabase.Items.Add(x));
            cbDatabase.SelectedIndex = 0;
        }

        private void InitTree()
        {
            var dbNode = new TreeNode(TagType.Databases.ToString(), new[] { new TreeNode() }) { Tag = TagType.Databases };
            tvServer.Nodes.Add(dbNode);
        }

        private void ClearForm()
        {
            tsbSave.Enabled = false;
            tsbSelect.Enabled = false;
            dbEntity = null;
        }

        private void MainForm_Shown(object? sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Login()
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (SQLRepository.LoginSuccess() == false)
            {
                this.Shown += MainForm_Shown;
            }
        }
        private Database? database;
        private void TvServer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e is null || databases == null)
            {
                return;
            }
            ClearForm();
            tvServer.BeginUpdate();
            switch (e.Node)
            {
                case { Tag: TagType.Databases }:
                    e.Node.Nodes.Clear();
                    databases.ForEach(db => e.Node.Nodes.Add(
                        new TreeNode(
                           db.ToString(),
                            new[] { new TreeNode() })
                        { Tag = db }
                        ));
                    break;

                case { Tag: TagType.Tables }:
                    e.Node.Nodes.Clear();
                    database = e.Node.Parent.Tag as Database;
                    database?.Tables.ToList().ForEach(t => e.Node.Nodes.Add(
                        new TreeNode(
                           t.ToString(),
                            new[] { new TreeNode() })
                        { Tag = t }
                        ));
                    break;

                case { Tag: TagType.Views }:
                    e.Node.Nodes.Clear();
                    database = e.Node.Parent.Tag as Database;
                    database?.Views.ToList().ForEach(v => e.Node.Nodes.Add(
                        new TreeNode(
                           v.ToString(),
                            new[] { new TreeNode() })
                        { Tag = v }
                        ));
                    break;

                case { Tag: TagType.Procedures }:
                    e.Node.Nodes.Clear();
                    database = e.Node.Parent.Tag as Database;
                    database?.Procedures.ToList().ForEach(p => e.Node.Nodes.Add(
                        new TreeNode(
                           p.ToString(),
                            new[] { new TreeNode() })
                        { Tag = p }
                        ));
                    break;

                case { Tag: Procedure procedure }:
                    e.Node.Nodes.Clear();
                    rtbCommands.Text = string.Empty;
                    procedure.Parameters.ToList().ForEach(v => e.Node.Nodes.Add(
                        new TreeNode(
                           v.ToString())));
                    rtbCommands.Text = procedure.Definition;
                    break;

                case { Tag: Database db }:
                    e.Node.Nodes.Clear();
                    e.Node.Nodes.Add(new TreeNode(TagType.Tables.ToString(), new[] { new TreeNode() }) { Tag = TagType.Tables });
                    e.Node.Nodes.Add(new TreeNode(TagType.Views.ToString(), new[] { new TreeNode() }) { Tag = TagType.Views });
                    e.Node.Nodes.Add(new TreeNode(TagType.Procedures.ToString(), new[] { new TreeNode() }) { Tag = TagType.Procedures });
                    break;

                case { Tag: DBEntity entity }:
                    dbEntity = entity;
                    e.Node.Nodes.Clear();
                    entity?.Columns.ToList().ForEach(p => e.Node.Nodes.Add(
                        new TreeNode(
                           p.ToString())));
                    tsbSelect.Enabled = true;
                    tsbSave.Enabled = true;
                    break;

            }
            tvServer.EndUpdate();
        }
        private DBEntity? dbEntity;
        private const string FileFilter = "XML files(*.xml)|*.xml|All files(*.*)|*.*";
        private const string FileName = "{0}.xml";
        private void TsbSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = FileFilter,
                FileName = FileName
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = RepositoryFactory.Repository.CreateDataset(dbEntity);
                ds.WriteXml(saveFileDialog.FileName, XmlWriteMode.WriteSchema);
            }
        }
        private void TsbSelect_Click(object sender, EventArgs e)
        {
            if (dbEntity == null)
            {
                return;
            }
            DataSet ds = RepositoryFactory.Repository.CreateDataset(dbEntity);
            new SearchResultForm(ds.Tables[0]).ShowDialog();
        }
        private void TvServer_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            switch (e.Node)
            {
                case { Tag: DBEntity }:
                    tsbSelect.Enabled = false;
                    tsbSave.Enabled = false;
                    break;
                case { Tag: Procedure }:
                    rtbCommands.Text = string.Empty;
                    break;
            }
        }
        public enum CRUDType
        {
            Insert, Update, Delete, Select, From, Len, Substring, SCOPE_IDENTITY, where, into, values
        }
        private void TsbExecute_Click(object sender, EventArgs e)
        {
            /*
            dgvSQLTableResult.DataSource = null;
            dgvSQLTableResult.Rows.Clear();
            */
            Database? selectedDatabase = cbDatabase.SelectedItem as Database;
            SQLResult result = RepositoryFactory.Repository.SendSQLCommand(rtbCommands.Text, selectedDatabase!);
            if (result.Result == null)
            {
                tabSQLResult.TabPages[0].Visible = false;
                tabSQLResult.TabPages[1].Focus();
                lblSQLMessageResult.Text = result.Message;
                lblSQLMessageResult.ForeColor = result.MessageColor;
                return;
            }

            tabSQLResult.TabPages[0].Visible = true;
            tabSQLResult.TabPages[0].Focus();
            dgvSQLTableResult.DataSource = result.Result;
            lblSQLMessageResult.Text = result.Message;
            lblSQLMessageResult.ForeColor = result.MessageColor;
        }

        private void RtbCommands_TextChanged(object sender, EventArgs e)
        {
            WordColor(CRUDType.Select, Color.Blue);
            WordColor(CRUDType.Insert, Color.Blue);
            WordColor(CRUDType.Delete, Color.Blue);
            WordColor(CRUDType.Update, Color.Purple);
            WordColor(CRUDType.From, Color.Blue);
            WordColor(CRUDType.Len, Color.Purple);
            WordColor(CRUDType.Substring, Color.Purple);
            WordColor(CRUDType.where, Color.Blue);
            WordColor(CRUDType.SCOPE_IDENTITY, Color.Purple);
            WordColor(CRUDType.into, Color.Blue);
            WordColor(CRUDType.values, Color.Blue);

        }
        private void WordColor(CRUDType type, Color color)
        {
            string text = rtbCommands.Text;
            int startIndex = 0;

            while (startIndex < text.Length)
            {
                startIndex = text.IndexOf(type.ToString(), startIndex, StringComparison.OrdinalIgnoreCase);

                if (startIndex == -1)
                {
                    break;
                }
                rtbCommands.SelectionStart = startIndex;
                rtbCommands.SelectionLength = type.ToString().Length;
                rtbCommands.SelectionColor = color;
                rtbCommands.SelectionFont = new Font(rtbCommands.Font, FontStyle.Bold);

                startIndex += type.ToString().Length;
            }


            rtbCommands.SelectionStart = text.Length;
            rtbCommands.SelectionLength = 0;
            rtbCommands.SelectionColor = Color.Black;
            rtbCommands.SelectionFont = new Font(rtbCommands.Font, FontStyle.Regular);

        }
    }
}