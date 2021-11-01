﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPi.Services
{
    public interface ICollectionService<T>
    {

        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<bool> Create(T model);
        Task<bool> Update(Guid id, T model);
        Task<bool> Delete(Guid id);


    }
}
