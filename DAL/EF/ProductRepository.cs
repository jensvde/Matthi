using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class ProductRepository : IProductRepository
    {
        private TwinkeltjeDbContext ctx = null;

        public ProductRepository()
        {
            ctx = new TwinkeltjeDbContext();
            TwinkeltjeDbContext.Initialize(ctx, true);
        }
        
        public Product CreateProduct(Product product)
        {
            ctx.Products.Add(product);
            ctx.SaveChanges();
            return product;
        }

        public Product ReadProduct(int productId)
        {
            return ctx.Products.Find(productId);
        }

        public void UpdateProduct(Product product)
        {
            ctx.Products.Update(product);
            ctx.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            ctx.Products.Remove(product);
            ctx.SaveChanges();
        }

        public IEnumerable<Product> ReadProducts()
        {
            return ctx.Products.Include("ProductAllergies").AsEnumerable();
        }

        public Allergie CreateAllergie(Allergie allergie)
        {
            ctx.Allergies.Add(allergie);
            ctx.SaveChanges();
            return allergie;
        }

        public Allergie ReadAllergie(int allergieId)
        {
            return ctx.Allergies.Find(allergieId);
        }

        public void DeleteAllergie(Allergie allergie)
        {
            ctx.Allergies.Remove(allergie);
            ctx.SaveChanges();
        }

        public void UpdateAllergie(Allergie allergie)
        {
            ctx.Allergies.Update(allergie);
            ctx.SaveChanges();
        }

        public IEnumerable<Allergie> ReadAllergies()
        {
            return ctx.Allergies.AsEnumerable();
        }
    }
}