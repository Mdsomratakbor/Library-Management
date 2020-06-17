using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class Staff : BaseEntities
    {
        public string Name { get; set; }
        public string DesignationID { get; set; }
        public virtual Designation Designations { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<StaffPicture> StaffPictures { get; set; }
    }
}
