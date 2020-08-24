using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class MenuRole : BaseEntities
    {
        public string  RoleId { get; set; }      
        public virtual List<RoleOfMenu> RoleOfMenus{get;set;}
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsCreate { get; set; }
    }
}
