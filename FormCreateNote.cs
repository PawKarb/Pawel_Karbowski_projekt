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
using System.Xml;
using System.Xml.Serialization;

namespace Pawel_Karbowski_projekt
{
    public partial class FormCreateNote : Form
    {
        private String nameOfCNote;
        private String dateOfCNote;
        private Importance importance;
        private Extension extension;
        private String textOfCNote;
        private Boolean isNotifiactionCNote = false;
        private String mainFolder = MainForm.rootFolder;
        private MainForm mainForm;
        private Note noteCreate;
        public FormCreateNote(MainForm mForm)
        {
            InitializeComponent();
            ComboBoxImportance.DataSource = Enum.GetValues(typeof(Importance));
            comboBoxExt.Text = "Wybierz rozszerzenie pliku...";
            comboBoxExt.Items.Add("plik tekstowy (.txt)");
            comboBoxExt.Items.Add("plik sformatowany (.rtf)");
            mainForm = mForm;
        }
        private void createNote()
        {
            String cfgFile = mainFolder + "\\noteConfig.xml";
            noteCreate = new Note(nameOfCNote, dateOfCNote, importance, extension, textOfCNote, isNotifiactionCNote);
            mainForm.saveNoteList(noteCreate);
            mainForm.ListSerializer();
            mainForm.AddListView(noteCreate);
        }
        private void saveFile() {
            String filePath = "";
            if (comboBoxExt.SelectedIndex == 0)
            {
                extension = Extension.TXT;
                filePath = mainFolder + "\\" + nameOfCNote + ".txt";
                if (!File.Exists(filePath))
                {
                    StreamWriter createLocalFile = new StreamWriter(filePath);
                    createLocalFile.Write(nameOfCNote, Encoding.UTF8);
                    createLocalFile.Close();
                    createNote();
                }
                else {                   
                    DialogResult dialogResult = MessageBox.Show("Notatka o podanej nazwie już istnieje. Chcesz ją utworzyć?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        while (File.Exists(filePath))
                        {
                            if (MainForm.iTxt != 0 && MainForm.numNotesTxt == 0)
                                nameOfCNote = nameOfCNote.Remove(nameOfCNote.Length - 1);
                            nameOfCNote += MainForm.iTxt;
                            filePath = mainFolder + "\\" + nameOfCNote + ".txt";
                            MainForm.iTxt++;
                        }
                        StreamWriter createLocalFile = new StreamWriter(filePath);
                        createLocalFile.Write(textOfCNote, Encoding.UTF8);
                        createLocalFile.Close();
                        MainForm.numNotesTxt++;
                        createNote();
                    }
                }
            }
            else if (comboBoxExt.SelectedIndex == 1)
            {
                extension = Extension.RTF;
                filePath = mainFolder + "\\" + nameOfCNote + ".rtf";
                if (!File.Exists(filePath))
                {
                    richTextNote.SaveFile(filePath, RichTextBoxStreamType.RichText);
                    createNote();
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Notatka o podanej nazwie już istnieje. Chcesz ją utworzyć?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        while (File.Exists(filePath))
                        {
                            if (MainForm.iRtf != 0 && MainForm.numNotesRtf == 0)
                                nameOfCNote = nameOfCNote.Remove(nameOfCNote.Length - 1);
                            nameOfCNote += MainForm.iRtf;
                            filePath = mainFolder + "\\" + nameOfCNote + ".rtf";
                            MainForm.iRtf++;
                        }
                        richTextNote.SaveFile(filePath, RichTextBoxStreamType.RichText);
                        MainForm.numNotesRtf++;
                        createNote();
                    }
                }
            }
            else 
            {
                DialogResult sprawdzenieExt = MessageBox.Show("Nie wybrano rozszerzenia pliku!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            

            if (!File.Exists(filePath))
            {
                DialogResult wynikDodania = MessageBox.Show("Błąd podczas tworzenia notatki!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult wynikDodania = MessageBox.Show("Notatka została utworzona");
                if (isNotifiactionCNote) {
                    if (DateTime.Parse(noteCreate.DateNote).Equals(DateTime.Today))
                    {
                        MessageBox.Show("Dzisiaj jest wydarzenie: " + noteCreate.Name, "Powiadomienie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (DateTime.Parse(noteCreate.DateNote).Equals(DateTime.Today.AddDays(1)))
                    {
                        MessageBox.Show("Jutro jest wydarzenie: " + noteCreate.Name, "Powiadomienie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.Close();
            }
        }
        private void btnCreateNote_Click(object sender, EventArgs e)
        {
            nameOfCNote = textBoxName.Text;
            dateOfCNote = datePickerNote.Value.ToShortDateString();
            importance = (Importance)Enum.Parse(typeof(Importance), ComboBoxImportance.Text);
            textOfCNote = richTextNote.Text;
            isNotifiactionCNote = notificationCheckBox.Checked;
            saveFile();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy napewno chcesz zakończyć tworzenie notatki?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
            richTextNote.SelectionFont = fontDialog.Font;
        }

        private void btnColorChange_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            richTextNote.SelectionColor = colorDialog.Color;
        }
    }
}
