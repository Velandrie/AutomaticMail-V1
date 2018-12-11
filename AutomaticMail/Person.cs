using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticMail
{
    //Excel'de tutulan her bir kişinin bilgilerinin tutulması için yaratılan Person sınıfı
    class Person
    {
        public int RowId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Sex { get; set; }
        public string Company { get; set; }
        public string Sector { get; set; }
        public string Group { get; set; }
        public string ReceiverMail { get; set; }
        public string Phone { get; set; }
        public string LastMeeting { get; set; }
        public string MeetingType { get; set; }
        public string LastMailDate { get; set; }
        public string Note { get; set; }
    }
}
