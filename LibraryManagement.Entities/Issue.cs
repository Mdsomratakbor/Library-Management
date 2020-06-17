using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class Issue : BaseEntities
    {
        public int BookID { get; set; }
        public virtual Book Books { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiraryDate { get; set; }
        public int StudentID { get; set; }
        public virtual Student Students { get; set; }
        
    }
}
