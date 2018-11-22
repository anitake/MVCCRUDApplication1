using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCRUDApplication1.Models.Repository
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();

        Product GetById(int id);

        void Create(Product product);

        void Update(Product product);

        void Delete(Product product);

    }
}
