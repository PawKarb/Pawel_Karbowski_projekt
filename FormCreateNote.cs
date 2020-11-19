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
        private String nazwaNotatki;
        private String dataNotatki;
        private Importance importance;
        private String tekstNotatki;
        private Boolean powiadomienie = false;
        private String rootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Notatki_projekt");
        private MainForm mainForm;
        private Note notatka;
        public FormCreateNote(MainForm mForm)
        {
            InitializeComponent();
            ComboBoxImportance.DataSource = Enum.GetValues(typeof(Importance));
            comboBoxExt.Text = "Wybierz rozszerzenie pliku...";
            comboBoxExt.Items.Add("plik tekstowy (.txt)");
            comboBoxExt.Items.Add("plik sformatowany (.rtf)");
            mainForm = mForm;
        }
        private void createNote() {
            String cfgFile = rootFolder + "\\noteConfig.xml";
            notatka = new Note(nazwaNotatki, dataNotatki, importance, tekstNotatki, powiadomienie);
            mainForm.saveNoteList(notatka);
            TextWriter writeFileCfg = new StreamWriter(cfgFile);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Note>), new XmlRootAttribute("Notes"));
            serializer.Serialize(writeFileCfg, mainForm.ListofNotes);
            writeFileCfg.Close();
            mainForm.NoteListBox.Items.Insert(0, notatka.name);
        }
        private void saveFile() {
            String filePath = "";
            if (comboBoxExt.SelectedIndex == 0)
            {
                filePath = rootFolder + "\\" + nazwaNotatki + ".txt";
                StreamWriter createLocalFile = new StreamWriter(filePath);
                createLocalFile.WriteLine("Ważność notatki: " + importance, Encoding.UTF8);
                createLocalFile.WriteLine(dataNotatki, Encoding.UTF8);
                createLocalFile.Write(tekstNotatki, Encoding.UTF8);
                createLocalFile.Close();
                createNote();
            }
            else if (comboBoxExt.SelectedIndex == 1)
            {
                filePath = rootFolder + "\\" + nazwaNotatki + ".rtf";
                richTextNote.SaveFile(filePath, RichTextBoxStreamType.RichText);
                createNote();
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
                this.Close();
            }
        }
        private void btnCreateNote_Click(object sender, EventArgs e)
        {
            nazwaNotatki = textBoxName.Text;
            dataNotatki = datePickerNote.Value.ToShortDateString();
            importance = (Importance)Enum.Parse(typeof(Importance), ComboBoxImportance.Text);
            tekstNotatki = richTextNote.Text;
            powiadomienie = notificationCheckBox.Checked;
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
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            richTextNote.SelectionColor = colorDialog.Color;
        }

        private void btnColorChange_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            richTextNote.SelectionColor = colorDialog.Color;
        }
    }
}
