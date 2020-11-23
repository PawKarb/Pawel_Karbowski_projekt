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
    public partial class MainForm : Form, IListOfNotes
    {
        public List<Note> ListofNotes = new List<Note>();
        private String rootFolder;
        private String cfgFile;
        private FormCreateNote createNote;
        private FormEdit formEdit;
        private FormOpen formOpen;
        private FormNotification formNotification;
        public static int iTxt, iRtf, liczbaNotatekRtf,liczbaNotatekTxt;
        public MainForm()
        {
            InitializeComponent();
            rootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Notatki_projekt");
            cfgFile = rootFolder + "\\noteConfig.xml";
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            if (!File.Exists(cfgFile))
            {
                var myFile = File.Create(cfgFile);
                myFile.Close();
            }
            else if (new FileInfo(cfgFile).Length != 0)
            {
                Stream xmlReader = new FileStream(cfgFile, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Note>), new XmlRootAttribute("Notes"));
                ListofNotes = (List<Note>)serializer.Deserialize(xmlReader);
                addNoteListBox();
                xmlReader.Close();
            }

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            createNote = new FormCreateNote(this);
            createNote.Show();

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                formOpen = new FormOpen();
                formOpen.Show();
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy chcesz wyjść z programu?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listViewNote.SelectedItems.Count > 0)
            {
                formEdit = new FormEdit();
                formEdit.Show();
            }
            else
            {
                MessageBox.Show("Nie zaznaczono elementu!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNotif_Click(object sender, EventArgs e)
        {
            formNotification = new FormNotification();
            formNotification.Show();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(rootFolder);
        }
        public void saveNoteList(Note note)
        {
            ListofNotes.Add(note);
        }
        private void addNoteListBox()
        {
            foreach (Note lnote in ListofNotes)
            {
                AddListView(lnote);
            }
        }

        public void delNoteList(Note note)
        {
            throw new NotImplementedException();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewNote.SelectedItems.Count > 0)
            {
                return;
            }
            else
            {
                MessageBox.Show("Nie zaznaczono elementu!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (listViewNote.Items.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Czy chcesz usunąć wszystkie elementy z listy?", "Błąd!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    return;
                }
            }
        }
        public void AddListView(Note lvnote)
        {
            switch (lvnote.importance)
            {
                case Importance.BRAK:
                    {
                        listViewNote.Items.Insert(0, lvnote.name);
                        listViewNote.Items[0].ForeColor = Color.Black;
                        break;
                    }
                case Importance.NAJWAZNIEJSZY:
                    {
                        listViewNote.Items.Insert(0, lvnote.name);
                        listViewNote.Items[0].ForeColor = Color.Red;
                        break;
                    }
                case Importance.OPCJONALNY:
                    {
                        listViewNote.Items.Insert(0, lvnote.name);
                        listViewNote.Items[0].ForeColor = Color.Green;
                        break;
                    }
                case Importance.PILNY:
                    {
                        listViewNote.Items.Insert(0, lvnote.name);
                        listViewNote.Items[0].ForeColor = Color.Orange;
                        break;
                    }
                case Importance.STANDARDOWY:
                    {
                        listViewNote.Items.Insert(0, lvnote.name);
                        listViewNote.Items[0].ForeColor = Color.Blue;
                        break;
                    }
            }
        }

    }
}
