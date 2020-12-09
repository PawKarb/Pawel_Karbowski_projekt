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
    public partial class FormEdit : Form
    {
        private string nameOfENote;
        private string dateOfENote;
        private Importance importance;
        private string textOfENote;
        private bool isNotifiactionENote;
        private Note noteEdit;
        private String fileEText;
        private String fileEName;
        private MainForm mainForm;
        private ListViewItem listViewEditItem;

        public FormEdit(Note _noteEdit, MainForm _mainForm, ListViewItem _listViewItem)
        {
            InitializeComponent();
            noteEdit = _noteEdit;
            mainForm = _mainForm;
            listViewEditItem = _listViewItem;
            comboBoxImportance.DataSource = Enum.GetValues(typeof(Importance));
            LoadNoteToEdit();
            LoadTextFromFile();
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
        private void LoadNoteToEdit() {
            textBoxEName.Text = noteEdit.Name;
            DateTime dtEdit = Convert.ToDateTime(noteEdit.DateNote);
            dateTimePickerENote.Value = dtEdit;
            comboBoxImportance.Text = noteEdit.importance.ToString();
            notificationCheckBox.Checked = noteEdit.IsNotification;
        }

        private void btnSaveNote_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy napewno chcesz nadpisać tą notatkę?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                nameOfENote = textBoxEName.Text;
                dateOfENote = dateTimePickerENote.Value.ToShortDateString();
                importance = (Importance)Enum.Parse(typeof(Importance), comboBoxImportance.Text);
                textOfENote = richTextBox1.Text;
                isNotifiactionENote = notificationCheckBox.Checked;
                Note noteCEdit = new Note(nameOfENote, dateOfENote, importance, noteEdit.extension, textOfENote, isNotifiactionENote);
                SaveEditNote(noteCEdit);
                this.Close();
            }
            else
            {
                return;
            }
        }
        private void LoadTextFromFile() {
            fileEName = MainForm.rootFolder + "\\" + noteEdit.Name + "." + noteEdit.extension;
            if (noteEdit.extension.Equals(Extension.TXT))
            {
                fileEText = File.ReadAllText(fileEName, Encoding.UTF8);
                richTextBox1.Text = fileEText;
            }
            else if (noteEdit.extension.Equals(Extension.RTF)) {
                richTextBox1.LoadFile(fileEName, RichTextBoxStreamType.RichText);
            }
        }
        private void SaveEditNote(Note saveNote) {
            if (noteEdit.extension.Equals(Extension.TXT))
            {
                StreamWriter createLocalFile = new StreamWriter(fileEName);
                createLocalFile.Write(textOfENote, Encoding.UTF8);
                createLocalFile.Close();
            }
            else if (noteEdit.extension.Equals(Extension.RTF))
            {
                richTextBox1.SaveFile(fileEName, RichTextBoxStreamType.RichText);
            }
            mainForm.RemoveListView(listViewEditItem);
            mainForm.delNoteList(noteEdit);
            mainForm.saveNoteList(saveNote);
            mainForm.AddListView(saveNote);
            mainForm.ListSerializer();
        }
    }
}
