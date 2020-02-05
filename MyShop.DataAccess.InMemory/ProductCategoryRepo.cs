using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepo
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;
        public ProductCategoryRepo()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }

        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }


        public void Insert(ProductCategory p)
        {

            productCategories.Add(p);
        }

        public void Update(ProductCategory productCategory)
        {

            ProductCategory productToUpdate = productCategories.Find(p => p.Id == productCategory.Id);
            if (productToUpdate != null)
            {
                productToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product not found ");

            }

        }


        public ProductCategory Find(string Id)
        {
            ProductCategory product = productCategories.Find(p => p.Id == Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not found ");

            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productToDelete = productCategories.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                productCategories.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found ");

            }
        }
    }
}