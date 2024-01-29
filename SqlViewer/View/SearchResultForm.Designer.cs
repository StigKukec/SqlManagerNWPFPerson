namespace SqlViewer.View
{
    partial class SearchResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgResults = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgResults).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.Silver;
            dgResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgResults.Dock = DockStyle.Fill;
            dgResults.Location = new Point(0, 0);
            dgResults.Name = "dataGridView1";
            dgResults.RowTemplate.Height = 25;
            dgResults.Size = new Size(800, 450);
            dgResults.TabIndex = 0;
            // 
            // SearchResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgResults);
            Name = "SearchResultForm";
            Text = "SearchResultForm";
            ((System.ComponentModel.ISupportInitialize)dgResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgResults;
    }
}