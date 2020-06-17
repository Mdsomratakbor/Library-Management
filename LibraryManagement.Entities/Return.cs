using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class Return : BaseEntities
    {
        public int BookID { get; set; }
        public virtual Book Books { get; set; }
        public DateTime ReturnDate { get; set; }
        public int StudentID { get; set; }
        public virtual Student Students { get; set; }
        public int StaffID { get; set; }
        public virtual Staff Staffs { get; set; }

    }
}
