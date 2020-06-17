using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class BaseEntities
    {
        public int ID { get; set; }
        public DateTime EntryDate { get; set; }
        public int LUserID { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateLUserID { get; set; }
    }
}
