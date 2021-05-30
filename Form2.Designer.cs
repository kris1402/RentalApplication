namespace Project_SQL
{
    partial class Main
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
            this.itemReg = new System.Windows.Forms.Button();
            this.cust = new System.Windows.Forms.Button();
            this.rental = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemReg
            // 
            this.itemReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.itemReg.Location = new System.Drawing.Point(114, 85);
            this.itemReg.Name = "itemReg";
            this.itemReg.Size = new System.Drawing.Size(160, 60);
            this.itemReg.TabIndex = 0;
            this.itemReg.Text = "Item Registation";
            this.itemReg.UseVisualStyleBackColor = true;
            this.itemReg.Click += new System.EventHandler(this.itemReg_Click);
            // 
            // cust
            // 
            this.cust.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cust.Location = new System.Drawing.Point(114, 170);
            this.cust.Name = "cust";
            this.cust.Size = new System.Drawing.Size(160, 60);
            this.cust.TabIndex = 1;
            this.cust.Text = "Customer";
            this.cust.UseVisualStyleBackColor = true;
            this.cust.Click += new System.EventHandler(this.cust_Click);
            // 
            // rental
            // 
            this.rental.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rental.Location = new System.Drawing.Point(67, 296);
            this.rental.Name = "rental";
            this.rental.Size = new System.Drawing.Size(160, 60);
            this.rental.TabIndex = 2;
            this.rental.Text = "RentalOLD";
            this.rental.UseVisualStyleBackColor = true;
            this.rental.Click += new System.EventHandler(this.rental_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(67, 211);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 60);
            this.button4.TabIndex = 3;
            this.button4.Text = "Rental";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.rental);
            this.groupBox1.Location = new System.Drawing.Point(47, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 394);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 500);
            this.Controls.Add(this.cust);
            this.Controls.Add(this.itemReg);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Main";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button itemReg;
        private System.Windows.Forms.Button cust;
        private System.Windows.Forms.Button rental;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}