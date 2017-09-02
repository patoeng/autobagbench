namespace AutoBagBench
{
    partial class ProductReferenceList
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
            this.dataGV1 = new System.Windows.Forms.DataGridView();
            this.Identity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArticleNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupingSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BagTypeCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccessoriesType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLabelFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.View = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ADD = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbReferenceFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.btnImportFromExcel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlImporting = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlImporting.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGV1
            // 
            this.dataGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Identity,
            this.ReferenceName,
            this.ArticleNumber,
            this.GroupingSize,
            this.BagTypeCell,
            this.AccessoriesType,
            this.clmLabelFile,
            this.Delete,
            this.View,
            this.Edit,
            this.ADD});
            this.dataGV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV1.Location = new System.Drawing.Point(0, 0);
            this.dataGV1.Name = "dataGV1";
            this.dataGV1.Size = new System.Drawing.Size(1076, 547);
            this.dataGV1.TabIndex = 1;
            this.dataGV1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGV1_CellContentClick);
            // 
            // Identity
            // 
            this.Identity.HeaderText = "IDENTITY";
            this.Identity.Name = "Identity";
            this.Identity.Visible = false;
            // 
            // ReferenceName
            // 
            this.ReferenceName.HeaderText = "REFERENCE NAME";
            this.ReferenceName.Name = "ReferenceName";
            // 
            // ArticleNumber
            // 
            this.ArticleNumber.HeaderText = "ARTICLE NUMBER";
            this.ArticleNumber.Name = "ArticleNumber";
            // 
            // GroupingSize
            // 
            this.GroupingSize.HeaderText = "GROUPING SIZE";
            this.GroupingSize.Name = "GroupingSize";
            // 
            // BagTypeCell
            // 
            this.BagTypeCell.HeaderText = "BAG TYPE";
            this.BagTypeCell.Name = "BagTypeCell";
            // 
            // AccessoriesType
            // 
            this.AccessoriesType.HeaderText = "ACCESSORIES TYPE";
            this.AccessoriesType.Name = "AccessoriesType";
            // 
            // clmLabelFile
            // 
            this.clmLabelFile.HeaderText = "Label File";
            this.clmLabelFile.Name = "clmLabelFile";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "DELETE";
            this.Delete.Name = "Delete";
            // 
            // View
            // 
            this.View.HeaderText = "VIEW";
            this.View.Name = "View";
            // 
            // Edit
            // 
            this.Edit.HeaderText = "EDIT";
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ADD
            // 
            this.ADD.HeaderText = "ADD";
            this.ADD.Name = "ADD";
            this.ADD.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ADD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.38961F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.61039F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1082, 616);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlImporting);
            this.panel1.Controls.Add(this.dataGV1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1076, 547);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.btnImportFromExcel);
            this.panel2.Controls.Add(this.btnExportToExcel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbReferenceFilter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 57);
            this.panel2.TabIndex = 1;
            // 
            // tbReferenceFilter
            // 
            this.tbReferenceFilter.Location = new System.Drawing.Point(124, 22);
            this.tbReferenceFilter.Name = "tbReferenceFilter";
            this.tbReferenceFilter.Size = new System.Drawing.Size(280, 20);
            this.tbReferenceFilter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search By Reference";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(738, 19);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(146, 23);
            this.btnExportToExcel.TabIndex = 2;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnImportFromExcel
            // 
            this.btnImportFromExcel.Location = new System.Drawing.Point(890, 19);
            this.btnImportFromExcel.Name = "btnImportFromExcel";
            this.btnImportFromExcel.Size = new System.Drawing.Size(146, 23);
            this.btnImportFromExcel.TabIndex = 2;
            this.btnImportFromExcel.Text = "Import From Excel";
            this.btnImportFromExcel.UseVisualStyleBackColor = true;
            this.btnImportFromExcel.Click += new System.EventHandler(this.btnImportFromExcel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(425, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(146, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlImporting
            // 
            this.pnlImporting.Controls.Add(this.btnCancel);
            this.pnlImporting.Controls.Add(this.progressBar1);
            this.pnlImporting.Controls.Add(this.label2);
            this.pnlImporting.Location = new System.Drawing.Point(306, 127);
            this.pnlImporting.Name = "pnlImporting";
            this.pnlImporting.Size = new System.Drawing.Size(450, 179);
            this.pnlImporting.TabIndex = 2;
            this.pnlImporting.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(429, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Importing... It may takes minutes or hours... ";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(23, 94);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(406, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(190, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ProductReferenceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 616);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProductReferenceList";
            this.Text = "Product Reference List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductReferenceList_FormClosing);
            this.Load += new System.EventHandler(this.ProductReferenceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlImporting.ResumeLayout(false);
            this.pnlImporting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGV1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticleNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupingSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn BagTypeCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccessoriesType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLabelFile;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewButtonColumn View;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn ADD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbReferenceFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Button btnImportFromExcel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlImporting;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCancel;
    }
}