using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawel_Karbowski_projekt
{
    public class Note
    {
        public String name { get; set; }
        public String dateNote { get; set; }
        public Importance importance { get; set; }
        public String textNote { get; set; }
        public Boolean isNotification { get; set; }
        public Note(string nazwa, string data, Importance waznosc, string tekst, bool powiadomienie)
        {
            name = nazwa;
            dateNote = data;
            importance = waznosc;
            textNote = tekst;
            isNotification = powiadomienie;
        }
        public Note() { 
        }
        public override string ToString()
        {
            return name + ", " + dateNote + ", " + importance + ", " + textNote +", "+ isNotification;
        }


    }
}
