namespace CodeFirst_Invoice
{
    partial class FormInvoiceDetails
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
            this.dataGridViewInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerCity = new System.Windows.Forms.TextBox();
            this.txtCustomerCounty = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnInvoiceALL = new System.Windows.Forms.Button();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoiceDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInvoiceDetails
            // 
            this.dataGridViewInvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInvoiceDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewInvoiceDetails.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dataGridViewInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInvoiceDetails.Location = new System.Drawing.Point(12, 150);
            this.dataGridViewInvoiceDetails.Name = "dataGridViewInvoiceDetails";
            this.dataGridViewInvoiceDetails.ReadOnly = true;
            this.dataGridViewInvoiceDetails.Size = new System.Drawing.Size(690, 279);
            this.dataGridViewInvoiceDetails.TabIndex = 0;
            this.dataGridViewInvoiceDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInvoiceDetails_CellClick);
            this.dataGridViewInvoiceDetails.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewInvoiceDetails_CellMouseDoubleClick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(234, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 23);
            this.label2.TabIndex = 29;
            this.label2.Text = "Customer City";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(234, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 23);
            this.label1.TabIndex = 33;
            this.label1.Text = "Customer Name";
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnShowDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnShowDetails.Location = new System.Drawing.Point(619, 30);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(73, 67);
            this.btnShowDetails.TabIndex = 35;
            this.btnShowDetails.Text = "All Invoice Details";
            this.btnShowDetails.UseVisualStyleBackColor = false;
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click);
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.BackColor = System.Drawing.Color.PapayaWhip;
            this.txtInvoiceID.Location = new System.Drawing.Point(115, 36);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(95, 20);
            this.txtInvoiceID.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(9, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "Invoice ID :";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(234, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 23);
            this.label4.TabIndex = 38;
            this.label4.Text = "Customer County";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Location = new System.Drawing.Point(375, 11);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(220, 20);
            this.txtCustomerName.TabIndex = 40;
            // 
            // txtCustomerCity
            // 
            this.txtCustomerCity.Enabled = false;
            this.txtCustomerCity.Location = new System.Drawing.Point(375, 54);
            this.txtCustomerCity.Name = "txtCustomerCity";
            this.txtCustomerCity.Size = new System.Drawing.Size(220, 20);
            this.txtCustomerCity.TabIndex = 41;
            // 
            // txtCustomerCounty
            // 
            this.txtCustomerCounty.Enabled = false;
            this.txtCustomerCounty.Location = new System.Drawing.Point(375, 93);
            this.txtCustomerCounty.Name = "txtCustomerCounty";
            this.txtCustomerCounty.Size = new System.Drawing.Size(220, 20);
            this.txtCustomerCounty.TabIndex = 42;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalAmount.Location = new System.Drawing.Point(601, 432);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(104, 23);
            this.lblTotalAmount.TabIndex = 66;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(491, 432);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 23);
            this.label8.TabIndex = 65;
            this.label8.Text = "Total Amount :";
            // 
            // btnInvoiceALL
            // 
            this.btnInvoiceALL.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnInvoiceALL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnInvoiceALL.Location = new System.Drawing.Point(12, 102);
            this.btnInvoiceALL.Name = "btnInvoiceALL";
            this.btnInvoiceALL.Size = new System.Drawing.Size(92, 42);
            this.btnInvoiceALL.TabIndex = 67;
            this.btnInvoiceALL.Text = "All Invoice";
            this.btnInvoiceALL.UseVisualStyleBackColor = false;
            this.btnInvoiceALL.Click += new System.EventHandler(this.btnInvoiceALL_Click);
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.BackColor = System.Drawing.Color.PapayaWhip;
            this.btnDeleteInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDeleteInvoice.Location = new System.Drawing.Point(110, 102);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(92, 42);
            this.btnDeleteInvoice.TabIndex = 68;
            this.btnDeleteInvoice.Text = "Delete Invoice";
            this.btnDeleteInvoice.UseVisualStyleBackColor = false;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // FormInvoiceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(720, 464);
            this.Controls.Add(this.btnDeleteInvoice);
            this.Controls.Add(this.btnInvoiceALL);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCustomerCounty);
            this.Controls.Add(this.txtCustomerCity);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInvoiceID);
            this.Controls.Add(this.btnShowDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewInvoiceDetails);
            this.MaximizeBox = false;
            this.Name = "FormInvoiceDetails";
            this.Text = "InvoiceDetails";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoiceDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInvoiceDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerCity;
        private System.Windows.Forms.TextBox txtCustomerCounty;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnInvoiceALL;
        private System.Windows.Forms.Button btnDeleteInvoice;
    }
}