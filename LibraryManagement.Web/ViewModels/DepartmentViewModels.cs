using LibraryManagement.Entities;
using LibraryManagement.Web.ViewModels.DepartmentInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class DepartmentActionModel : IDepartment, IDepartmentList
    {
        public int ID { get; set; }
        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? LUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateLUserID { get; set; }
        public List<Department> Departments { get; set; }
    
    }
}