
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
            this.search_bar = new System.Windows.Forms.TextBox();
            this.writing_to_file = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lv_offer
            // 
            this.lv_offer.AllowColumnReorder = true;
            this.lv_offer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_offer.BackColor = System.Drawing.SystemColors.Menu;
            this.lv_offer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pr_name,
            this.pr_description,
            this.pr_price,
            this.pr_expiration});
            this.lv_offer.FullRowSelect = true;
            this.lv_offer.HideSelection = false;
            this.lv_offer.Location = new System.Drawing.Point(46, 100);
            this.lv_offer.MultiSelect = false;
            this.lv_offer.Name = "lv_offer";
            this.lv_offer.Size = new System.Drawing.Size(847, 313);
            this.lv_offer.TabIndex = 0;
            this.lv_offer.UseCompatibleStateImageBehavior = false;
            this.lv_offer.View = System.Windows.Forms.View.Details;
            this.lv_offer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_offer_MouseDoubleClick);
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
            this.add_new_offer.AutoEllipsis = true;
            this.add_new_offer.Location = new System.Drawing.Point(46, 39);
            this.add_new_offer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.add_new_offer.Name = "add_new_offer";
            this.add_new_offer.Size = new System.Drawing.Size(168, 33);
            this.add_new_offer.TabIndex = 1;
            this.add_new_offer.Text = "Pridėti pasiūlymą";
            this.add_new_offer.UseVisualStyleBackColor = true;
            this.add_new_offer.Click += new System.EventHandler(this.add_new_offer_Click);
            // 
            // remove_offer
            // 
            this.remove_offer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remove_offer.Location = new System.Drawing.Point(764, 39);
            this.remove_offer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.remove_offer.Name = "remove_offer";
            this.remove_offer.Size = new System.Drawing.Size(129, 33);
            this.remove_offer.TabIndex = 2;
            this.remove_offer.Text = "Ištrinti visus";
            this.remove_offer.UseVisualStyleBackColor = true;
            this.remove_offer.Click += new System.EventHandler(this.remove_offer_Click);
            // 
            // add_file_offer
            // 
            this.add_file_offer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.add_file_offer.Location = new System.Drawing.Point(46, 446);
            this.add_file_offer.Name = "add_file_offer";
            this.add_file_offer.Size = new System.Drawing.Size(158, 31);
            this.add_file_offer.TabIndex = 3;
            this.add_file_offer.Text = "Įkelti pasiūlymą iš failo";
            this.add_file_offer.UseVisualStyleBackColor = true;
            this.add_file_offer.Click += new System.EventHandler(this.add_file_offer_Click_1);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "Pavadinimą nuo A iki Z",
            "Pavadinimą nuo Z iki A",
            "Kainą didėjančiai",
            "Kainą mažėjančiai",
            "Galiojimo datą didėjančiai",
            "Galiojimo datą mažėjančiai"});
            this.comboBoxSort.Location = new System.Drawing.Point(595, 446);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(189, 28);
            this.comboBoxSort.TabIndex = 4;
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // buttonSort
            // 
            this.buttonSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSort.Location = new System.Drawing.Point(803, 446);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(90, 31);
            this.buttonSort.TabIndex = 5;
            this.buttonSort.Text = "Rūšiuoti";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rūšiuoti pagal:";
            // 
            // search_bar
            // 
            this.search_bar.Location = new System.Drawing.Point(240, 39);
            this.search_bar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.search_bar.Name = "search_bar";
            this.search_bar.PlaceholderText = "Ieškoti...";
            this.search_bar.Size = new System.Drawing.Size(445, 27);
            this.search_bar.TabIndex = 4;
            this.search_bar.TextChanged += new System.EventHandler(this.search_bar_TextChanged);
            // 
            // writing_to_file
            // 
            this.writing_to_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.writing_to_file.Location = new System.Drawing.Point(224, 446);
            this.writing_to_file.Name = "writing_to_file";
            this.writing_to_file.Size = new System.Drawing.Size(160, 31);
            this.writing_to_file.TabIndex = 7;
            this.writing_to_file.Text = "Surašyti viską į failą";
            this.writing_to_file.UseVisualStyleBackColor = true;
            this.writing_to_file.Click += new System.EventHandler(this.writing_to_file_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(925, 495);
            this.Controls.Add(this.writing_to_file);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.search_bar);
            this.Controls.Add(this.add_file_offer);
            this.Controls.Add(this.remove_offer);
            this.Controls.Add(this.add_new_offer);
            this.Controls.Add(this.lv_offer);
            this.Name = "Form1";
            this.Text = "Left Over";
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
        private System.Windows.Forms.TextBox search_bar;
        private System.Windows.Forms.Button writing_to_file;
    }
}

