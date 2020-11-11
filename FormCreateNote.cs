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
        private String waznoscNotatki;
        private String tekstNotatki;
        private Boolean powiadomienie = false;
        private String rootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Notatki_projekt");
        private MainForm mainForm;
        public FormCreateNote(MainForm mForm)
        {
            InitializeComponent();
            ComboBoxImportance.DataSource = Enum.GetValues(typeof(importance));
            comboBoxExt.Text = "Wybierz rozszerzenie pliku...";
            comboBoxExt.Items.Add("plik tekstowy (.txt)");
            comboBoxExt.Items.Add("plik sformatowany (.rtf)");
            mainForm = mForm;
    }
        private void saveFile() {
            String filePath = "";
            if (comboBoxExt.SelectedIndex == 0)
            {
                filePath = rootFolder + "\\" + nazwaNotatki + ".txt";
                StreamWriter createLocalFile = new StreamWriter(filePath);
                createLocalFile.WriteLine("Ważność notatki: " + waznoscNotatki, Encoding.UTF8);
                createLocalFile.WriteLine(dataNotatki, Encoding.UTF8);
                createLocalFile.Write(tekstNotatki, Encoding.UTF8);
                createLocalFile.Close();
            }
            else if (comboBoxExt.SelectedIndex == 1)
            {
                filePath = rootFolder + "\\" + nazwaNotatki + ".rtf";
                richTextNote.SaveFile(filePath, RichTextBoxStreamType.RichText);
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
            String cfgFile = rootFolder + "\\noteConfig.xml";
            nazwaNotatki = textBoxName.Text;
            dataNotatki = datePickerNote.Value.ToShortDateString();
            waznoscNotatki = ComboBoxImportance.Text;
            tekstNotatki = richTextNote.Text;
            powiadomienie = notificationCheckBox.Checked;

            //tworzenie obiektu i dodawanie do listy
            Note notatka = new Note(nazwaNotatki, dataNotatki, waznoscNotatki, tekstNotatki, powiadomienie);
            mainForm.saveNoteInList(notatka);
            TextWriter writeFileCfg = new StreamWriter(cfgFile);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Note>), new XmlRootAttribute("Notes"));
            serializer.Serialize(writeFileCfg, mainForm.ListofNotes);
            writeFileCfg.Close();
            mainForm.NoteListBox.Items.Insert(0,notatka.name);
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
