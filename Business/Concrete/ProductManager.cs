using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal= productDal;
        }
        public string Add(Product product)
        {
            _productDal.Add(product);
            return "Ekleme Başarılı";
        }

        public string Delete(Product product)
        {
            _productDal.Delete(product);
            return "Silme Başarılı";
        }

        public List<Product> GetAll()
        {
            List<Product> products = _productDal.GetAll().ToList();
            return products;
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(x => x.ProductId == productId);
        }

        public string Update(Product product)
        {
            _productDal.Update(product);
            return "Güncelleme Başarılı";
        }
    }
}
