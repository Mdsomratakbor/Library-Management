using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class Return
    {
        public int ID { get; set; }
        public int BooID { get; set; }
        public List<Book> Books { get; set; }
        public DateTime ReturnDate { get; set; }
        public int StudentID { get; set; }
        public List<Student> Students { get; set; }
        public int StaffID { get; set; }
    }
}
