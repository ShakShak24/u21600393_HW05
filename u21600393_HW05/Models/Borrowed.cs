using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21600393_HW05.Models
{
    public class Borrowed
    {
        public int borrowId { get; set; }   
        public DateTime takenDate { get; set; }
        public DateTime broughtDate { get; set; }
        public string borrowedBy { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}