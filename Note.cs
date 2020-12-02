using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawel_Karbowski_projekt
{
    public class Note
    {
        public String Name { get; set; }
        public String DateNote { get; set; }
        public Importance importance { get; set; }
        public Extension extension { get; set; }
        public String TextNote { get; set; }
        public Boolean IsNotification { get; set; }

        public Note() { 
        }

        public Note(string name, string dateNote, Importance importance, Extension extension, string textNote, bool isNotification)
        {
            Name = name;
            DateNote = dateNote;
            this.importance = importance;
            this.extension = extension;
            TextNote = textNote;
            IsNotification = isNotification;
        }

        public override string ToString()
        {
            return Name + ", " + DateNote + ", " + this.importance + ", " + this.extension + ", " + TextNote + ", " + IsNotification; 
        }
    }
}
