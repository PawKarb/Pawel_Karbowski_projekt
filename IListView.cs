using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pawel_Karbowski_projekt
{
    interface IListView
    {
       void addNoteListView();
        void RemoveListView(ListViewItem listViewItem);
    }
}
