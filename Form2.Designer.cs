﻿namespace Project_SQL
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
            this.SuspendLayout();
            // 
            // itemReg
            // 
            this.itemReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.itemReg.Location = new System.Drawing.Point(125, 85);
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
            this.cust.Location = new System.Drawing.Point(125, 170);
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
            this.rental.Location = new System.Drawing.Point(125, 255);
            this.rental.Name = "rental";
            this.rental.Size = new System.Drawing.Size(160, 60);
            this.rental.TabIndex = 2;
            this.rental.Text = "Rental";
            this.rental.UseVisualStyleBackColor = true;
            this.rental.Click += new System.EventHandler(this.rental_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(125, 340);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 60);
            this.button4.TabIndex = 3;
            this.button4.Text = "Return";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 550);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.rental);
            this.Controls.Add(this.cust);
            this.Controls.Add(this.itemReg);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button itemReg;
        private System.Windows.Forms.Button cust;
        private System.Windows.Forms.Button rental;
        private System.Windows.Forms.Button button4;
    }
}