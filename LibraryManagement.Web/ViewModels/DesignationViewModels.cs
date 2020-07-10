using LibraryManagement.Web.ViewModels.DesignationInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class DesignationActionModel : IDesignation
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter Designation")]
        public string Name { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? LUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateLUserID { get; set; }
    }
}