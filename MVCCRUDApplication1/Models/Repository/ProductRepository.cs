using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCCRUDApplication1.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected storeEntities fDb
        {
            get;
            private set;
        }

        public ProductRepository()
        {
            this.fDb = new storeEntities();
        }

        public void Create(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }
            else
            {
                fDb.Products.Add(product);
                fDb.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }
            else
            {
                fDb.Entry(product).State = EntityState.Deleted;
                fDb.SaveChanges();
            }
        }

        public IQueryable<Product> GetAll()
        {
            return fDb.Products.AsQueryable();
        }

        public Product GetById(int id)
        {
            return fDb.Products.Find(id);
        }

        public void Update(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product");
            }
            else
            {
                fDb.Entry(product).State = EntityState.Modified;
                fDb.SaveChanges();
            }
        }

        public IList<int> GetCategoryIds()
        {
            return fDb.Products.GroupBy(x => x.CategoryID)
                .Select(y => y.Key).ToList();
        }
    }
}