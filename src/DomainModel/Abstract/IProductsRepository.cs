﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;

namespace DomainModel.Abstract
{
    public interface IProductsRepository
    {
        int GetCount();
        IList<Product> GetByPage(int page, int pageSize);
        Product Add(Product product);
    }
}
