namespace ManagerStuffs.Pages
{
    partial class ucPlaceStuffs
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gvPlaceStuffs = new MetroFramework.Controls.MetroGrid();
            this.txtFilterPlaceStuffs = new MetroFramework.Controls.MetroTextBox();
            this.lbFilter = new MetroFramework.Drawing.Html.HtmlLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtNamePlaceStuffs = new MetroFramework.Controls.MetroTextBox();
            this.lbNamePlaceStuff = new MetroFramework.Drawing.Html.HtmlLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeletePlaceStuff = new MetroFramework.Controls.MetroButton();
            this.btnEditPlaceStuff = new MetroFramework.Controls.MetroButton();
            this.btnInsertPlaceStuff = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaceStuffs)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(766, 417);
            this.splitContainer1.SplitterDistance = 335;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gvPlaceStuffs, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFilterPlaceStuffs, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbFilter, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(766, 335);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gvPlaceStuffs
            // 
            this.gvPlaceStuffs.AllowUserToResizeRows = false;
            this.gvPlaceStuffs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvPlaceStuffs.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvPlaceStuffs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvPlaceStuffs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gvPlaceStuffs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPlaceStuffs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gvPlaceStuffs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.gvPlaceStuffs, 2);
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvPlaceStuffs.DefaultCellStyle = dataGridViewCellStyle11;
            this.gvPlaceStuffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPlaceStuffs.EnableHeadersVisualStyles = false;
            this.gvPlaceStuffs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPlaceStuffs.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvPlaceStuffs.Location = new System.Drawing.Point(3, 36);
            this.gvPlaceStuffs.MultiSelect = false;
            this.gvPlaceStuffs.Name = "gvPlaceStuffs";
            this.gvPlaceStuffs.ReadOnly = true;
            this.gvPlaceStuffs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPlaceStuffs.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gvPlaceStuffs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gvPlaceStuffs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPlaceStuffs.Size = new System.Drawing.Size(760, 296);
            this.gvPlaceStuffs.TabIndex = 0;
            this.gvPlaceStuffs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPlaceStuffs_CellClick);
            // 
            // txtFilterPlaceStuffs
            // 
            // 
            // 
            // 
            this.txtFilterPlaceStuffs.CustomButton.Image = null;
            this.txtFilterPlaceStuffs.CustomButton.Location = new System.Drawing.Point(674, 1);
            this.txtFilterPlaceStuffs.CustomButton.Name = "";
            this.txtFilterPlaceStuffs.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtFilterPlaceStuffs.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFilterPlaceStuffs.CustomButton.TabIndex = 1;
            this.txtFilterPlaceStuffs.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFilterPlaceStuffs.CustomButton.UseSelectable = true;
            this.txtFilterPlaceStuffs.CustomButton.Visible = false;
            this.txtFilterPlaceStuffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterPlaceStuffs.Lines = new string[0];
            this.txtFilterPlaceStuffs.Location = new System.Drawing.Point(63, 3);
            this.txtFilterPlaceStuffs.MaxLength = 32767;
            this.txtFilterPlaceStuffs.Name = "txtFilterPlaceStuffs";
            this.txtFilterPlaceStuffs.PasswordChar = '\0';
            this.txtFilterPlaceStuffs.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFilterPlaceStuffs.SelectedText = "";
            this.txtFilterPlaceStuffs.SelectionLength = 0;
            this.txtFilterPlaceStuffs.SelectionStart = 0;
            this.txtFilterPlaceStuffs.ShortcutsEnabled = true;
            this.txtFilterPlaceStuffs.Size = new System.Drawing.Size(700, 27);
            this.txtFilterPlaceStuffs.TabIndex = 0;
            this.txtFilterPlaceStuffs.UseSelectable = true;
            this.txtFilterPlaceStuffs.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFilterPlaceStuffs.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtFilterPlaceStuffs.TextChanged += new System.EventHandler(this.txtFilterPlaceStuffs_TextChanged);
            this.txtFilterPlaceStuffs.Click += new System.EventHandler(this.txtFilterPlaceStuffs_Click);
            // 
            // lbFilter
            // 
            this.lbFilter.AutoScroll = true;
            this.lbFilter.AutoScrollMinSize = new System.Drawing.Size(10, 0);
            this.lbFilter.AutoSize = false;
            this.lbFilter.BackColor = System.Drawing.Color.White;
            this.lbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFilter.Location = new System.Drawing.Point(3, 3);
            this.lbFilter.Name = "lbFilter";
            this.lbFilter.Size = new System.Drawing.Size(54, 27);
            this.lbFilter.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtNamePlaceStuffs, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbNamePlaceStuff, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(766, 78);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtNamePlaceStuffs
            // 
            // 
            // 
            // 
            this.txtNamePlaceStuffs.CustomButton.Image = null;
            this.txtNamePlaceStuffs.CustomButton.Location = new System.Drawing.Point(609, 1);
            this.txtNamePlaceStuffs.CustomButton.Name = "";
            this.txtNamePlaceStuffs.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtNamePlaceStuffs.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNamePlaceStuffs.CustomButton.TabIndex = 1;
            this.txtNamePlaceStuffs.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNamePlaceStuffs.CustomButton.UseSelectable = true;
            this.txtNamePlaceStuffs.CustomButton.Visible = false;
            this.txtNamePlaceStuffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNamePlaceStuffs.Lines = new string[0];
            this.txtNamePlaceStuffs.Location = new System.Drawing.Point(153, 3);
            this.txtNamePlaceStuffs.MaxLength = 32767;
            this.txtNamePlaceStuffs.Name = "txtNamePlaceStuffs";
            this.txtNamePlaceStuffs.PasswordChar = '\0';
            this.txtNamePlaceStuffs.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNamePlaceStuffs.SelectedText = "";
            this.txtNamePlaceStuffs.SelectionLength = 0;
            this.txtNamePlaceStuffs.SelectionStart = 0;
            this.txtNamePlaceStuffs.ShortcutsEnabled = true;
            this.txtNamePlaceStuffs.Size = new System.Drawing.Size(610, 27);
            this.txtNamePlaceStuffs.TabIndex = 5;
            this.txtNamePlaceStuffs.UseSelectable = true;
            this.txtNamePlaceStuffs.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNamePlaceStuffs.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbNamePlaceStuff
            // 
            this.lbNamePlaceStuff.AutoScrollMinSize = new System.Drawing.Size(10, 0);
            this.lbNamePlaceStuff.AutoSize = false;
            this.lbNamePlaceStuff.BackColor = System.Drawing.Color.White;
            this.lbNamePlaceStuff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNamePlaceStuff.Location = new System.Drawing.Point(3, 3);
            this.lbNamePlaceStuff.Name = "lbNamePlaceStuff";
            this.lbNamePlaceStuff.Size = new System.Drawing.Size(144, 27);
            this.lbNamePlaceStuff.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Controls.Add(this.btnDeletePlaceStuff, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnEditPlaceStuff, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnInsertPlaceStuff, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(760, 36);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // btnDeletePlaceStuff
            // 
            this.btnDeletePlaceStuff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeletePlaceStuff.Location = new System.Drawing.Point(307, 3);
            this.btnDeletePlaceStuff.Name = "btnDeletePlaceStuff";
            this.btnDeletePlaceStuff.Size = new System.Drawing.Size(146, 30);
            this.btnDeletePlaceStuff.TabIndex = 4;
            this.btnDeletePlaceStuff.UseSelectable = true;
            this.btnDeletePlaceStuff.Click += new System.EventHandler(this.btnDeletePlaceStuffs_Click);
            // 
            // btnEditPlaceStuff
            // 
            this.btnEditPlaceStuff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditPlaceStuff.Location = new System.Drawing.Point(155, 3);
            this.btnEditPlaceStuff.Name = "btnEditPlaceStuff";
            this.btnEditPlaceStuff.Size = new System.Drawing.Size(146, 30);
            this.btnEditPlaceStuff.TabIndex = 3;
            this.btnEditPlaceStuff.UseSelectable = true;
            this.btnEditPlaceStuff.Click += new System.EventHandler(this.btnEditPlaceStuffs_Click);
            // 
            // btnInsertPlaceStuff
            // 
            this.btnInsertPlaceStuff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInsertPlaceStuff.Location = new System.Drawing.Point(3, 3);
            this.btnInsertPlaceStuff.Name = "btnInsertPlaceStuff";
            this.btnInsertPlaceStuff.Size = new System.Drawing.Size(146, 30);
            this.btnInsertPlaceStuff.TabIndex = 2;
            this.btnInsertPlaceStuff.UseSelectable = true;
            this.btnInsertPlaceStuff.Click += new System.EventHandler(this.btnInsertPlaceStuffs_Click);
            // 
            // ucPlaceStuffs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(65)))), ((int)(((byte)(114)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucPlaceStuffs";
            this.Size = new System.Drawing.Size(766, 417);
            this.Load += new System.EventHandler(this.ucPlaceStuffs_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPlaceStuffs)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroGrid gvPlaceStuffs;
        private MetroFramework.Controls.MetroTextBox txtFilterPlaceStuffs;
        private MetroFramework.Drawing.Html.HtmlLabel lbFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroTextBox txtNamePlaceStuffs;
        private MetroFramework.Drawing.Html.HtmlLabel lbNamePlaceStuff;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MetroFramework.Controls.MetroButton btnDeletePlaceStuff;
        private MetroFramework.Controls.MetroButton btnEditPlaceStuff;
        private MetroFramework.Controls.MetroButton btnInsertPlaceStuff;
    }
}
