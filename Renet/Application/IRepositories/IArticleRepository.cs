﻿using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories;
public interface IArticleRepository : IRepository {
   
    Task<IEnumerable<Article>> GetByProductId(Guid productId);
}