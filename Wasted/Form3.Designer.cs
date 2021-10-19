
namespace Wasted
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.bin = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.RB_weighed = new System.Windows.Forms.RadioButton();
            this.RB_discrete = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.submit_changes = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bin
            // 
            this.bin.Location = new System.Drawing.Point(434, 224);
            this.bin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bin.Name = "bin";
            this.bin.Size = new System.Drawing.Size(82, 26);
            this.bin.TabIndex = 0;
            this.bin.Text = "Į šiukšlinę";
            this.bin.UseVisualStyleBackColor = true;
            this.bin.Click += new System.EventHandler(this.bin_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(36, 32);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(225, 23);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(36, 189);
            this.textBoxPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(225, 23);
            this.textBoxPrice.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(36, 80);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(225, 77);
            this.textBoxDescription.TabIndex = 4;
            // 
            // RB_weighed
            // 
            this.RB_weighed.AutoSize = true;
            this.RB_weighed.Location = new System.Drawing.Point(312, 32);
            this.RB_weighed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RB_weighed.Name = "RB_weighed";
            this.RB_weighed.Size = new System.Drawing.Size(78, 19);
            this.RB_weighed.TabIndex = 5;
            this.RB_weighed.TabStop = true;
            this.RB_weighed.Text = "Sveriamas";
            this.RB_weighed.UseVisualStyleBackColor = true;
            // 
            // RB_discrete
            // 
            this.RB_discrete.AutoSize = true;
            this.RB_discrete.Location = new System.Drawing.Point(434, 32);
            this.RB_discrete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RB_discrete.Name = "RB_discrete";
            this.RB_discrete.Size = new System.Drawing.Size(76, 19);
            this.RB_discrete.TabIndex = 6;
            this.RB_discrete.TabStop = true;
            this.RB_discrete.Text = "Vienetinis";
            this.RB_discrete.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(312, 80);
            this.textBoxAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(204, 23);
            this.textBoxAmount.TabIndex = 8;
            // 
            // submit_changes
            // 
            this.submit_changes.Location = new System.Drawing.Point(312, 224);
            this.submit_changes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.submit_changes.Name = "submit_changes";
            this.submit_changes.Size = new System.Drawing.Size(82, 26);
            this.submit_changes.TabIndex = 10;
            this.submit_changes.Text = "Patvirtinti";
            this.submit_changes.UseVisualStyleBackColor = true;
            this.submit_changes.Click += new System.EventHandler(this.submit_changes_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(312, 189);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 23);
            this.textBox1.TabIndex = 11;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 302);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.submit_changes);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.RB_discrete);
            this.Controls.Add(this.RB_weighed);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.bin);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form3";
            this.Text = "Produkto redagavimas";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bin;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.RadioButton RB_weighed;
        private System.Windows.Forms.RadioButton RB_discrete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Button submit_changes;
        private System.Windows.Forms.TextBox textBox1;
    }
}