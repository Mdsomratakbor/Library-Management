using LibraryManagement.Web.ViewModels.MenuInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class MenuActionModel : IMenu
    {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ProjectName { get; set; }
        public int ParentId { get; set; }
        public bool IsParent { get; set; }
        public bool IsActive { get; set; }
        public string Icon { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? LUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateLUserID { get; set; }
    }
}