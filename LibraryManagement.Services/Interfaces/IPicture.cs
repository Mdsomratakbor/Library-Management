using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Interfaces
{
    interface IPicture
    {
        int SavePicture(Picture model);
        List<Picture> GetPicturesByIDs(List<int> idpictureIDs);
    }
}
