using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;
using FluentNHibernate.Mapping;

namespace DomainModel.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Price);
            Map(x => x.Category);
        }
    }
}
