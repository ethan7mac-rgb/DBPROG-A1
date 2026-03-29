namespace Lab1_SqlServerCodeConnect
{
    partial class Form1
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
            cboTables = new ComboBox();
            lblStat1Desc = new Label();
            lblStat2Desc = new Label();
            lblStat1Value = new Label();
            lblStat2Value = new Label();
            dgvOutput = new DataGridView();
            label1 = new Label();
            grpStats = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvOutput).BeginInit();
            grpStats.SuspendLayout();
            SuspendLayout();
            // 
            // cboTables
            // 
            cboTables.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTables.FormattingEnabled = true;
            cboTables.Location = new Point(907, 39);
            cboTables.Margin = new Padding(3, 2, 3, 2);
            cboTables.Name = "cboTables";
            cboTables.Size = new Size(209, 23);
            cboTables.TabIndex = 0;
            cboTables.SelectedIndexChanged += cboTables_SelectedIndexChanged;
            // 
            // lblStat1Desc
            // 
            lblStat1Desc.AutoSize = true;
            lblStat1Desc.Location = new Point(10, 28);
            lblStat1Desc.Name = "lblStat1Desc";
            lblStat1Desc.Size = new Size(38, 15);
            lblStat1Desc.TabIndex = 1;
            lblStat1Desc.Text = "label1";
            // 
            // lblStat2Desc
            // 
            lblStat2Desc.AutoSize = true;
            lblStat2Desc.Location = new Point(10, 76);
            lblStat2Desc.Name = "lblStat2Desc";
            lblStat2Desc.Size = new Size(38, 15);
            lblStat2Desc.TabIndex = 2;
            lblStat2Desc.Text = "label2";
            // 
            // lblStat1Value
            // 
            lblStat1Value.BorderStyle = BorderStyle.Fixed3D;
            lblStat1Value.Location = new Point(10, 49);
            lblStat1Value.Name = "lblStat1Value";
            lblStat1Value.Size = new Size(203, 19);
            lblStat1Value.TabIndex = 3;
            lblStat1Value.Text = "label3";
            // 
            // lblStat2Value
            // 
            lblStat2Value.BorderStyle = BorderStyle.Fixed3D;
            lblStat2Value.Location = new Point(10, 95);
            lblStat2Value.Name = "lblStat2Value";
            lblStat2Value.Size = new Size(203, 19);
            lblStat2Value.TabIndex = 4;
            lblStat2Value.Text = "label4";
            // 
            // dgvOutput
            // 
            dgvOutput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOutput.Location = new Point(22, 22);
            dgvOutput.Margin = new Padding(3, 2, 3, 2);
            dgvOutput.MultiSelect = false;
            dgvOutput.Name = "dgvOutput";
            dgvOutput.RowHeadersWidth = 51;
            dgvOutput.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOutput.Size = new Size(851, 265);
            dgvOutput.TabIndex = 5;
            dgvOutput.SelectionChanged += dgvOutput_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(907, 22);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 6;
            label1.Text = "Select a Table:";
            // 
            // grpStats
            // 
            grpStats.Controls.Add(lblStat2Value);
            grpStats.Controls.Add(lblStat1Desc);
            grpStats.Controls.Add(lblStat2Desc);
            grpStats.Controls.Add(lblStat1Value);
            grpStats.Location = new Point(897, 116);
            grpStats.Margin = new Padding(3, 2, 3, 2);
            grpStats.Name = "grpStats";
            grpStats.Padding = new Padding(3, 2, 3, 2);
            grpStats.Size = new Size(219, 127);
            grpStats.TabIndex = 7;
            grpStats.TabStop = false;
            grpStats.Text = "Item Stats:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 296);
            Controls.Add(grpStats);
            Controls.Add(label1);
            Controls.Add(dgvOutput);
            Controls.Add(cboTables);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab 1 by ";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOutput).EndInit();
            grpStats.ResumeLayout(false);
            grpStats.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboTables;
        private Label lblStat1Desc;
        private Label lblStat2Desc;
        private Label lblStat1Value;
        private Label lblStat2Value;
        private DataGridView dgvOutput;
        private Label label1;
        private GroupBox grpStats;
    }
}
