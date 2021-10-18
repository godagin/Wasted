
namespace Wasted
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lv_offer = new System.Windows.Forms.ListView();
            this.pr_name = new System.Windows.Forms.ColumnHeader();
            this.pr_description = new System.Windows.Forms.ColumnHeader();
            this.pr_price = new System.Windows.Forms.ColumnHeader();
            this.pr_expiration = new System.Windows.Forms.ColumnHeader();
            this.add_new_offer = new System.Windows.Forms.Button();
            this.remove_offer = new System.Windows.Forms.Button();
            this.add_file_offer = new System.Windows.Forms.Button();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.buttonSort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lv_offer
            // 
            this.lv_offer.AllowColumnReorder = true;
            this.lv_offer.BackColor = System.Drawing.SystemColors.Menu;
            this.lv_offer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pr_name,
            this.pr_description,
            this.pr_price,
            this.pr_expiration});
            this.lv_offer.FullRowSelect = true;
            this.lv_offer.HideSelection = false;
            this.lv_offer.Location = new System.Drawing.Point(46, 96);
            this.lv_offer.Name = "lv_offer";
            this.lv_offer.Size = new System.Drawing.Size(693, 319);
            this.lv_offer.TabIndex = 0;
            this.lv_offer.UseCompatibleStateImageBehavior = false;
            this.lv_offer.View = System.Windows.Forms.View.Details;
            this.lv_offer.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lv_offer_ItemSelectionChanged);
            // 
            // pr_name
            // 
            this.pr_name.Text = "Produkto pavadinimas";
            this.pr_name.Width = 180;
            // 
            // pr_description
            // 
            this.pr_description.Text = "Aprašymas";
            this.pr_description.Width = 270;
            // 
            // pr_price
            // 
            this.pr_price.Text = "Kaina";
            this.pr_price.Width = 90;
            // 
            // pr_expiration
            // 
            this.pr_expiration.Text = "Galiojimo pabaiga";
            this.pr_expiration.Width = 150;
            // 
            // add_new_offer
            // 
            this.add_new_offer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.add_new_offer.AutoEllipsis = true;
            this.add_new_offer.Location = new System.Drawing.Point(46, 32);
            this.add_new_offer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.add_new_offer.Name = "add_new_offer";
            this.add_new_offer.Size = new System.Drawing.Size(191, 40);
            this.add_new_offer.TabIndex = 1;
            this.add_new_offer.Text = "Pridėti pasiūlymą";
            this.add_new_offer.UseVisualStyleBackColor = true;
            this.add_new_offer.Click += new System.EventHandler(this.add_new_offer_Click);
            // 
            // remove_offer
            // 
            this.remove_offer.Location = new System.Drawing.Point(608, 32);
            this.remove_offer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.remove_offer.Name = "remove_offer";
            this.remove_offer.Size = new System.Drawing.Size(131, 40);
            this.remove_offer.TabIndex = 2;
            this.remove_offer.Text = "Ištrinti visus";
            this.remove_offer.UseVisualStyleBackColor = true;
            this.remove_offer.Click += new System.EventHandler(this.remove_offer_Click);
            // 
            // add_file_offer
            // 
            this.add_file_offer.Location = new System.Drawing.Point(31, 421);
            this.add_file_offer.Name = "add_file_offer";
            this.add_file_offer.Size = new System.Drawing.Size(183, 29);
            this.add_file_offer.TabIndex = 3;
            this.add_file_offer.Text = "Įkelti pasiūlymą iš failo";
            this.add_file_offer.UseVisualStyleBackColor = true;
            this.add_file_offer.Click += new System.EventHandler(this.add_file_offer_Click_1);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "Pavadinimą nuo A iki Z",
            "Pavadinimą nuo Z iki A",
            "Kainą didėjančiai",
            "Kainą mažėjančiai",
            "Galiojimo datą didėjančiai",
            "Galiojimo datą mažėjančiai"});
            this.comboBoxSort.Location = new System.Drawing.Point(439, 420);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(189, 28);
            this.comboBoxSort.TabIndex = 4;
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(645, 419);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(94, 29);
            this.buttonSort.TabIndex = 5;
            this.buttonSort.Text = "Rūšiuoti";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rūšiuoti pagal:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(785, 451);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.add_file_offer);
            this.Controls.Add(this.remove_offer);
            this.Controls.Add(this.add_new_offer);
            this.Controls.Add(this.lv_offer);
            this.Name = "Form1";
            this.Text = "Wasteless";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_offer;
        private System.Windows.Forms.Button add_new_offer;
        private System.Windows.Forms.ColumnHeader pr_name;
        private System.Windows.Forms.ColumnHeader pr_description;
        private System.Windows.Forms.ColumnHeader pr_price;
        private System.Windows.Forms.Button remove_offer;

        private System.Windows.Forms.ColumnHeader pr_expiration;

        private System.Windows.Forms.Button add_file_offer;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Label label1;
    }
}

