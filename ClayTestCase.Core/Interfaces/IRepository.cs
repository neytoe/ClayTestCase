﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayTestCase.Core.Interfaces
{   
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> Find(int? id);
        Task Update(T t);
        Task Save(T t);
        Task Delete(int? id);
      
    }
    
}
