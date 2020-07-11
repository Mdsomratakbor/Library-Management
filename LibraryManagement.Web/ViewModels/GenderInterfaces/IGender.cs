using LibraryManagement.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.GenderInterfaces
{
   public interface IGender
    {
        List<GenderEnums> Genders { get; set; }
    }
}
