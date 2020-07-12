using LibraryManagement.Data;
using LibraryManagement.Entities;
using LibraryManagement.Services.Abstractclass;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class DesignationServices : LibraryMangementServices<Designation>, IDesigantionServices
    {   
        public List<Designation> GetAllData(int displayLength, int displayStart, int sortCol, string sortDir, string search = null)
        {
            using (var _LMContext = new LMContext())
            {
                string columnNameAsc = "";
                string columnNameDsc = "";
                List<Designation> categories = new List<Designation>();
                if (sortCol == 0 && sortDir == "asc") columnNameAsc = "Name";
                else if (sortCol == 0 && sortDir == "dsc") columnNameDsc = "Name";
                else if (sortCol == 1 && sortDir == "asc") columnNameAsc = "Description";
                else if (sortCol == 1 && sortDir == "dsc") columnNameDsc = "Description";
                if (sortDir == "asc" && string.IsNullOrEmpty(search) == false)
                {
                    categories = _LMContext.Designations.OrderBy(x => columnNameAsc).Where(x => x.Name.ToString().ToLower().Contains(search.ToLower())).ToList();
                }

                else if (sortDir == "dsc" && string.IsNullOrEmpty(search) == false)
                {
                    categories = _LMContext.Designations.OrderBy(x => columnNameDsc).Where(x => x.Name.ToString().ToLower().Contains(search.ToLower())).ToList();
                }
                else if (sortDir == "asc")
                {
                    categories = _LMContext.Designations.OrderBy(x => columnNameAsc).ToList();
                }
                else
                {
                    categories = _LMContext.Designations.OrderBy(x => columnNameDsc).ToList();
                }
                return categories;
            }
        }         
    }
}
