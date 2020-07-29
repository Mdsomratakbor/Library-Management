using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entities
{
    public class Menu:BaseEntities
    {
        public string MenuName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ProjectName { get; set; }
        public int ParentId { get; set; }
        public bool IsParent { get; set; }
        public string Icon { get; set; }
    }
}
