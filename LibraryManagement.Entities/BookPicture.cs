using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class BookPicture
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int PictureID { get; set; }    
        public virtual Picture Pictures { get; set; }
        
    }
}
