using LibraryManagement.Web.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.DesignationInterfaces
{
    interface IDesignation : IBaseEntities
    {
        [Required (ErrorMessage="Please enter Designation")]
        string Name { get; set; }
    }
}
