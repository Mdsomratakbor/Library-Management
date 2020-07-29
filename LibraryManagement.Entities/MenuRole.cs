using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class MenuRole : BaseEntities
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public virtual Menu Menus{get;set;}
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsCreate { get; set; }

    }
}
