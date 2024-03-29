﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Pawel_Karbowski_projekt
{
    public partial class MainForm : Form, IListOfNotes,ISerializer,IListView
    {
        public List<Note> ListOfNotes = new List<Note>();
        public static List<Note> listOfNotesNot = new List<Note>();
        public static String rootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Notatki_projekt");
        private String cfgFile;
        private FormCreateNote createNote;
        private FormEdit formEdit;
        private FormOpen formOpen;
        private FormNotification formNotification;
        public static int iTxt, iRtf,numNotesRtf,numNotesTxt;
        private int numberOfNotes = 0;
        public MainForm()
        {
            InitializeComponent();
            listBoxImportance.DataSource = Enum.GetValues(typeof(Importance));
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
                ListDeserializer();
                addNoteListView();
                checkNotification();
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
                String n = listViewNote.SelectedItems[0].Text;
                Extension ext = (Extension)Enum.Parse(typeof(Extension), listViewNote.SelectedItems[0].SubItems[1].Text);
                String fileNameEdit = rootFolder + "\\" + n + "." + ext;
                if (File.Exists(fileNameEdit))
                {
                    var itemEdit = listViewNote.SelectedItems[0];
                    foreach (Note lnote in ListOfNotes)
                    {
                        if (lnote.Name.Equals(n) && lnote.extension.Equals(ext))
                        {
                            formEdit = new FormEdit(lnote, this, itemEdit);
                            break;
                        }
                    }
                    formEdit.Show();
                }
                else {
                    MessageBox.Show("Plik nie istnieje!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczono elementu!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNotif_Click(object sender, EventArgs e)
        {
            if (listOfNotesNot.Any())
            {
                formNotification = new FormNotification(this);
                formNotification.Show();
            }
            else {
                MessageBox.Show("Brak powiadomień!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(rootFolder);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewNote.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Czy chcesz usunąć tą notatkę?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    var item = listViewNote.SelectedItems[0];
                    String n = listViewNote.SelectedItems[0].Text;
                    Extension ext = (Extension)Enum.Parse(typeof(Extension), listViewNote.SelectedItems[0].SubItems[1].Text);
                    foreach (Note lnote in ListOfNotes)
                    {
                        if (lnote.Name.Equals(n) && lnote.extension.Equals(ext))
                        {
                            delNoteList(lnote);
                            break;
                        }
                    }
                    RemoveListView(item);
                    File.Delete(rootFolder + "\\" + n + "." + ext.ToString());
                    ListSerializer();
                }
                else
                {
                    return;
                }
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
                if (dialogResult == DialogResult.Yes)
                {
                    string[] filePaths = Directory.GetFiles(rootFolder);
                    foreach (string filePath in filePaths)
                    {
                        if(!filePath.Equals(cfgFile))
                            File.Delete(filePath);
                    }
                    ListOfNotes.Clear();
                    listOfNotesNot.Clear();
                    listViewNote.Items.Clear();
                    ListSerializer();
                    numberOfNotes = 0;
                }
                else
                {
                    return;
                }
            }
        }
        public void AddListView(Note lvnote)
        {
            var item = new ListViewItem(new[] { lvnote.Name,  lvnote.extension.ToString()});
            switch (lvnote.importance)
            {
                case Importance.BRAK:
                    {
                        listViewNote.Items.Add(item);
                        listViewNote.Items[numberOfNotes].ForeColor = Color.Black;
                        break;
                    }
                case Importance.NAJWAZNIEJSZY:
                    {
                        listViewNote.Items.Add(item);
                        listViewNote.Items[numberOfNotes].ForeColor = Color.Red;
                        break;
                    }
                case Importance.OPCJONALNY:
                    {
                        listViewNote.Items.Add(item);
                        listViewNote.Items[numberOfNotes].ForeColor = Color.Green;
                        break;
                    }
                case Importance.PILNY:
                    {
                        listViewNote.Items.Add(item);
                        listViewNote.Items[numberOfNotes].ForeColor = Color.Orange;
                        break;
                    }
                case Importance.STANDARDOWY:
                    {
                        listViewNote.Items.Add(item);
                        listViewNote.Items[numberOfNotes].ForeColor = Color.Blue;
                        break;
                    }
            }
            numberOfNotes++;
        }
        public void RemoveListView(ListViewItem listViewItem) {
            listViewItem.Remove();
        }
        public void addNoteListView()
        {
            foreach (Note lnote in ListOfNotes)
            {
                AddListView(lnote);
            }
        }
        public void ListSerializer()
        {
            TextWriter writeFileCfg = new StreamWriter(cfgFile);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Note>), new XmlRootAttribute("Notes"));
            serializer.Serialize(writeFileCfg, ListOfNotes);
            writeFileCfg.Close();
        }

        public void ListDeserializer()
        {
            Stream xmlReader = new FileStream(cfgFile, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Note>), new XmlRootAttribute("Notes"));
            ListOfNotes = (List<Note>)serializer.Deserialize(xmlReader);
            addNoteListNotif();
            xmlReader.Close();
        }

        public void saveNoteList(Note note)
        {
            ListOfNotes.Add(note);
            if (note.IsNotification) {
                listOfNotesNot.Add(note);
            }
        }
        public void delNoteList(Note note)
        {
            ListOfNotes.Remove(note);
            listOfNotesNot.Remove(note);
            numberOfNotes--;
        }
        public void addNoteListNotif() {
            foreach (Note ntNote in ListOfNotes) {
                if (ntNote.IsNotification) {
                    listOfNotesNot.Add(ntNote);
                }
            }
            listOfNotesNot.OrderBy(x => DateTime.Parse(x.DateNote));
        }
        public void checkNotification() {
            foreach (Note lnote in listOfNotesNot) {
                if (DateTime.Parse(lnote.DateNote).Equals(DateTime.Today))
                {
                    MessageBox.Show("Dzisiaj jest wydarzenie: " + lnote.Name, "Powiadomienie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (DateTime.Parse(lnote.DateNote).Equals(DateTime.Today.AddDays(1))) {
                    MessageBox.Show("Jutro jest wydarzenie: " + lnote.Name, "Powiadomienie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }
    }

}
