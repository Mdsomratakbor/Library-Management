using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class LibraryManagementDBInitializer : CreateDatabaseIfNotExists<LMContext>
    {
    }
}
