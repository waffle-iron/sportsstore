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

        public int GetCount()
        {
            var rowCount = CriteriaTransformer.TransformToRowCount(
                DetachedCriteria.For<Product>()).GetExecutableCriteria(_session).UniqueResult<int>();
            return rowCount;
        }

        public IList<Product> GetByPage(int page, int pageSize)
        {
            int first = (page - 1) * pageSize;
            return _session.CreateCriteria(typeof(Product))
                .SetFirstResult(first)
                .SetMaxResults(pageSize)
                .List<Product>();
        }

        public Product Add(Product product)
        {
            _session.SaveOrUpdate(product);
            return product;
        }
    }
}
