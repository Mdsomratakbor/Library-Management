﻿using LibraryManagement.Entities;
using LibraryManagement.Web.ViewModels.StudentInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagement.Web.ViewModels
{
    public class StudentActionModel : IStudent
    {
        public int ID { get; set; }
        [Required (ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessage = "Please enter Semester")]
        public string Semester { get; set; }      
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter Phone")]
        public List<StudentPicture> Pictures { get; set; }
        public string PictureIDs { get; set; }
        [Required(ErrorMessage = "Please enter Department")]
        public int DepartmentID { get; set; }
        public List<Department> Departments { get; set; }
        public string Phone { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? LUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateLUserID { get; set; }
    }
}