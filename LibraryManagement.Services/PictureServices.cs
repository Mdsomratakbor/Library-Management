using LibraryManagement.Data;
using LibraryManagement.Entities;
using LibraryManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class PictureServices :IPicture
    {
        #region Singletone
        public static PictureServices Instance
        {
            get
            {
                if (instance == null) instance = new PictureServices();
                return instance;
            }
        }
        private static PictureServices instance { get; set; }
        #endregion
        private readonly LMContext _LMContext;
        public PictureServices()
        {
            _LMContext = new LMContext();
        }
        public int SavePicture(Picture picture)
        {
            _LMContext.Pictures.Add(picture);
            _LMContext.SaveChanges();
            return picture.ID;
        }
        public List<Picture> GetPicturesByIDs(List<int> pictureIDs)
        {
            return pictureIDs.Select(x => _LMContext.Pictures.Find(x)).ToList();
        }

        
    }
}
