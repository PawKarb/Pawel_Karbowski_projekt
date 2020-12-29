using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pawel_Karbowski_projekt
{
    public partial class FormNotification : Form
    {
        private Note firstNoteNot;
        private MainForm mainForm;
        public FormNotification(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
            MainForm.listOfNotesNot = MainForm.listOfNotesNot.OrderBy(x => DateTime.Parse(x.DateNote)).ToList();
            firstNoteNot = MainForm.listOfNotesNot[0];
            label5.Text = firstNoteNot.DateNote;
            label6.Text = firstNoteNot.Name;
            addNoteListViewNot();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewNotif.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Czy chcesz usunąć to powiadomienie?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    ListViewItem item = listViewNotif.SelectedItems[0];
                    String name = listViewNotif.SelectedItems[0].Text;
                    foreach (Note lnote in MainForm.listOfNotesNot)
                    {
                        if (lnote.Name.Equals(name))
                        {
                            MainForm.listOfNotesNot.Remove(lnote);
                            lnote.IsNotification = false;
                            mainForm.ListSerializer();
                            break;
                        }
                    }
                    item.Remove();
                    if (!MainForm.listOfNotesNot.Any()) {
                        label5.Text = "";
                        label6.Text = "";
                    }
                }
                else {
                    return;    
                }
            }
            else
            {
                MessageBox.Show("Nie zaznaczono elementu!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czy napewno chcesz wrócić?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            else
            {
                this.Close();
            }
        }
        public void addNoteListViewNot()
        {
            foreach (Note lnote in MainForm.listOfNotesNot)
            {
                AddListViewNot(lnote);
            }
        }
        public void AddListViewNot(Note lvnote)
        {
            var item = new ListViewItem(new[] { lvnote.Name, lvnote.DateNote});
            listViewNotif.Items.Add(item);
        }
    }        
}
