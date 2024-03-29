﻿using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface ICategoryRepository : IRepository
    {
        Task<IEnumerable<Category>> GetAll();
    }
}
