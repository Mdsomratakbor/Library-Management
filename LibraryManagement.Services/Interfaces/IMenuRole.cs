﻿using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Interfaces
{
    public interface IMenuRole:IServices<MenuRole>
    {
        List<MenuRole> GetAllData();
    }
}
