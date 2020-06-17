using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class Issue
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public List<Book> Books { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiraryDate { get; set; }
        public int StudentID { get; set; }
        public List<Student> Students { get; set; }
        
    }
}
