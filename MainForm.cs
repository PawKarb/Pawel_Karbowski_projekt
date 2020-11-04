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
        public MainForm()
        {
            InitializeComponent();
            String rootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Notatki_projekt");
            String cfgFile = rootFolder + "\\noteConfig.xml";
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
            if (!File.Exists(cfgFile)) 
            {
                File.Create(cfgFile);
            }
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
    }
}
