using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class StaffPicture
    {
        public int ID { get; set; }
        public int PictureID { get; set; }
        public List<Picture> Pictures { get; set; }
        public int StaffID { get; set; }
    }
}
