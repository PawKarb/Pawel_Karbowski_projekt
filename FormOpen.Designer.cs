namespace Pawel_Karbowski_projekt
{
    partial class FormOpen
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnCreateNote = new System.Windows.Forms.Button();
            this.btnOpenNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.btnFontChange = new System.Windows.Forms.Button();
            this.btnColorChange = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 42);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(560, 635);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnCreateNote
            // 
            this.btnCreateNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCreateNote.Location = new System.Drawing.Point(12, 690);
            this.btnCreateNote.Name = "btnCreateNote";
            this.btnCreateNote.Size = new System.Drawing.Size(175, 59);
            this.btnCreateNote.TabIndex = 10;
            this.btnCreateNote.Text = "Zapisz";
            this.btnCreateNote.UseVisualStyleBackColor = true;
            this.btnCreateNote.Click += new System.EventHandler(this.btnCreateNote_Click);
            // 
            // btnOpenNext
            // 
            this.btnOpenNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOpenNext.Location = new System.Drawing.Point(207, 690);
            this.btnOpenNext.Name = "btnOpenNext";
            this.btnOpenNext.Size = new System.Drawing.Size(175, 59);
            this.btnOpenNext.TabIndex = 11;
            this.btnOpenNext.Text = "Otwórz inny";
            this.btnOpenNext.UseVisualStyleBackColor = true;
            this.btnOpenNext.Click += new System.EventHandler(this.btnOpenNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.Location = new System.Drawing.Point(398, 690);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(175, 59);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Wróć";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // fontDialog
            // 
            this.fontDialog.ShowApply = true;
            // 
            // btnFontChange
            // 
            this.btnFontChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFontChange.Location = new System.Drawing.Point(12, 12);
            this.btnFontChange.Name = "btnFontChange";
            this.btnFontChange.Size = new System.Drawing.Size(80, 24);
            this.btnFontChange.TabIndex = 13;
            this.btnFontChange.Text = "Czcionka";
            this.btnFontChange.UseVisualStyleBackColor = true;
            this.btnFontChange.Click += new System.EventHandler(this.btnFontChange_Click);
            // 
            // btnColorChange
            // 
            this.btnColorChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnColorChange.Location = new System.Drawing.Point(492, 12);
            this.btnColorChange.Name = "btnColorChange";
            this.btnColorChange.Size = new System.Drawing.Size(80, 24);
            this.btnColorChange.TabIndex = 14;
            this.btnColorChange.Text = "Kolor";
            this.btnColorChange.UseVisualStyleBackColor = true;
            this.btnColorChange.Click += new System.EventHandler(this.btnColorChange_Click);
            // 
            // FormOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 761);
            this.Controls.Add(this.btnColorChange);
            this.Controls.Add(this.btnFontChange);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOpenNext);
            this.Controls.Add(this.btnCreateNote);
            this.Controls.Add(this.richTextBox1);
            this.MaximumSize = new System.Drawing.Size(600, 800);
            this.MinimumSize = new System.Drawing.Size(600, 800);
            this.Name = "FormOpen";
            this.Text = "Otwórz";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnCreateNote;
        private System.Windows.Forms.Button btnOpenNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button btnFontChange;
        private System.Windows.Forms.Button btnColorChange;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}