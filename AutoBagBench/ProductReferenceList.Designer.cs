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
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.View = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ADD = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV1)).BeginInit();
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
            this.Delete,
            this.View,
            this.Edit,
            this.ADD});
            this.dataGV1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGV1.Location = new System.Drawing.Point(0, 0);
            this.dataGV1.Name = "dataGV1";
            this.dataGV1.Size = new System.Drawing.Size(906, 511);
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
            // ProductReferenceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 511);
            this.Controls.Add(this.dataGV1);
            this.Name = "ProductReferenceList";
            this.Text = "Product Reference List";
            this.Load += new System.EventHandler(this.ProductReferenceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGV1)).EndInit();
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
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.DataGridViewButtonColumn View;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn ADD;

    }
}