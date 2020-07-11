using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Web.ViewModels.Interfaces
{
    public interface IBaseEntities
    {
         int ID { get; set; }
         DateTime? EntryDate { get; set; }
         int? LUserID { get; set; }
         DateTime? UpdateDate { get; set; }
         int? UpdateLUserID { get; set; }
    }
}
