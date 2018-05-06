namespace CSV_Peruser
{
    partial class Form1
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
            this.btn_Load = new System.Windows.Forms.Button();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtbx_Filepath = new System.Windows.Forms.TextBox();
            this.data_Grid = new System.Windows.Forms.DataGridView();
            this.combo_Delimeter = new System.Windows.Forms.ComboBox();
            this.grp_File_Selector = new System.Windows.Forms.GroupBox();
            this.label_LeftFilter1 = new System.Windows.Forms.Label();
            this.combo_LeftFilter1 = new System.Windows.Forms.ComboBox();
            this.txtbox_LeftPod = new System.Windows.Forms.RichTextBox();
            this.combo_LeftReturnCol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_LeftSign1 = new System.Windows.Forms.ComboBox();
            this.txt_LeftFilter1 = new System.Windows.Forms.TextBox();
            this.btn_LeftFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_Grid)).BeginInit();
            this.grp_File_Selector.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(247, 43);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(75, 23);
            this.btn_Load.TabIndex = 0;
            this.btn_Load.Text = "Load";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Visible = false;
            this.btn_Load.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(9, 43);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 2;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            // 
            // txtbx_Filepath
            // 
            this.txtbx_Filepath.Location = new System.Drawing.Point(9, 19);
            this.txtbx_Filepath.Name = "txtbx_Filepath";
            this.txtbx_Filepath.ReadOnly = true;
            this.txtbx_Filepath.Size = new System.Drawing.Size(313, 20);
            this.txtbx_Filepath.TabIndex = 4;
            // 
            // data_Grid
            // 
            this.data_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_Grid.Location = new System.Drawing.Point(12, 93);
            this.data_Grid.Name = "data_Grid";
            this.data_Grid.Size = new System.Drawing.Size(648, 279);
            this.data_Grid.TabIndex = 5;
            // 
            // combo_Delimeter
            // 
            this.combo_Delimeter.FormattingEnabled = true;
            this.combo_Delimeter.Items.AddRange(new object[] {
            "Comma (\",\")",
            "Tab (\"\\t\")",
            "Semi-colon (\";\")"});
            this.combo_Delimeter.Location = new System.Drawing.Point(90, 45);
            this.combo_Delimeter.Name = "combo_Delimeter";
            this.combo_Delimeter.Size = new System.Drawing.Size(151, 21);
            this.combo_Delimeter.TabIndex = 6;
            // 
            // grp_File_Selector
            // 
            this.grp_File_Selector.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grp_File_Selector.Controls.Add(this.btn_Load);
            this.grp_File_Selector.Controls.Add(this.combo_Delimeter);
            this.grp_File_Selector.Controls.Add(this.btn_Browse);
            this.grp_File_Selector.Controls.Add(this.txtbx_Filepath);
            this.grp_File_Selector.Location = new System.Drawing.Point(12, 12);
            this.grp_File_Selector.Name = "grp_File_Selector";
            this.grp_File_Selector.Size = new System.Drawing.Size(329, 75);
            this.grp_File_Selector.TabIndex = 7;
            this.grp_File_Selector.TabStop = false;
            this.grp_File_Selector.Text = "File Selector";
            // 
            // label_LeftFilter1
            // 
            this.label_LeftFilter1.AutoSize = true;
            this.label_LeftFilter1.Location = new System.Drawing.Point(386, 60);
            this.label_LeftFilter1.Name = "label_LeftFilter1";
            this.label_LeftFilter1.Size = new System.Drawing.Size(38, 13);
            this.label_LeftFilter1.TabIndex = 8;
            this.label_LeftFilter1.Text = "Filter 1";
            // 
            // combo_LeftFilter1
            // 
            this.combo_LeftFilter1.FormattingEnabled = true;
            this.combo_LeftFilter1.Location = new System.Drawing.Point(430, 55);
            this.combo_LeftFilter1.Name = "combo_LeftFilter1";
            this.combo_LeftFilter1.Size = new System.Drawing.Size(135, 21);
            this.combo_LeftFilter1.TabIndex = 9;
            this.combo_LeftFilter1.SelectedIndexChanged += new System.EventHandler(this.combo_LeftFilter1_SelectedIndexChanged);
            // 
            // txtbox_LeftPod
            // 
            this.txtbox_LeftPod.Location = new System.Drawing.Point(760, 12);
            this.txtbox_LeftPod.Name = "txtbox_LeftPod";
            this.txtbox_LeftPod.ReadOnly = true;
            this.txtbox_LeftPod.Size = new System.Drawing.Size(139, 206);
            this.txtbox_LeftPod.TabIndex = 11;
            this.txtbox_LeftPod.Text = "";
            this.txtbox_LeftPod.WordWrap = false;
            // 
            // combo_LeftReturnCol
            // 
            this.combo_LeftReturnCol.FormattingEnabled = true;
            this.combo_LeftReturnCol.Location = new System.Drawing.Point(430, 28);
            this.combo_LeftReturnCol.Name = "combo_LeftReturnCol";
            this.combo_LeftReturnCol.Size = new System.Drawing.Size(135, 21);
            this.combo_LeftReturnCol.TabIndex = 13;
            this.combo_LeftReturnCol.SelectedIndexChanged += new System.EventHandler(this.combo_LeftReturnCol_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Return Column";
            // 
            // combo_LeftSign1
            // 
            this.combo_LeftSign1.FormattingEnabled = true;
            this.combo_LeftSign1.Location = new System.Drawing.Point(571, 55);
            this.combo_LeftSign1.Name = "combo_LeftSign1";
            this.combo_LeftSign1.Size = new System.Drawing.Size(59, 21);
            this.combo_LeftSign1.TabIndex = 14;
            this.combo_LeftSign1.SelectedIndexChanged += new System.EventHandler(this.combo_LeftSign1_SelectedIndexChanged);
            // 
            // txt_LeftFilter1
            // 
            this.txt_LeftFilter1.Location = new System.Drawing.Point(636, 55);
            this.txt_LeftFilter1.Name = "txt_LeftFilter1";
            this.txt_LeftFilter1.Size = new System.Drawing.Size(118, 20);
            this.txt_LeftFilter1.TabIndex = 15;
            // 
            // btn_LeftFilter
            // 
            this.btn_LeftFilter.Location = new System.Drawing.Point(679, 81);
            this.btn_LeftFilter.Name = "btn_LeftFilter";
            this.btn_LeftFilter.Size = new System.Drawing.Size(75, 23);
            this.btn_LeftFilter.TabIndex = 16;
            this.btn_LeftFilter.Text = "Filter";
            this.btn_LeftFilter.UseVisualStyleBackColor = true;
            this.btn_LeftFilter.Click += new System.EventHandler(this.btn_LeftFilter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 384);
            this.Controls.Add(this.btn_LeftFilter);
            this.Controls.Add(this.txt_LeftFilter1);
            this.Controls.Add(this.combo_LeftSign1);
            this.Controls.Add(this.combo_LeftReturnCol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbox_LeftPod);
            this.Controls.Add(this.combo_LeftFilter1);
            this.Controls.Add(this.label_LeftFilter1);
            this.Controls.Add(this.grp_File_Selector);
            this.Controls.Add(this.data_Grid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.data_Grid)).EndInit();
            this.grp_File_Selector.ResumeLayout(false);
            this.grp_File_Selector.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtbx_Filepath;
        private System.Windows.Forms.DataGridView data_Grid;
        private System.Windows.Forms.ComboBox combo_Delimeter;
        private System.Windows.Forms.GroupBox grp_File_Selector;
        private System.Windows.Forms.Label label_LeftFilter1;
        private System.Windows.Forms.ComboBox combo_LeftFilter1;
        private System.Windows.Forms.RichTextBox txtbox_LeftPod;
        private System.Windows.Forms.ComboBox combo_LeftReturnCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_LeftSign1;
        private System.Windows.Forms.TextBox txt_LeftFilter1;
        private System.Windows.Forms.Button btn_LeftFilter;
    }
}

