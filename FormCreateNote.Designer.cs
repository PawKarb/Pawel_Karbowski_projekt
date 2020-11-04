namespace Pawel_Karbowski_projekt
{
    partial class FormCreateNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateNote));
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.datePickerNote = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBoxImportance = new System.Windows.Forms.ComboBox();
            this.richTextNote = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.notificationCheckBox = new System.Windows.Forms.CheckBox();
            this.btnCreateNote = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnFontChange = new System.Windows.Forms.Button();
            this.btnColorChange = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.comboBoxExt = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxName.Location = new System.Drawing.Point(91, 32);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(202, 22);
            this.textBoxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(160, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nazwa";
            // 
            // datePickerNote
            // 
            this.datePickerNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datePickerNote.Location = new System.Drawing.Point(91, 78);
            this.datePickerNote.Name = "datePickerNote";
            this.datePickerNote.Size = new System.Drawing.Size(202, 20);
            this.datePickerNote.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(165, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(151, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ważność";
            // 
            // ComboBoxImportance
            // 
            this.ComboBoxImportance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ComboBoxImportance.FormattingEnabled = true;
            this.ComboBoxImportance.Location = new System.Drawing.Point(91, 124);
            this.ComboBoxImportance.Name = "ComboBoxImportance";
            this.ComboBoxImportance.Size = new System.Drawing.Size(202, 23);
            this.ComboBoxImportance.TabIndex = 5;
            // 
            // richTextNote
            // 
            this.richTextNote.Location = new System.Drawing.Point(12, 238);
            this.richTextNote.Name = "richTextNote";
            this.richTextNote.Size = new System.Drawing.Size(360, 416);
            this.richTextNote.TabIndex = 6;
            this.richTextNote.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(160, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Treść";
            // 
            // notificationCheckBox
            // 
            this.notificationCheckBox.AutoSize = true;
            this.notificationCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.notificationCheckBox.Location = new System.Drawing.Point(78, 660);
            this.notificationCheckBox.Name = "notificationCheckBox";
            this.notificationCheckBox.Size = new System.Drawing.Size(215, 24);
            this.notificationCheckBox.TabIndex = 8;
            this.notificationCheckBox.Text = "Ustaw jako powiadomienie";
            this.notificationCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnCreateNote
            // 
            this.btnCreateNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCreateNote.Location = new System.Drawing.Point(12, 690);
            this.btnCreateNote.Name = "btnCreateNote";
            this.btnCreateNote.Size = new System.Drawing.Size(125, 59);
            this.btnCreateNote.TabIndex = 9;
            this.btnCreateNote.Text = "Stwórz";
            this.btnCreateNote.UseVisualStyleBackColor = true;
            this.btnCreateNote.Click += new System.EventHandler(this.btnCreateNote_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.Location = new System.Drawing.Point(247, 690);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 59);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Wróć";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnFontChange
            // 
            this.btnFontChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFontChange.Location = new System.Drawing.Point(12, 208);
            this.btnFontChange.Name = "btnFontChange";
            this.btnFontChange.Size = new System.Drawing.Size(80, 24);
            this.btnFontChange.TabIndex = 14;
            this.btnFontChange.Text = "Czcionka";
            this.btnFontChange.UseVisualStyleBackColor = true;
            this.btnFontChange.Click += new System.EventHandler(this.btnFontChange_Click);
            // 
            // btnColorChange
            // 
            this.btnColorChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnColorChange.Location = new System.Drawing.Point(292, 208);
            this.btnColorChange.Name = "btnColorChange";
            this.btnColorChange.Size = new System.Drawing.Size(80, 24);
            this.btnColorChange.TabIndex = 15;
            this.btnColorChange.Text = "Kolor";
            this.btnColorChange.UseVisualStyleBackColor = true;
            this.btnColorChange.Click += new System.EventHandler(this.btnColorChange_Click);
            // 
            // comboBoxExt
            // 
            this.comboBoxExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxExt.FormattingEnabled = true;
            this.comboBoxExt.Location = new System.Drawing.Point(91, 173);
            this.comboBoxExt.Name = "comboBoxExt";
            this.comboBoxExt.Size = new System.Drawing.Size(202, 23);
            this.comboBoxExt.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(136, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Rozszerzenie";
            // 
            // FormCreateNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 761);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxExt);
            this.Controls.Add(this.btnColorChange);
            this.Controls.Add(this.btnFontChange);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCreateNote);
            this.Controls.Add(this.notificationCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextNote);
            this.Controls.Add(this.ComboBoxImportance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datePickerNote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 800);
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "FormCreateNote";
            this.Text = "Tworzenie Notatki";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePickerNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBoxImportance;
        private System.Windows.Forms.RichTextBox richTextNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox notificationCheckBox;
        private System.Windows.Forms.Button btnCreateNote;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnFontChange;
        private System.Windows.Forms.Button btnColorChange;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ComboBox comboBoxExt;
        private System.Windows.Forms.Label label5;
    }
}