using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21600393_HW05.Models
{
    public class BooksVM
    {
        public List<Books> Books { get; set; }
        public List<Authors> Authors { get; set; }

        public List<Borrows> Borrows { get; set; }
        public List<Types> Types { get; set; }
        public List<Students> Students { get; set; } 

        //public String getAuthorName(int iD)
        //{
        //    List<Authors> name = (List<Authors>)Authors.Where(x => x.authorId == iD).Select(s => s.Name);
        //    return name.ToString();
        //}
    }
}