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
    public partial class MainForm : Form
    {
        public static List<Note> ListofNotes = new List<Note>();
        private String rootFolder;
        private String cfgFile;
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
                File.Create(cfgFile);
            }
        }
        public static void saveNoteInList(Note note) {
            ListofNotes.Add(note);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            FormCreateNote noteForm = new FormCreateNote();
            noteForm.Show();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                FormOpen openForm = new FormOpen();
                openForm.Show();
            }
            catch(ObjectDisposedException) {
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
            FormEdit formEdit = new FormEdit();
            formEdit.Show();
        }

        private void btnNotif_Click(object sender, EventArgs e)
        {
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(rootFolder);
        }
    }
}
