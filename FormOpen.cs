using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pawel_Karbowski_projekt
{
    public partial class FormOpen : Form
    {
        private OpenFileDialog openFileDialog;
        private string fileExt = "";
        private string rootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Notatki_projekt");
        public FormOpen()
        {
            InitializeComponent();
            OpenFile();
            richTextBox1.SelectionColor = Color.Black;
        }
        private void OpenFile() {
            openFileDialog = new OpenFileDialog();
            string fileText = "";
            openFileDialog.InitialDirectory = rootFolder;
            openFileDialog.Filter = "rtf files(*.rtf)|*.rtf|txt files(*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog.FileName.Length > 0)
            {
                fileExt = Path.GetExtension(openFileDialog.FileName);
                if (fileExt == ".txt")
                {
                    fileText = File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);
                    richTextBox1.Text = fileText;
                }
                else if (fileExt == ".rtf")
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);        
            }
            else
            {
                this.Close();
            }
        }

        private void btnCreateNote_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy napewno chcesz nadpisać ten plik?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            else
            {
                if (fileExt == ".txt")
                {
                    StreamWriter openLocalFile = new StreamWriter(openFileDialog.FileName);
                    openLocalFile.Write(richTextBox1.Text, Encoding.UTF8);
                    openLocalFile.Close();
                }
                else if (fileExt == ".rtf")
                    richTextBox1.SaveFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy napewno chcesz zakończyć edycję notatki?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void btnOpenNext_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnFontChange_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            richTextBox1.SelectionFont = fontDialog.Font;
        }

        private void btnColorChange_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            richTextBox1.SelectionColor = colorDialog.Color;
        }
    }
}
