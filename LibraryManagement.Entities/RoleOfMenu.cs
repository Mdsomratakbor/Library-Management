using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class RoleOfMenu
    {
        public int ID { get; set; }
        public int MenuRoleId { get; set; }
        public int MenuId { get; set; }
        public virtual Menu Menu { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsCreate { get; set; }
    }
}
