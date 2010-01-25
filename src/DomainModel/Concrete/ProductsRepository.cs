using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Abstract;
using DomainModel.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace DomainModel.Concrete
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ISession _session;

        public ProductsRepository(ISession session)
        {
            _session = session;
        }

        public IList<Product> GetAll()
        {
            var criteria = DetachedCriteria.For<Product>();
            return criteria.GetExecutableCriteria(_session).List<Product>();
        }
    }
}
