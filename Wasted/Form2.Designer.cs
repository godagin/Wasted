﻿
namespace Wasted
{
    partial class Form2
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RB_type_weighted = new System.Windows.Forms.RadioButton();
            this.RB_type_discrete = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxExpiration = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(47, 65);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(213, 27);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(47, 135);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(213, 105);
            this.textBoxDescription.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(47, 280);
            this.textBoxPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(213, 27);
            this.textBoxPrice.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Produkto pavadinimas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Aprašymas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kaina";
            // 
            // RB_type_weighted
            // 
            this.RB_type_weighted.AutoSize = true;
            this.RB_type_weighted.Location = new System.Drawing.Point(326, 67);
            this.RB_type_weighted.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RB_type_weighted.Name = "RB_type_weighted";
            this.RB_type_weighted.Size = new System.Drawing.Size(97, 24);
            this.RB_type_weighted.TabIndex = 7;
            this.RB_type_weighted.TabStop = true;
            this.RB_type_weighted.Text = "Sveriamas";
            this.RB_type_weighted.UseVisualStyleBackColor = true;
            this.RB_type_weighted.CheckedChanged += new System.EventHandler(this.RB_type_weighted_CheckedChanged);
            // 
            // RB_type_discrete
            // 
            this.RB_type_discrete.AutoSize = true;
            this.RB_type_discrete.Location = new System.Drawing.Point(458, 68);
            this.RB_type_discrete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RB_type_discrete.Name = "RB_type_discrete";
            this.RB_type_discrete.Size = new System.Drawing.Size(94, 24);
            this.RB_type_discrete.TabIndex = 8;
            this.RB_type_discrete.TabStop = true;
            this.RB_type_discrete.Text = "Vienetinis";
            this.RB_type_discrete.UseVisualStyleBackColor = true;
            this.RB_type_discrete.CheckedChanged += new System.EventHandler(this.RB_type_discrete_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Pasirinkite produkto kiekybinį tipą:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(326, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Kiekis (kg)";
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(326, 145);
            this.textBoxWeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(212, 27);
            this.textBoxWeight.TabIndex = 11;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(326, 200);
            this.textBoxQuantity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(212, 27);
            this.textBoxQuantity.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Kiekis (vnt.)";
            // 
            // textBoxExpiration
            // 
            this.textBoxExpiration.Location = new System.Drawing.Point(326, 280);
            this.textBoxExpiration.Name = "textBoxExpiration";
            this.textBoxExpiration.Size = new System.Drawing.Size(212, 27);
            this.textBoxExpiration.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Galiojimo dienų skaičius";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 399);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxExpiration);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxQuantity);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RB_type_discrete);
            this.Controls.Add(this.RB_type_weighted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxName);
            this.Name = "Form2";
            this.Text = "Produkto pridėjimas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton RB_type_weighted;
        private System.Windows.Forms.RadioButton RB_type_discrete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxExpiration;
        private System.Windows.Forms.Label label7;
    }
}