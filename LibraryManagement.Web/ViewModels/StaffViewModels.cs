using LibraryManagement.Entities;
using LibraryManagement.Services.Enums;
using LibraryManagement.Web.ViewModels.StaffInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class StaffActionModel : IStaff
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter contact address")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Please enter  address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter  city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter  Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter  Phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter  Gender")]
        public string Gender { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? LUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateLUserID { get; set; }
        [Required(ErrorMessage = "Please enter Designation")]
        public int DesignationID { get; set; }
        public List<Designation> Designations { get; set; }
        public List<StaffPicture> Pictures { get; set; }
        public string PictureIDs { get; set; }
        public List<GenderEnums> Genders { get; set; }
    }
}