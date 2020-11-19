using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawel_Karbowski_projekt
{
    interface IListOfNotes
    {
        void saveNoteList(Note note);
        void delNoteList(Note note);
    }
}
