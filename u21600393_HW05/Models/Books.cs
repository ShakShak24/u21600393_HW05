using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21600393_HW05.Models
{
    public class Books
    {
        public int BookID { get; set; }
        public String Name { get; set; }
        public int pageCount { get; set; }
        public int Point { get; set; }
        public int AuthorID { get; set; }
        public int typeID { get; set; }
        
    }
}