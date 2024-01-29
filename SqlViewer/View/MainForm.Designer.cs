namespace SqlViewer.View
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            tsbSelect = new ToolStripButton();
            tsbSave = new ToolStripButton();
            tsbExecute = new ToolStripButton();
            tvServer = new TreeView();
            tabSQLResult = new TabControl();
            tabResultPage = new TabPage();
            dgvSQLTableResult = new DataGridView();
            tabMessagePage = new TabPage();
            lblSQLMessageResult = new Label();
            cbDatabase = new ComboBox();
            label1 = new Label();
            rtbCommands = new RichTextBox();
            toolStrip1.SuspendLayout();
            tabSQLResult.SuspendLayout();
            tabResultPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSQLTableResult).BeginInit();
            tabMessagePage.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbSelect, tsbSave, tsbExecute });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1494, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbSelect
            // 
            tsbSelect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSelect.Image = (Image)resources.GetObject("tsbSelect.Image");
            tsbSelect.ImageTransparentColor = Color.Magenta;
            tsbSelect.Name = "tsbSelect";
            tsbSelect.Size = new Size(23, 22);
            tsbSelect.Text = "Show table";
            tsbSelect.Click += TsbSelect_Click;
            // 
            // tsbSave
            // 
            tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSave.Image = (Image)resources.GetObject("tsbSave.Image");
            tsbSave.ImageTransparentColor = Color.Magenta;
            tsbSave.Name = "tsbSave";
            tsbSave.Size = new Size(23, 22);
            tsbSave.Text = "Save table";
            tsbSave.Click += TsbSave_Click;
            // 
            // tsbExecute
            // 
            tsbExecute.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbExecute.Image = (Image)resources.GetObject("tsbExecute.Image");
            tsbExecute.ImageTransparentColor = Color.Magenta;
            tsbExecute.Name = "tsbExecute";
            tsbExecute.Size = new Size(23, 22);
            tsbExecute.Text = "Execute SQL command";
            tsbExecute.Click += TsbExecute_Click;
            // 
            // tvServer
            // 
            tvServer.Location = new Point(12, 71);
            tvServer.Name = "tvServer";
            tvServer.Size = new Size(273, 747);
            tvServer.TabIndex = 1;
            tvServer.AfterCollapse += TvServer_AfterCollapse;
            tvServer.BeforeExpand += TvServer_BeforeExpand;
            // 
            // tabSQLResult
            // 
            tabSQLResult.Controls.Add(tabResultPage);
            tabSQLResult.Controls.Add(tabMessagePage);
            tabSQLResult.Location = new Point(291, 614);
            tabSQLResult.Name = "tabSQLResult";
            tabSQLResult.SelectedIndex = 0;
            tabSQLResult.Size = new Size(1203, 204);
            tabSQLResult.TabIndex = 3;
            // 
            // tabResultPage
            // 
            tabResultPage.Controls.Add(dgvSQLTableResult);
            tabResultPage.Location = new Point(4, 24);
            tabResultPage.Name = "tabResultPage";
            tabResultPage.Padding = new Padding(3);
            tabResultPage.Size = new Size(1195, 176);
            tabResultPage.TabIndex = 0;
            tabResultPage.Text = "Result";
            tabResultPage.UseVisualStyleBackColor = true;
            // 
            // dgvSQLTableResult
            // 
            dgvSQLTableResult.BorderStyle = BorderStyle.Fixed3D;
            dgvSQLTableResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSQLTableResult.Dock = DockStyle.Fill;
            dgvSQLTableResult.Location = new Point(3, 3);
            dgvSQLTableResult.Name = "dgvSQLTableResult";
            dgvSQLTableResult.RowTemplate.Height = 25;
            dgvSQLTableResult.Size = new Size(1189, 170);
            dgvSQLTableResult.TabIndex = 0;
            // 
            // tabMessagePage
            // 
            tabMessagePage.Controls.Add(lblSQLMessageResult);
            tabMessagePage.Location = new Point(4, 24);
            tabMessagePage.Name = "tabMessagePage";
            tabMessagePage.Padding = new Padding(3);
            tabMessagePage.Size = new Size(1195, 176);
            tabMessagePage.TabIndex = 1;
            tabMessagePage.Text = "Message";
            tabMessagePage.UseVisualStyleBackColor = true;
            // 
            // lblSQLMessageResult
            // 
            lblSQLMessageResult.AutoSize = true;
            lblSQLMessageResult.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            lblSQLMessageResult.Location = new Point(26, 38);
            lblSQLMessageResult.Name = "lblSQLMessageResult";
            lblSQLMessageResult.Size = new Size(59, 25);
            lblSQLMessageResult.TabIndex = 0;
            lblSQLMessageResult.Text = "label2";
            // 
            // cbDatabase
            // 
            cbDatabase.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDatabase.FormattingEnabled = true;
            cbDatabase.Location = new Point(47, 42);
            cbDatabase.Name = "cbDatabase";
            cbDatabase.Size = new Size(238, 23);
            cbDatabase.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 45);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 5;
            label1.Text = "Use:";
            // 
            // rtbCommands
            // 
            rtbCommands.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            rtbCommands.Location = new Point(291, 42);
            rtbCommands.Name = "rtbCommands";
            rtbCommands.Size = new Size(1199, 566);
            rtbCommands.TabIndex = 6;
            rtbCommands.Text = "";
            rtbCommands.TextChanged += RtbCommands_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1494, 830);
            Controls.Add(rtbCommands);
            Controls.Add(label1);
            Controls.Add(cbDatabase);
            Controls.Add(tabSQLResult);
            Controls.Add(tvServer);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabSQLResult.ResumeLayout(false);
            tabResultPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSQLTableResult).EndInit();
            tabMessagePage.ResumeLayout(false);
            tabMessagePage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbSelect;
        private ToolStripButton tsbSave;
        private TreeView tvServer;
        private TabControl tabSQLResult;
        private TabPage tabResultPage;
        private TabPage tabMessagePage;
        private ToolStripButton tsbExecute;
        private ComboBox cbDatabase;
        private Label label1;
        private DataGridView dgvSQLTableResult;
        private Label lblSQLMessageResult;
        private RichTextBox rtbCommands;
    }
}