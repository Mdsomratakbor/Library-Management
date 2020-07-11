using LibraryManagement.Entities;
using LibraryManagement.Web.ViewModels.DesignationInterfaces;
using LibraryManagement.Web.ViewModels.GenderInterfaces;
using LibraryManagement.Web.ViewModels.ImageInterfaces;
using LibraryManagement.Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.StaffInterfaces
{
    public interface IStaff : IBaseEntities, IDesignatioList, IPicture<StaffPicture>, IGender
    {
        string Name { get; set; }
        int DesignationID { get; set; }
        string Contact { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Gender { get; set; }
    }
}
