
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
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxExpiration = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bin
            // 
            this.bin.Location = new System.Drawing.Point(496, 299);
            this.bin.Name = "bin";
            this.bin.Size = new System.Drawing.Size(94, 35);
            this.bin.TabIndex = 0;
            this.bin.Text = "Į šiukšlinę";
            this.bin.UseVisualStyleBackColor = true;
            this.bin.Click += new System.EventHandler(this.bin_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(41, 43);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(257, 27);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(41, 252);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(257, 27);
            this.textBoxPrice.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(41, 107);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(257, 101);
            this.textBoxDescription.TabIndex = 4;
            // 
            // RB_weighed
            // 
            this.RB_weighed.AutoSize = true;
            this.RB_weighed.Location = new System.Drawing.Point(357, 43);
            this.RB_weighed.Name = "RB_weighed";
            this.RB_weighed.Size = new System.Drawing.Size(97, 24);
            this.RB_weighed.TabIndex = 5;
            this.RB_weighed.TabStop = true;
            this.RB_weighed.Text = "Sveriamas";
            this.RB_weighed.UseVisualStyleBackColor = true;
            // 
            // RB_discrete
            // 
            this.RB_discrete.AutoSize = true;
            this.RB_discrete.Location = new System.Drawing.Point(496, 43);
            this.RB_discrete.Name = "RB_discrete";
            this.RB_discrete.Size = new System.Drawing.Size(94, 24);
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
            this.textBoxAmount.Location = new System.Drawing.Point(357, 107);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(233, 27);
            this.textBoxAmount.TabIndex = 8;
            // 
            // submit_changes
            // 
            this.submit_changes.Location = new System.Drawing.Point(357, 299);
            this.submit_changes.Name = "submit_changes";
            this.submit_changes.Size = new System.Drawing.Size(94, 35);
            this.submit_changes.TabIndex = 10;
            this.submit_changes.Text = "Patvirtinti";
            this.submit_changes.UseVisualStyleBackColor = true;
            this.submit_changes.Click += new System.EventHandler(this.submit_changes_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Default",
            "Vegetables",
            "Fruits",
            "Fish and Seafood",
            "Meat and Poultry",
            "Dairy",
            "Grains Beans and Nuts",
            "Sweets",
            "Soups",
            "Meals",
            "Bakery",
            "Confectionery",
            "Other"});
            this.comboBoxType.Location = new System.Drawing.Point(357, 252);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(233, 28);
            this.comboBoxType.TabIndex = 11;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Produkto pavadinimas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Aprašymas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Kaina";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Produkto kiekybinis tipas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(357, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Kiekis";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Kategorija";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(357, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Galiojimo dienos";
            // 
            // textBoxExpiration
            // 
            this.textBoxExpiration.Location = new System.Drawing.Point(357, 181);
            this.textBoxExpiration.Name = "textBoxExpiration";
            this.textBoxExpiration.Size = new System.Drawing.Size(233, 27);
            this.textBoxExpiration.TabIndex = 19;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 403);
            this.Controls.Add(this.textBoxExpiration);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.submit_changes);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.RB_discrete);
            this.Controls.Add(this.RB_weighed);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.bin);
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
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxExpiration;
    }
}