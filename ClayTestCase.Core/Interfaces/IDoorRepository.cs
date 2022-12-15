﻿using ClayTestCase.Core.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Interfaces
{
    public interface IDoorRepository : IRepository<Door>
    {
        Task<bool> OpenDoor(int doorId, string role);
    }
}
