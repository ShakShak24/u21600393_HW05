using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21600393_HW05.Models
{
    public class Borrows
    {
        public int borrowID { get; set; }
        public int StudentID { get; set; }
        public int BookID { get; set; }
        public DateTime takenDate { get; set; }
        public DateTime broughtDate { get; set; }
    }
}