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
            return ctx.Products.Include(u => u.ProductAllergies).Single(x => x.ProductId == productId);
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
            return ctx.Products.Include(u => u.ProductAllergies).AsEnumerable();
        }
        public IEnumerable<Allergie> ReadAllergies()
        {
            List<Allergie> allergies = new List<Allergie>();
            List<string> uniqueAllergies = new List<string>();

                foreach (Allergie readProductProductAllergy in ctx.Allergies.AsEnumerable())
                {
                    if (! uniqueAllergies.Contains(readProductProductAllergy.Naam))
                    {
                        uniqueAllergies.Add(readProductProductAllergy.Naam);
                        allergies.Add(readProductProductAllergy);
                    }
                }

            return allergies.OrderBy(o => o.Naam);
        }

        public IEnumerable<OpeningsUur> ReadOpeningstijden()
        {
            return ctx.OpeningsTijden.AsEnumerable();
        }

        public IEnumerable<Vakantie> ReadVakanties()
        {
            return ctx.Vakanties.AsEnumerable();
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
    }
}