namespace ManagerStuffs.Pages
{
    partial class ucCategories
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
            this.gvCategories = new MetroFramework.Controls.MetroGrid();
            this.txtFilterCategories = new MetroFramework.Controls.MetroTextBox();
            this.lbFilter = new MetroFramework.Drawing.Html.HtmlLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtNameCategories = new MetroFramework.Controls.MetroTextBox();
            this.lbStatus = new MetroFramework.Drawing.Html.HtmlLabel();
            this.lbNameCategory = new MetroFramework.Drawing.Html.HtmlLabel();
            this.cbStatus = new MetroFramework.Controls.MetroCheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteCategory = new MetroFramework.Controls.MetroButton();
            this.btnEditCategory = new MetroFramework.Controls.MetroButton();
            this.btnInsertCategory = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategories)).BeginInit();
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
            this.splitContainer1.SplitterDistance = 305;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gvCategories, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtFilterCategories, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbFilter, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(766, 305);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gvCategories
            // 
            this.gvCategories.AllowUserToResizeRows = false;
            this.gvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvCategories.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gvCategories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gvCategories.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.gvCategories, 2);
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvCategories.DefaultCellStyle = dataGridViewCellStyle11;
            this.gvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvCategories.EnableHeadersVisualStyles = false;
            this.gvCategories.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvCategories.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvCategories.Location = new System.Drawing.Point(3, 36);
            this.gvCategories.MultiSelect = false;
            this.gvCategories.Name = "gvCategories";
            this.gvCategories.ReadOnly = true;
            this.gvCategories.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvCategories.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.gvCategories.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvCategories.Size = new System.Drawing.Size(760, 266);
            this.gvCategories.TabIndex = 0;
            this.gvCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvCategories_CellClick);
            this.gvCategories.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvCategories_KeyDown);
            // 
            // txtFilterCategories
            // 
            // 
            // 
            // 
            this.txtFilterCategories.CustomButton.Image = null;
            this.txtFilterCategories.CustomButton.Location = new System.Drawing.Point(694, 1);
            this.txtFilterCategories.CustomButton.Name = "";
            this.txtFilterCategories.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtFilterCategories.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFilterCategories.CustomButton.TabIndex = 1;
            this.txtFilterCategories.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFilterCategories.CustomButton.UseSelectable = true;
            this.txtFilterCategories.CustomButton.Visible = false;
            this.txtFilterCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilterCategories.Lines = new string[0];
            this.txtFilterCategories.Location = new System.Drawing.Point(63, 3);
            this.txtFilterCategories.MaxLength = 32767;
            this.txtFilterCategories.Name = "txtFilterCategories";
            this.txtFilterCategories.PasswordChar = '\0';
            this.txtFilterCategories.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFilterCategories.SelectedText = "";
            this.txtFilterCategories.SelectionLength = 0;
            this.txtFilterCategories.SelectionStart = 0;
            this.txtFilterCategories.ShortcutsEnabled = true;
            this.txtFilterCategories.Size = new System.Drawing.Size(700, 27);
            this.txtFilterCategories.TabIndex = 0;
            this.txtFilterCategories.UseSelectable = true;
            this.txtFilterCategories.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFilterCategories.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtFilterCategories.TextChanged += new System.EventHandler(this.txtFilterCategories_TextChanged);
            this.txtFilterCategories.Click += new System.EventHandler(this.txtFilterCategories_Click);
            // 
            // lbFilter
            // 
            this.lbFilter.AutoScroll = true;
            this.lbFilter.AutoScrollMinSize = new System.Drawing.Size(10, 10);
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
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.txtNameCategories, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbStatus, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbNameCategory, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbStatus, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(766, 108);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtNameCategories
            // 
            // 
            // 
            // 
            this.txtNameCategories.CustomButton.Image = null;
            this.txtNameCategories.CustomButton.Location = new System.Drawing.Point(614, 1);
            this.txtNameCategories.CustomButton.Name = "";
            this.txtNameCategories.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtNameCategories.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNameCategories.CustomButton.TabIndex = 1;
            this.txtNameCategories.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNameCategories.CustomButton.UseSelectable = true;
            this.txtNameCategories.CustomButton.Visible = false;
            this.txtNameCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNameCategories.Lines = new string[0];
            this.txtNameCategories.Location = new System.Drawing.Point(123, 3);
            this.txtNameCategories.MaxLength = 32767;
            this.txtNameCategories.Name = "txtNameCategories";
            this.txtNameCategories.PasswordChar = '\0';
            this.txtNameCategories.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNameCategories.SelectedText = "";
            this.txtNameCategories.SelectionLength = 0;
            this.txtNameCategories.SelectionStart = 0;
            this.txtNameCategories.ShortcutsEnabled = true;
            this.txtNameCategories.Size = new System.Drawing.Size(640, 27);
            this.txtNameCategories.TabIndex = 5;
            this.txtNameCategories.UseSelectable = true;
            this.txtNameCategories.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNameCategories.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoScroll = true;
            this.lbStatus.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.lbStatus.AutoSize = false;
            this.lbStatus.BackColor = System.Drawing.Color.White;
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStatus.Location = new System.Drawing.Point(3, 36);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(114, 27);
            this.lbStatus.TabIndex = 4;
            // 
            // lbNameCategory
            // 
            this.lbNameCategory.AutoScroll = true;
            this.lbNameCategory.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.lbNameCategory.AutoSize = false;
            this.lbNameCategory.BackColor = System.Drawing.Color.White;
            this.lbNameCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNameCategory.Location = new System.Drawing.Point(3, 3);
            this.lbNameCategory.Name = "lbNameCategory";
            this.lbNameCategory.Size = new System.Drawing.Size(114, 27);
            this.lbNameCategory.TabIndex = 3;
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStatus.Location = new System.Drawing.Point(123, 36);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(640, 27);
            this.cbStatus.TabIndex = 6;
            this.cbStatus.UseSelectable = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Controls.Add(this.btnDeleteCategory, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnEditCategory, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnInsertCategory, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 69);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(760, 36);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteCategory.Location = new System.Drawing.Point(307, 3);
            this.btnDeleteCategory.Name = "btnDeleteCategory";
            this.btnDeleteCategory.Size = new System.Drawing.Size(146, 30);
            this.btnDeleteCategory.TabIndex = 4;
            this.btnDeleteCategory.UseSelectable = true;
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategories_Click);
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditCategory.Location = new System.Drawing.Point(155, 3);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(146, 30);
            this.btnEditCategory.TabIndex = 3;
            this.btnEditCategory.UseSelectable = true;
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategories_Click);
            // 
            // btnInsertCategory
            // 
            this.btnInsertCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInsertCategory.Location = new System.Drawing.Point(3, 3);
            this.btnInsertCategory.Name = "btnInsertCategory";
            this.btnInsertCategory.Size = new System.Drawing.Size(146, 30);
            this.btnInsertCategory.TabIndex = 2;
            this.btnInsertCategory.UseSelectable = true;
            this.btnInsertCategory.Click += new System.EventHandler(this.btnInsertCategories_Click);
            // 
            // ucCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(65)))), ((int)(((byte)(114)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucCategories";
            this.Size = new System.Drawing.Size(766, 417);
            this.Load += new System.EventHandler(this.ucCategories_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvCategories)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroGrid gvCategories;
        private MetroFramework.Controls.MetroTextBox txtFilterCategories;
        private MetroFramework.Drawing.Html.HtmlLabel lbFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Drawing.Html.HtmlLabel lbNameCategory;
        private MetroFramework.Drawing.Html.HtmlLabel lbStatus;
        private MetroFramework.Controls.MetroTextBox txtNameCategories;
        private MetroFramework.Controls.MetroCheckBox cbStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MetroFramework.Controls.MetroButton btnInsertCategory;
        private MetroFramework.Controls.MetroButton btnEditCategory;
        private MetroFramework.Controls.MetroButton btnDeleteCategory;
    }
}
